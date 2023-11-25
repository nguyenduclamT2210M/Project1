using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Entities
{
    [Table("Receivers")]
    public class Receivers
    {
        [Key]
        public int IdReceiver { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}
