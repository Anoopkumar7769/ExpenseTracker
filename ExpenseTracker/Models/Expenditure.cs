using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Expenditure
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string ExpenditureName { get; set; }
        [DisplayName("Amount")]
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Amount Must be greater than 0!")]
        public int ExpenditureAmount { get; set; }

        [DisplayName("Expense Type")]
        public int ExpenditureTypeId { get; set; }
        [ForeignKey("ExpenditureTypeId")]
        public virtual ExpenditureType ExpenditureType { get; set; }

    }
}
