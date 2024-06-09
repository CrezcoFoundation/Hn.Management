﻿using HN.Management.Engine.CosmosDb.Base;
using HN.Management.Engine.CosmosDb.Interfaces;
using HN.Management.Engine.Models.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HN.Management.Engine.CosmosDb.Accessors
{
    public class PrivilegeDataAccessor : BaseDataAccessor<Privilege>
    {
        public PrivilegeDataAccessor(ICosmosDbClient<Privilege> cosmosDbClient)
            : base(cosmosDbClient)
        { 
        }
         
        public override IQueryable<Privilege> GetAllAccessibleItemsAsQueryable()
        {
            return this.GetAllItems();
        }

        public override Task<IList<Privilege>> GetAllAccessibleItemsAsync()
        {
            return this.GetAllItemsAsync();
        }

        protected override IQueryable<Privilege> FilterAccessibleItems(IQueryable<Privilege> query)
        {
            return query;
        }

        protected override bool IsItemAccessible(Privilege item)
        {
            if (item == null)
            {
                // TODO pass the loggeer instead console writeline
                Console.WriteLine($"Privilege object its inaccessible, MessageId: {item.Id}");
                return false;
            }

            return true;
        }
    }
}
