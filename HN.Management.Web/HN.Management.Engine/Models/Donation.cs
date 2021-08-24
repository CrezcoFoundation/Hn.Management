using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Donation")]
    public class Donation
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "Varchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column("Description", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Column("MoneyAmount", TypeName = "int")]
        [MaxLength(11)]
        public int MoneyAmount { get; set; }

        [Column("Date", TypeName = "Varchar")]
        [MaxLength(50)]
        public DateTime? Date { get; set; }

        [Required]
        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        [ForeignKey("DonorId")]
        public int? DonorId { get; set; }
        public Donor Donor { get; set; }
    }
}
