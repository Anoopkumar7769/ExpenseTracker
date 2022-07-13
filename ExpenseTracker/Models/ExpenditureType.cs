using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class ExpenditureType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
