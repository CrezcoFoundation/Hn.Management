using HN.ManagementEngine.Models;
using System;

namespace HN.ManagementEngine.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocalMoneyAmount { get; set; }
        public int ConversionToDollar { get; set; }
        public int DollarMoneyAmount { get; set; }
        public DateTime? Date { get; set; }
        public int ProjectId { get; set; }
        public int StudentId { get; set; }
    }
}
