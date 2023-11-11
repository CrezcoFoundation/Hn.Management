using Newtonsoft.Json;

namespace HN.Management.Engine.CosmosDb.Interfaces
{
    public interface IBaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
 
        /// <summary>
        /// Partition Key - All children must implement this.
        /// </summary>
        public string PartitionKey { get; set; }

        [JsonProperty("_etag")]
        public string Etag { get; set; }
    }
}
