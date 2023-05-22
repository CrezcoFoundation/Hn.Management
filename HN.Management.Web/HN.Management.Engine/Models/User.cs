using HN.Management.Engine.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters")]
        [Column("Email", TypeName = "Varchar")]
        public string UserEmail { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required(ErrorMessage = "PasswordHash is required")]
        [MaxLength(40, ErrorMessage = "PasswordHash can't be longer than 40 characters")]
        [Column("PasswordHash", TypeName = "Varchar")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage ="RoleName is requiered")]
        [MaxLength(40, ErrorMessage = "RoleName can't be longer than 40 characters")]
        [Column("RoleName", TypeName = "Varchar")]
        public string RoleName { get; set; }

        [ForeignKey("RoleId")]
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
