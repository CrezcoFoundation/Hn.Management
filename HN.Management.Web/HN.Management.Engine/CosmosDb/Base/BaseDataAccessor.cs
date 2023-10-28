using HN.Management.Engine.CosmosDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HN.Management.Engine.CosmosDb.Base
{
    public abstract class BaseDataAccessor<T> : IDataManager<T>
        where T : IBaseEntity
    {
        private readonly ICosmosDbClient<T> cosmosDbClient;

        public BaseDataAccessor(ICosmosDbClient<T> cosmosDbClient)
        {
            this.cosmosDbClient = cosmosDbClient;
        }

        public virtual async Task<T> GetItemByIdAsync(string id, string partitionKey = null)
        {
            var item = await this.cosmosDbClient.GetItemByIdAsync(id, partitionKey);

            if (item is null)
            {
                return item;
            }

            this.CheckItemAccessible(item);

            return item;
        }

        public IQueryable<T> GetAllItemsByExpressionAsQueryable(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null)
        {
            return this.FilterAccessibleItems(
                this.cosmosDbClient.GetAllItemsByExpressionAsQueryable(
                    predicate,
                    partitionKey));
        }

        public async Task<IEnumerable<T>> GetAllItemsByExpressionAsync(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null)
        {
            var items = await this.cosmosDbClient.GetAllItemsByExpressionAsync(predicate, partitionKey);
            return items.Where(this.IsItemAccessible);
        }

        public IEnumerable<T> GetAllItemsByExpression(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null)
        {
            var items = this.cosmosDbClient.GetAllItemsByExpression(predicate, partitionKey);
            return items.Where(this.IsItemAccessible);
        }

        public async Task<IEnumerable<T>> GetAllItemsByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null)
        {
            var items = await this.cosmosDbClient.GetAllItemsByExpressionAsync(predicate, partitionKey);
            return items.Where(this.IsItemAccessible);
        }

        public async Task<bool> IsItemAccessibleAsync(string id, string partitionKey = null)
        {
            var item = await this.cosmosDbClient.GetItemByIdAsync(id, partitionKey);
            return this.IsItemAccessible(item);
        }

        public virtual Task<T> CreateItemAsync(T item)
        {
            this.CheckItemAccessible(item);
            return this.cosmosDbClient.CreateItemAsync(item);
        }

        public async Task DeleteItemAsync(string id, string partitionkey = null)
        {
            var item = await this.cosmosDbClient.GetItemByIdAsync(id);
            this.CheckItemAccessible(item);
            await this.cosmosDbClient.DeleteItemAsync(id, partitionkey);
        }

        public async Task DeleteItemAsync(T item)
        {
            this.CheckItemAccessible(item);
            await this.cosmosDbClient.DeleteItemAsync(item);
        }

        public virtual async Task<T> UpdateItemAsync(T item)
        {
            this.CheckItemAccessible(item);
            return await this.cosmosDbClient.ReplaceItemAsync(item, ifMatchEtag: true);
        }

        public virtual async Task<T> UpdateItemAsync(Func<T, T> updateItem, string id, string partitionkey = null)
        {
            T UpdateItemWithAccessCheck(T item)
            {
                this.CheckItemAccessible(item);
                return updateItem(item);
            }

            return await this.cosmosDbClient.UpdateItemAsync(UpdateItemWithAccessCheck, id, partitionkey);
        }


        public async Task<T> UpsertItemAsync(T item)
        {
            this.CheckItemAccessible(item);

#if DEBUG
            var props = await this.cosmosDbClient.GetContainerPropertiesAsync();

            Console.WriteLine(props.PartitionKeyPath);
#endif

            return await this.cosmosDbClient.UpsertItemAsync(item);
        }

        public abstract IQueryable<T> GetAllAccessibleItemsAsQueryable();

        public abstract Task<IList<T>> GetAllAccessibleItemsAsync();

        public async Task<IList<T>> GetItemsBySqlExpressionAsync(string sqlExpression, IDictionary<string, string>
                                                                    parameters, bool getAllResults)
        {

            return await this.cosmosDbClient.GetItemsBySqlExpressionAsync(sqlExpression, parameters, getAllResults);
        }

        protected IQueryable<T> GetAllItems()
        {
            return this.cosmosDbClient.GetAllItemsAsQueryable();
        }


        protected async Task<IList<T>> GetAllItemsAsync()
        {
            return await this.cosmosDbClient.GetAllItemsAsync();
        }

        protected abstract IQueryable<T> FilterAccessibleItems(IQueryable<T> query);
        protected abstract bool IsItemAccessible(T item);

        protected void CheckItemAccessible(T item)
        {
            if (!this.IsItemAccessible(item))
            {
                throw new System.UnauthorizedAccessException($"Unauthorized access to resource: {nameof(T)}");
            }
        }
    }
}
