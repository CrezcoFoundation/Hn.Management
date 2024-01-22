using HN.Management.Engine.CosmosDb.Base;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HN.Management.Engine.CosmosDb.Accessors
{
    public class RoleDataAccessor : BaseDataAccessor<Role>
    {
        public RoleDataAccessor(ICosmosDbClient<Role> cosmosDbClient)
            : base(cosmosDbClient)
        {

        }

        public override IQueryable<Role> GetAllAccessibleItemsAsQueryable()
        {
            return this.GetAllItems();
        }

        public override Task<IList<Role>> GetAllAccessibleItemsAsync()
        {
            return this.GetAllItemsAsync();
        }

        protected override IQueryable<Role> FilterAccessibleItems(IQueryable<Role> query)
        {
            return query;
        }

        protected override bool IsItemAccessible(Role item)
        {
            if (item == null)
            {
                // TODO pass the loggeer instead console writeline
                Console.WriteLine($"Role object its inaccessible, MessageId: {item.Id}");
                return false;
            }

            return true;
        }
    }
}
