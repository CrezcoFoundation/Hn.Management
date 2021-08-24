
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Proyect")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "Varchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column("Description", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Column("Country", TypeName = "Varchar")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Column("CountryFlag", TypeName = "Varchar")]
        [MaxLength(500)]
        public string CountryFlag { get; set; }

        [Column("Image", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Image { get; set; }
    }
}
