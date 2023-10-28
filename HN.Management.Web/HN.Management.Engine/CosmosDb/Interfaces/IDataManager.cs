using System;
using System.Threading.Tasks;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
    public interface IDataManager<T> : IDataReader<T> where T : IBaseEntity
    {
        public Task DeleteItemAsync(string id, string partitionKey = null);

        public Task DeleteItemAsync(T item);

        public Task<T> UpdateItemAsync(T item);

        public Task<T> UpdateItemAsync(Func<T, T> updateItem, string id, string partitionKey = null);

        public Task<T> CreateItemAsync(T item);

        public Task<T> UpsertItemAsync(T item);
    }
}
