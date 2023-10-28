using HN.Management.Engine.CosmosDb;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace HN.ManagementEngine.Models
{
    public class Donation : CosmosEntity
    {
        public const string DonationSchema = "Donation";

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = DonationSchema;

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; } = "1.0";

        [JsonProperty("name")]
        [MaxLength(20)]
        public string Name { get; set; }

        [JsonProperty("descripcion")]
        [MaxLength(500)]
        public string Description { get; set; }

        [JsonProperty("moneyAmount")]
        [MaxLength(11)]
        public int MoneyAmount { get; set; }

        [JsonProperty("isDeleted")]
        [MaxLength(50)]
        public bool? IsDeleted { get; set; }

        [JsonProperty("dateDonated")]
        [MaxLength(50)]
        public DateTimeOffset? DateDonated { get; set; }

        [JsonProperty("project")]
        public virtual Project Project { get; set; }

        [JsonProperty("donor")]
        public virtual Donor Donor { get; set; }
    }
}
