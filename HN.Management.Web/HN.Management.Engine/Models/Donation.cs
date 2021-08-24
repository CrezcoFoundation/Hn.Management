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

        [Required]
        [Column("Name", TypeName = "Varchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Column("Description", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column("MoneyAmount", TypeName = "int")]
        [MaxLength(11)]
        public int MoneyAmount { get; set; }

        [Required]
        [Column("Date", TypeName = "Varchar")]
        [MaxLength(50)]
        public DateTime? Date { get; set; }

        [Required]
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Projects { get; set; }

        [Required]
        [ForeignKey("DonorId")]
        public int DonorId { get; set; }
        public Donor Donors { get; set; }
    }
}
