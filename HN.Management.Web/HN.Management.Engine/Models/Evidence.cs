using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HN.ManagementEngine.Models
{
    [Table("Evidence")]
    public class Evidence
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(500, ErrorMessage = "Image can't be longer than 500 characters")]
        [Column("Image", TypeName = "Varchar")]
        public string Image { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [ForeignKey("ExpenseId")]
        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }
    }
}
