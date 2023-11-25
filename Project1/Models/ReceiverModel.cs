using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class ReceiverModel
    {
        [Key]
        public int IdReceiver { get; set; } 
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}
  