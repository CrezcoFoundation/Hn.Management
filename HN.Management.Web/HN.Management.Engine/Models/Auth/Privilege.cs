using HN.Management.Engine.CosmosDb;
using Newtonsoft.Json;

namespace HN.Management.Engine.Models.Auth
{
    public class Privilege : CosmosEntity
    {
        public const string UserSchema = "Privilege";
        public override string PartitionKey { get; set; } = UserSchema;

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = UserSchema;

        public string Name { get; set; }

        public bool IsDeleted { get; set; } 
    }
}
