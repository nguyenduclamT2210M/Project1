using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Entities
{
    [Table("SericeTypes")]
    public class SericeTypes
    {
        [Key]
        public int IdServiceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
