using AutoMapper.Configuration.Annotations;
using HN.Management.Engine.CosmosDb.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HN.Management.Engine.CosmosDb
{
    public abstract class CosmosEntity: IBaseEntity, IAuditable
    {
        [JsonProperty("id")]
        [Ignore]
        public virtual string Id { get; set; }

        [Ignore]
        public virtual string PartitionKey { get; set; }

        [JsonProperty("_etag")]
        [Ignore]
        public string Etag { get; set; }

        [JsonProperty("_ts")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [Ignore]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [Ignore]
        public virtual string CreatedById { get; set; }

        [Ignore]
        public virtual string CreatedByName { get; set; }

        [Ignore]
        public virtual DateTimeOffset CreatedAt { get; set; }

        [Ignore]
        public virtual string LastUpdatedById { get; set; }

        [Ignore]
        public virtual string LastUpdatedByName { get; set; }

        [Ignore]
        public virtual DateTimeOffset LastUpdatedAt { get; set; }
    }
}
