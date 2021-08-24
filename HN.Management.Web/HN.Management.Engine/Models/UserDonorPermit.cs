
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("UserDonorPermit")]
    public class UserDonorPermit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Permit", TypeName = "Varchar")]
        [MaxLength(50)]
        public bool Permit { get; set; }

        [Required]
        [ForeignKey("DonorId")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
