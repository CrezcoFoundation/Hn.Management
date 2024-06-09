using HN.Management.Engine.CosmosDb.Base;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HN.Management.Engine.CosmosDb.Accessors
{
    public class RolePrivilegeDataAccessor : BaseDataAccessor<RolePrivilege>
    {
        public RolePrivilegeDataAccessor(ICosmosDbClient<RolePrivilege> cosmosDbClient)
            : base(cosmosDbClient)
        { 
        }
         
        public override IQueryable<RolePrivilege> GetAllAccessibleItemsAsQueryable()
        {
            return this.GetAllItems();
        }

        public override Task<IList<RolePrivilege>> GetAllAccessibleItemsAsync()
        {
            return this.GetAllItemsAsync();
        }

        protected override IQueryable<RolePrivilege> FilterAccessibleItems(IQueryable<RolePrivilege> query)
        {
            return query;
        }

        protected override bool IsItemAccessible(RolePrivilege item)
        {
            if (item == null)
            {
                // TODO pass the loggeer instead console writeline
                Console.WriteLine($"RolePrivilege object its inaccessible, MessageId: {item.Id}");
                return false;
            }

            return true;
        }
    }
}
