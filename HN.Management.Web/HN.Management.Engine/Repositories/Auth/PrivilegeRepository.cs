using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using HN.Management.Engine.Repositories.Interfaces;

namespace HN.Management.Engine.Repositories.Auth
{
    public class PrivilegeRepository : IPrivilegeRepository
    {
        internal const string UserPartition = "Privilege";
        private readonly IDataManager<Privilege> dataManager;

        public PrivilegeRepository(IDataManager<Privilege> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IQueryable<Privilege> GetAllQueryable()
        {
            return this.dataManager.GetAllAccessibleItemsAsQueryable();
        }

        public IEnumerable<Privilege> GetAll()
        {
            var filter = this.GetAllQueryable();

            Expression<Func<Privilege, bool>> matchPartitionKey = x => x.PartitionKey ==
            UserPartition;
            filter = filter.Where(matchPartitionKey);

            return filter.AsEnumerable();
        }

        public Privilege GetPrivilegeByName(string privilegeName)
        {
            var privileges = this.dataManager
                .GetAllItemsByExpression(privileges => privileges
                .Where(x => x.Name == privilegeName && x.PartitionKey == UserPartition))
                .ToList();

            return privileges.FirstOrDefault();
        }

        public async Task<IEnumerable<Privilege>> GetAllAsync()
        {
            return await this.dataManager.GetAllAccessibleItemsAsync();
        }

        public async Task<Privilege> GetAsync(string id)
        {
            return await this.dataManager.GetItemByIdAsync(id, UserPartition);
        }

        public async Task<Privilege> InsertAsync(Privilege item)
        {
            if (item == null)
            {
                throw new ArgumentException("One or more of the required properties its missing or has null value");
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString("D");
            }

            return await this.dataManager.CreateItemAsync(item);
        }

        public async Task<Privilege> UpdateAsync(Privilege item)
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

        public List<Privilege> GetPrivilegesByIds(List<string> ids)
        {
            var privileges = this.dataManager
               .GetAllItemsByExpression(privileges => privileges
               .Where(x => ids.Contains(x.Id) && x.PartitionKey == UserPartition))
               .ToList();

            return privileges;
        }
    }
}
