
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("UserProjectPermit")]
    public class UserPermit
    {
        [Key]
        public int Id { get; set; }

        [Column("DonorPermit", TypeName = "Varchar")]
        [MaxLength(50)]
        public bool DonorPermit { get; set; }

        [Column("ProjectPermit", TypeName = "Varchar")]
        [MaxLength(50)]
        public bool ProjectPermit { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("DonorId")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
