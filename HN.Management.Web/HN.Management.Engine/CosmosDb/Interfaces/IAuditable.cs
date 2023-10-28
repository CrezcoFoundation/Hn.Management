using System;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
    public interface IAuditable
    {
        public string CreatedById { get; set; }

        public string CreatedByName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string LastUpdatedById { get; set; }

        public string LastUpdatedByName { get; set; }

        public DateTimeOffset LastUpdatedAt { get; set; }
    }
}
