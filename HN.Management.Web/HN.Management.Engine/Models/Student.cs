
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("Email", TypeName = "Varchar")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column("FirstName", TypeName = "Varchar")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("LastName", TypeName = "Varchar")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("Image", TypeName = "Varchar")]
        [MaxLength(500)]
        public string Image { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
