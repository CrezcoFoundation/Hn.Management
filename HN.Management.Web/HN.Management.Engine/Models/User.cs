using HN.Management.Engine.CosmosDb;
using HN.Management.Engine.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HN.ManagementEngine.Models
{
    public class User : CosmosEntity
    {
        public const string UserSchema = "User";

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = UserSchema;

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; } = "1.0";

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        public string Email { get; set; }

        [JsonProperty("isEmailConfirmed")]
        public bool IsEmailConfirmed { get; set; }

        [JsonProperty("passwordHash")]
        [Required(ErrorMessage = "PasswordHash is required")]
        [MaxLength(40, ErrorMessage = "PasswordHash can't be longer than 40 characters")]
        public string PasswordHash { get; set; }

        [JsonProperty("role")]
        [Required(ErrorMessage = "RoleName is requiered")]
        [MaxLength(40, ErrorMessage = "RoleName can't be longer than 40 characters")]
        public Role Role { get; set; }
    }
}
