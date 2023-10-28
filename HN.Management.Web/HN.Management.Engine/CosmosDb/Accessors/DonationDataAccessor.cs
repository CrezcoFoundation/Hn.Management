using HN.Management.Engine.CosmosDb.Base;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.ManagementEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HN.Management.Engine.CosmosDb.Accessors
{
    public class DonationDataAccessor : BaseDataAccessor<Donation>
    {
        public DonationDataAccessor(ICosmosDbClient<Donation> cosmosDbClient)
            : base(cosmosDbClient)
        {
        }

        public override IQueryable<Donation> GetAllAccessibleItemsAsQueryable()
        {
            return this.GetAllItems();
        }

        public override Task<IList<Donation>> GetAllAccessibleItemsAsync()
        {
            return this.GetAllItemsAsync();
        }

        protected override IQueryable<Donation> FilterAccessibleItems(IQueryable<Donation> query)
        {
            return query;
        }

        protected override bool IsItemAccessible(Donation item)
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
