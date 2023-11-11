using HN.Management.Engine.CosmosDb;
using Newtonsoft.Json;
using System;

namespace HN.ManagementEngine.Models
{
    public class Donation : CosmosEntity
    {
        public const string DonationSchema = "Donation";

        public override string PartitionKey { get; set; } = DonationSchema;

        [JsonProperty("schemaName")]
        public string SchemaName { get; set; } = DonationSchema;

        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; } = "1.0";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("descripcion")]
        public string Description { get; set; }

        [JsonProperty("moneyAmount")]
        public int MoneyAmount { get; set; }

        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty("dateDonated")]
        public DateTimeOffset? DateDonated { get; set; }

        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        [JsonProperty("donorId")]
        public string DonorId { get; set; }
    }
}
