using HN.Management.Engine.CosmosDb;
using HN.Management.Engine.Models;
using Newtonsoft.Json;

namespace HN.ManagementEngine.Models
{
    public class User : CosmosEntity
    {
        public const string UserSchema = "User";
        public override string PartitionKey { get; set; } = UserSchema;

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = UserSchema;

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; } = "1.0";

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("isEmailConfirmed")]
        public bool IsEmailConfirmed { get; set; }

        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }
}
