using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Util;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HN.Management.Engine.CosmosDb.Client
{
    public class CosmosDbClient<T> : ICosmosDbClient<T>
         where T : IBaseEntity
    {
        // If not provider, cosmos' default value is 100 for MaxItemCount.
        // -1 let's cosmos decide on the maximum. Currently this number is around 1220 items.
        private const int DefaultMaxItemCount = -1;
        private const int DefaultMaxConcurrency = -1;

        private const int CosmosExceptionRetryWithStatusCode = 449;
        private const int MaxRetries = 6;

        private readonly QueryRequestOptions defaultQueryRequestOptions = new()
        {
            MaxItemCount = DefaultMaxItemCount,
        };

        private readonly Func<int, TimeSpan> exponentialBackoffStrategy = (retryAttempt) => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
        private readonly Func<CosmosException, bool> retryPolicyExceptionPredicate = (ex) =>
                                                ex.StatusCode == HttpStatusCode.TooManyRequests
                                             || ex.StatusCode == HttpStatusCode.RequestTimeout
                                             || ex.StatusCode == HttpStatusCode.ServiceUnavailable
                                             || (int)ex.StatusCode == CosmosExceptionRetryWithStatusCode;

        private readonly string databaseName;
        private readonly string collectionName;
        private readonly bool logRequestCharges;
        private readonly Container container;
        private readonly IAsyncPolicy cosmosExceptionPolicyAsync;
        private readonly IAsyncPolicy cosmosConflictRetryPolicyAsync;
        private readonly RetryPolicy cosmosExceptionPolicy;

        public CosmosDbClient(
            CosmosClient cosmosClient,
            string databaseName,
            string collectionName,
            IConfiguration configuration)
        {
            if (cosmosClient is null)
            {
                throw new ArgumentNullException(nameof(cosmosClient));
            }

            if (databaseName is null)
            {
                throw new ArgumentNullException(nameof(databaseName));
            }

            if (collectionName is null)
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            this.databaseName = databaseName;
            this.collectionName = collectionName;
            this.container = cosmosClient.GetContainer(this.databaseName, this.collectionName);
            this.cosmosExceptionPolicyAsync = Policy
                .Handle(this.retryPolicyExceptionPredicate)
                .WaitAndRetryAsync(
                    retryCount: MaxRetries,
                    this.exponentialBackoffStrategy,
                    (ex, retriedAfter, context) => Console.WriteLine( $"{ex }, Retrying an async cosmos call after {retriedAfter.TotalSeconds} seconds."));

            this.cosmosExceptionPolicy = Policy
                .Handle(this.retryPolicyExceptionPredicate)
                .WaitAndRetry(
                    retryCount: MaxRetries,
                    this.exponentialBackoffStrategy,
                    (ex, retriedAfter, context) => Console.WriteLine($"{ex}, Retrying a sync cosmos call after {retriedAfter.TotalSeconds} seconds."));

            this.cosmosConflictRetryPolicyAsync = Policy
                .Handle((CosmosException ex) => ex.StatusCode == HttpStatusCode.PreconditionFailed)
                .RetryAsync(
                    retryCount: MaxRetries,
                    (ex, retriedAfter, context) => Console.WriteLine($"{ex}, Retrying a sync cosmos call after conflict."));

            this.logRequestCharges = configuration.GetSection("ApplicationInsights:LogRequestCharges").Get<bool>();
        }

        public bool CollectionExists(string databaseName, string collectionName)
        {
            return this.databaseName == databaseName && this.collectionName == collectionName;
        }

        public async Task<T> GetItemByIdAsync(string itemId, string partitionKey = null)
        {
            try
            {
                return await this.cosmosExceptionPolicyAsync
                    .ExecuteAsync(
                        async () => string.IsNullOrEmpty(partitionKey)
                            ? this.GetAllItemsByExpressionAsQueryable(document => document.Id == itemId)
                                  .Take(1)
                                  .ToList()
                                  .FirstOrDefault()
                            : await this.container.ReadItemAsync<T>(itemId, new PartitionKey(partitionKey)));
            }
            catch (CosmosException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<IEnumerable<T>> GetPaginatedItemsByExpressionAsync(
           Expression<Func<T, bool>> predicate,
           int skip,
           int take,
           string partitionKey = null)
        {
            return await this.GetPaginatedItemsByExpressionAsync<object>(predicate, null, SortDirection.None, skip, take, partitionKey);
        }

        public async Task<IList<T>> GetPaginatedItemsByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            int skip,
            int take,
            string partitionKey = null)
        {
            return await this.GetPaginatedItemsByExpressionAsync<object>(predicate, null, SortDirection.None, skip, take, partitionKey);
        }

        public async Task<IEnumerable<T>> GetPaginatedItemsByExpressionAsync<TKey>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderPredicate,
            SortDirection sortDirection,
            int skip,
            int take,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync
               .ExecuteAsync(async () => await this.container.GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                                                    .Where(predicate)
                                                    .ApplyOrdering(sortDirection, orderPredicate)
                                                    .Skip(skip)
                                                    .Take(take)
                                                    .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public async Task<IList<T>> GetPaginatedItemsByExpressionAsync<TKey>(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            Expression<Func<T, TKey>> orderPredicate,
            SortDirection sortDirection,
            int skip,
            int take,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync
               .ExecuteAsync(async () => await this.container.GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                                                    .ApplyPredicate(predicate)
                                                    .ApplyOrdering(sortDirection, orderPredicate)
                                                    .Skip(skip)
                                                    .Take(take)
                                                    .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public async Task<IList<T>> GetPaginatedItemsByExpressionAsync<TKey>(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            IList<(Expression<Func<T, TKey>> sortPredicate, SortDirection sortDirection)> sortOperations,
            int skip,
            int take,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync
               .ExecuteAsync(async () => await this.container.GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                                                .ApplyPredicate(predicate)
                                                .ApplyMultiOrdering(sortOperations)
                                                .Skip(skip)
                                                .Take(take)
                                                .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public IQueryable<T> GetAllItemsByExpressionAsQueryable(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            var policyResult = this.cosmosExceptionPolicy
                .ExecuteAndCapture(() => this.container
                    .GetItemLinqQueryable<T>(
                        allowSynchronousQueryExecution: true,
                        requestOptions: queryRequestOptions)
                    .Where(predicate));

            return policyResult.Result;
        }

        public async Task<IEnumerable<T>> GetAllItemsByExpressionAsync(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync
                .ExecuteAsync(async () => await this.container
                        .GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                        .Where(predicate)
                        .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public IEnumerable<T> GetAllItemsByExpression(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            var policyResult = this.cosmosExceptionPolicy.ExecuteAndCapture(() =>
                predicate(this.container.GetItemLinqQueryable<T>(
                    allowSynchronousQueryExecution: true,
                    requestOptions: queryRequestOptions)));

            return policyResult.Result;
        }

        public async Task<IEnumerable<T>> GetAllItemsByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync
                .ExecuteAsync(async () => await this.container
                        .GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                        .ApplyPredicate(predicate)
                        .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public async Task<IEnumerable<TResult>> GetAllItemsByExpressionAsync<TResult>(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            Expression<Func<T, TResult>> select,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync
                .ExecuteAsync(async () => await this.container.GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                        .ApplyPredicate(predicate)
                        .Select(select)
                        .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public async Task<int> GetCountByExpressionAsync(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync.ExecuteAsync(async () =>
                    await this.container.GetItemLinqQueryable<T>(requestOptions: queryRequestOptions)
                                        .Where(predicate)
                                        .CountAsync());
        }

        public async Task<int> GetCountByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            return await this.cosmosExceptionPolicyAsync.ExecuteAsync(async () =>
                await predicate(this.container.GetItemLinqQueryable<T>(requestOptions: queryRequestOptions))
                    .CountAsync());
        }

        public IQueryable<T> GetItemsByExpressionAsQueryable(Func<IQueryable<T>, IQueryable<T>> predicate)
        {
            var policyResult = this.cosmosExceptionPolicy.ExecuteAndCapture(() =>
                predicate(this.container.GetItemLinqQueryable<T>(
                    allowSynchronousQueryExecution: true,
                    requestOptions: this.defaultQueryRequestOptions)));

            return policyResult.Result;
        }

        public IQueryable<T> GetItemsByExpressionAsQueryable(Expression<Func<T, bool>> predicate)
        {
            var policyResult = this.cosmosExceptionPolicy.ExecuteAndCapture(() =>
                this.container.GetItemLinqQueryable<T>(allowSynchronousQueryExecution: true, requestOptions: this.defaultQueryRequestOptions)
                              .Where(predicate));

            return policyResult.Result;
        }

        public async Task<IList<T>> GetItemsBySqlExpressionAsync(
            string sqlExpression,
            IDictionary<string, string> parameters,
            bool getAllResults,
            int skip = 0,
            int take = 50,
            string partitionKey = null)
        {
            var queryRequestOptions = new QueryRequestOptions()
            {
                MaxConcurrency = DefaultMaxConcurrency,
                MaxItemCount = DefaultMaxItemCount,
                PartitionKey = partitionKey == null ? null : new PartitionKey(partitionKey),
            };

            var sqlExpressionToExecute = $"{sqlExpression}";

            if (!getAllResults)
            {
                queryRequestOptions.MaxItemCount = take;
                sqlExpressionToExecute = $"{sqlExpression} OFFSET {skip} LIMIT {take}";
            }

            var queryDefinition = new QueryDefinition(sqlExpressionToExecute);
            foreach (var parameter in parameters)
            {
                queryDefinition = queryDefinition.WithParameter(parameter.Key, parameter.Value);
            }

            return await this.cosmosExceptionPolicyAsync.ExecuteAsync(async () =>
                await this.container.GetItemQueryIterator<T>(queryDefinition, null, queryRequestOptions)
                                    .ToListAsync(this.logRequestCharges, this.databaseName, this.collectionName));
        }

        public IOrderedQueryable<T> GetAllItemsAsQueryable(QueryRequestOptions requestOptions = null)
        {
            requestOptions ??= this.defaultQueryRequestOptions;

            var policyResult = this.cosmosExceptionPolicy.ExecuteAndCapture(() =>
                this.container.GetItemLinqQueryable<T>(
                    allowSynchronousQueryExecution: true,
                    requestOptions: requestOptions));

            return policyResult.Result;
        }

        public async Task<IList<T>> GetAllItemsAsync()
        {
            var requestChargeLog = this.logRequestCharges ? new Dictionary<string, dynamic>
                {
                    { "requestOrigin", "CosmosDbClient" },
                    { "method", "GetAllItemsAsync" },
                    { "database", this.databaseName },
                    { "collection", this.collectionName },
                    { "requestCharges", 0 },
                }
                : null;

            var items = new List<T>();

            var feedIterator = this.container
                .GetItemLinqQueryable<T>(requestOptions: this.defaultQueryRequestOptions)
                .ToFeedIterator();

            while (feedIterator.HasMoreResults)
            {
                var result = await this.cosmosExceptionPolicyAsync.ExecuteAsync(async () =>
                    await feedIterator.ReadNextAsync());
                items.AddRange(result.ToList());

                if (this.logRequestCharges)
                {
                    requestChargeLog["requestCharges"] = requestChargeLog["requestCharges"] += result.RequestCharge;
                    requestChargeLog["activityId"] = result.ActivityId;
                }
            }

            if (this.logRequestCharges)
            {
                Console.WriteLine(requestChargeLog.ToJsonString());
            }

            return items;
        }

        public async Task<T> CreateItemAsync(T instance)
        {
            return await this.cosmosExceptionPolicyAsync
                .ExecuteAsync<T>(
                    async () => await this.container.CreateItemAsync(instance, new PartitionKey(instance.PartitionKey)));
        }

        public async Task<T> ReplaceItemAsync(T instance, bool ifMatchEtag = false)
        {
            ItemRequestOptions requestOptions = null;
            if (ifMatchEtag)
            {
                requestOptions = new ItemRequestOptions { IfMatchEtag = instance.Etag };
            }

            return await this.cosmosExceptionPolicyAsync
                .ExecuteAsync<T>(
                    async () => await this.container.ReplaceItemAsync(instance, instance.Id, new PartitionKey(instance.PartitionKey), requestOptions));
        }

        public async Task<T> UpdateItemAsync(Func<T, T> updateItem, string id, string partitionKey = null)
        {
            async Task<T> Update()
            {
                var item = await this.GetItemByIdAsync(id, partitionKey);
                var updatedItem = updateItem(item);
                updatedItem = await this.ReplaceItemAsync(updatedItem, true);
                return updatedItem;
            }

            return await this.cosmosConflictRetryPolicyAsync.ExecuteAsync(Update);
        }

        public async Task<T> UpsertItemAsync(T item)
        {
            var response = await this.cosmosExceptionPolicyAsync
                .ExecuteAsync<T>(async () =>
                {
                    var response = await this.container.UpsertItemAsync(item, new PartitionKey(item.PartitionKey));
                    return response;
                });
            return response;
        }

        public async Task DeleteItemAsync(T instance)
        {
            await this.cosmosExceptionPolicyAsync
                .ExecuteAsync<T>(
                    async () => await this.container.DeleteItemAsync<T>(instance.Id, new PartitionKey(instance.PartitionKey)));
        }

        public async Task DeleteItemAsync(string id, string partitionKey = null)
        {
            partitionKey ??= id;

            await this.cosmosExceptionPolicyAsync
                .ExecuteAsync<T>(
                    async () => await this.container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey)));
        }

        public async Task DeleteItemAsync(string id, PartitionKey partitionKey)
        {
            await this.cosmosExceptionPolicyAsync
                .ExecuteAsync<T>(
                    async () => await this.container.DeleteItemAsync<T>(id, partitionKey));
        }

        public async Task<ContainerProperties> GetContainerPropertiesAsync()
        {
            var properties = await this.container.ReadContainerAsync();
            return properties;
        }
    }
}
