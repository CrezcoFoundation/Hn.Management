
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Email", TypeName = "Varchar")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Column("FirstName", TypeName = "Varchar")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName", TypeName = "Varchar")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("Password", TypeName = "Varchar")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("Image", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Image { get; set; }
    }
}
