using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
    public interface IDataReader<T>
        where T : IBaseEntity
    {
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

        IQueryable<T> GetAllAccessibleItemsAsQueryable();

        Task<IList<T>> GetAllAccessibleItemsAsync();

        Task<T> GetItemByIdAsync(string id, string partitionKey = null);

        Task<bool> IsItemAccessibleAsync(string id, string partitionKey = null);

        Task<IList<T>> GetItemsBySqlExpressionAsync(
            string sqlExpression,
            IDictionary<string, string> parameters,
            bool getAllResults);
    }
}
