using HN.Management.Engine.CosmosDb;
using Newtonsoft.Json;

namespace HN.Management.Engine.Models.Auth
{
    public class Role : CosmosEntity
    {
        public const string UserSchema = "Role";
        public override string PartitionKey { get; set; } = UserSchema;

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = UserSchema;

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
