using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Models.Auth;
using HN.Management.Engine.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HN.Management.Engine.Repositories.Auth
{
    public class RoleRepository : IRoleRepository
    {
        internal const string UserPartition = "Role";
        private readonly IDataManager<Role> dataManager;

        public RoleRepository(IDataManager<Role> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IQueryable<Role> GetAllQueryable()
        {
            return this.dataManager.GetAllAccessibleItemsAsQueryable();
        }

        public IEnumerable<Role> GetAll()
        {
            var filter = this.GetAllQueryable();

            Expression<Func<Role, bool>> matchPartitionKey = x => x.PartitionKey ==
            UserPartition;
            filter = filter.Where(matchPartitionKey);

            return filter.AsEnumerable();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await this.dataManager.GetAllAccessibleItemsAsync();
        }

        public async Task<Role> GetAsync(string id)
        {
            return await this.dataManager.GetItemByIdAsync(id, UserPartition);
        }

        public async Task<Role> InsertAsync(Role item)
        {
            if (item == null)
            {
                throw new ArgumentException("One or more of the required properities its missing or has null value");
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString("D");
            }
            item.IsDeleted = true;

            return await this.dataManager.CreateItemAsync(item);
        }

        public async Task<Role> UpdateAsync(Role item)
        {
            item.LastUpdatedAt = DateTime.UtcNow;
            //TODO: we really need log the session name of the user (username, email, userId), for now I let "System", but this must change.
            item.LastUpdatedByName = "System";

            return await this.dataManager.UpsertItemAsync(item);
        }

        public async Task Delete(string id)
        {
            await this.dataManager.DeleteItemAsync(id, UserPartition);
        }
    }
}
