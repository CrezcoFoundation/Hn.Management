
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("UserProjectPermit")]
    public class UserProjectPermit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Permit", TypeName = "Varchar")]
        [MaxLength(50)]
        public bool Permit { get; set; }

        [Required]
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
