using Newtonsoft.Json;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
    public interface IBaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("partitionKey")]

        public string PartitionKey { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }
    }
}
