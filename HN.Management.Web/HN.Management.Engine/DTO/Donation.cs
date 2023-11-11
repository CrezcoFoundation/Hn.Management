using System;

namespace HN.ManagementEngine.DTO
{
    public class Donation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MoneyAmount { get; set; }
        public DateTime? Date { get; set; }
        public int ProjectId { get; set; }
        public int DonorId { get; set; }
    }
}
