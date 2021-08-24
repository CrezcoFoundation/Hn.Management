using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Evidence")]
    public class Evidence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Image", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Image { get; set; }

        [Required]
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project Projects { get; set; }

        [Required]
        [ForeignKey("ActivityId")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
