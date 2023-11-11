using HN.Management.Engine.CosmosDb;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HN.ManagementEngine.Models
{
    public class Donor : CosmosEntity
    {
        public const string DonorSchema = "Donor";

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = DonorSchema;

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; } = "1.0";

        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string ImageLocation { get; set; }
    }
}
