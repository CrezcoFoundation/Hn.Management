using HN.ManagementEngine.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.Management.Engine.Models
{
    [Table("UserDetail")]
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(40, ErrorMessage = "FirstName can't be longer than 40 characters")]
        [Column("FirstName", TypeName = "Varchar")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(40, ErrorMessage = "LastName can't be longer than 40 characters")]
        [Column("LastName", TypeName = "Varchar")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(500, ErrorMessage = "Image can't be longer than 500 characters")]
        [Column("Image", TypeName = "Varchar")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Foreign key is required")]
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
