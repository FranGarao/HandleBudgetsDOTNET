using System.ComponentModel.DataAnnotations;

namespace HandleBudgets2.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int xd{ get; set; }
        public int Order { get; set; }
    }
}
