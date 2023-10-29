using HN.Management.Engine.Util;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PartitionKey = Microsoft.Azure.Cosmos.PartitionKey;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
     public interface ICosmosDbClient<T>
    {
        bool CollectionExists(string databaseName, string collectionName);

        Task<T> GetItemByIdAsync(
            string itemId,
            string partitionKey = null);

        Task<IEnumerable<T>> GetPaginatedItemsByExpressionAsync(
            Expression<Func<T, bool>> predicate,
            int skip,
            int take,
            string partitionKey = null);

        Task<IList<T>> GetPaginatedItemsByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            int skip,
            int take,
            string partitionKey = null);

        Task<IEnumerable<T>> GetPaginatedItemsByExpressionAsync<TKey>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TKey>> orderPredicate,
            SortDirection sortDirection,
            int skip,
            int take,
            string partitionKey = null);

        Task<IList<T>> GetPaginatedItemsByExpressionAsync<TKey>(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            Expression<Func<T, TKey>> orderPredicate,
            SortDirection sortDirection,
            int skip,
            int take,
            string partitionKey = null);

        Task<IList<T>> GetPaginatedItemsByExpressionAsync<TKey>(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            IList<(Expression<Func<T, TKey>> sortPredicate, SortDirection sortDirection)> sortOperations,
            int skip,
            int take,
            string partitionKey = null);

        IQueryable<T> GetAllItemsByExpressionAsQueryable(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null);

        Task<IEnumerable<T>> GetAllItemsByExpressionAsync(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null);

        IEnumerable<T> GetAllItemsByExpression(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null);

        Task<IEnumerable<T>> GetAllItemsByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null);

        Task<IEnumerable<TResult>> GetAllItemsByExpressionAsync<TResult>(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            Expression<Func<T, TResult>> select,
            string partitionKey = null);

        Task<int> GetCountByExpressionAsync(
            Expression<Func<T, bool>> predicate,
            string partitionKey = null);

        Task<int> GetCountByExpressionAsync(
            Func<IQueryable<T>, IQueryable<T>> predicate,
            string partitionKey = null);

        IQueryable<T> GetItemsByExpressionAsQueryable(
            Func<IQueryable<T>, IQueryable<T>> predicate);

        IQueryable<T> GetItemsByExpressionAsQueryable(
            Expression<Func<T, bool>> predicate);

        Task<IList<T>> GetItemsBySqlExpressionAsync(
            string sqlExpression,
            IDictionary<string, string> parameters,
            bool getAllResults,
            int skip = 0,
            int take = 50,
            string partitionKey = null);

        IOrderedQueryable<T> GetAllItemsAsQueryable(QueryRequestOptions requestOptions = null);

        Task<IList<T>> GetAllItemsAsync();

        Task<T> CreateItemAsync(T instance);

        Task<T> ReplaceItemAsync(T instance, bool ifMatchEtag = false);

        Task<T> UpdateItemAsync(Func<T, T> updateItem, string id, string partitionKey = null);

        Task<T> UpsertItemAsync(T item);

        Task DeleteItemAsync(T instance);

        Task DeleteItemAsync(string id, string partitionKey = null);

        Task DeleteItemAsync(string id, PartitionKey partitionKey);

        Task<ContainerProperties> GetContainerPropertiesAsync();
    }
}
