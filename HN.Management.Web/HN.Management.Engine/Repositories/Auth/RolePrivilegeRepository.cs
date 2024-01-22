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
    public class RolePrivilegeRepository : IRolePrivilegeRepository
    {
        internal const string UserPartition = "RolePrivilege";
        private readonly IDataManager<RolePrivilege> dataManager;
         
        public RolePrivilegeRepository(IDataManager<RolePrivilege> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IQueryable<RolePrivilege> GetAllQueryable()
        {
            return this.dataManager.GetAllAccessibleItemsAsQueryable();
        }

        public IEnumerable<RolePrivilege> GetAll()
        {
            var filter = this.GetAllQueryable();

            Expression<Func<RolePrivilege, bool>> matchPartitionKey = x => x.PartitionKey ==
            UserPartition;
            filter = filter.Where(matchPartitionKey);

            return filter.AsEnumerable();
        }

        public async Task<IEnumerable<RolePrivilege>> GetAllAsync()
        {
            return await this.dataManager.GetAllAccessibleItemsAsync();
        }

        public async Task<RolePrivilege> GetAsync(string id)
        {
            return await this.dataManager.GetItemByIdAsync(id, UserPartition);
        }

        public async Task<RolePrivilege> InsertAsync(RolePrivilege item)
        {
            if (item == null)
            {
                throw new ArgumentException("One or more of the required properities its missing or has null value");
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString("D");
            }

            return await this.dataManager.CreateItemAsync(item);
        }

        public async Task<RolePrivilege> UpdateAsync(RolePrivilege item)
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
