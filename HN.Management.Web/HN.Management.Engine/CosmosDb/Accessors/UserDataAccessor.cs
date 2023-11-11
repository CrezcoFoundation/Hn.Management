using HN.Management.Engine.CosmosDb.Base;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.ManagementEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HN.Management.Engine.CosmosDb.Accessors
{
    public class UserDataAccessor : BaseDataAccessor<User>
    {
        public UserDataAccessor(ICosmosDbClient<User> cosmosDbClient)
            : base(cosmosDbClient)
        { 
        }

        public override IQueryable<User> GetAllAccessibleItemsAsQueryable()
        {
            return this.GetAllItems();
        }

        public override Task<IList<User>> GetAllAccessibleItemsAsync()
        {
            return this.GetAllItemsAsync();
        }

        protected override IQueryable<User> FilterAccessibleItems(IQueryable<User> query)
        {
            return query;
        }

        protected override bool IsItemAccessible(User item)
        {
            if (item == null)
            {
                // TODO pass the loggeer instead console writeline
                Console.WriteLine($"Donation object its inaccessible, MessageId: {item.Id}");
                return false;
            }

            return true;
        }
    }
}
