
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Proyect")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(40, ErrorMessage = "Name can't be longer than 40 characters")]
        [Column("Name", TypeName = "Varchar")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        [Column("Description", TypeName = "Varchar")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50, ErrorMessage = "Country can't be longer than 50 characters")]
        [Column("Country", TypeName = "Varchar")]
        public string Country { get; set; }

        [Required(ErrorMessage = "CountryFlag is required")]
        [MaxLength(500, ErrorMessage = "CountryFlag can't be longer than 500 characters")]
        [Column("CountryFlag", TypeName = "Varchar")]
        public string CountryFlag { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(500, ErrorMessage = "Image can't be longer than 500 characters")]
        [Column("Image", TypeName = "Varchar")]
        public string Image { get; set; }
    }
}
