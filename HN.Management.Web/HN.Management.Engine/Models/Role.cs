using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.Management.Engine.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "RoleName is required")]
        [MaxLength(40, ErrorMessage = "RoleName can't be longer than 40 characters")]
        [Column("RoleName", TypeName = "Varchar")]
        public string RoleName { get; set; }
    }
}
