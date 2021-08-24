using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "Varchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("Description", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column("LocalMoneyAmount", TypeName = "int")]
        [MaxLength(11)]
        public int LocalMoneyAmount { get; set; }

        [Required]
        [Column("ConversionToDollar", TypeName = "int")]
        [MaxLength(11)]
        public int ConversionToDollar { get; set; }

        [Required]
        [Column("DollarMoneyAmount", TypeName = "int")]
        [MaxLength(11)]
        public int DollarMoneyAmount { get; set; }

        [Required]
        [Column("Date", TypeName = "Varchar")]
        [MaxLength(50)]
        public DateTime? Date { get; set; }

        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("StudentId")]
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
