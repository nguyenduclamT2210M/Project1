using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class SericeTypeModel
    {
        [Key]
        public int IdServiceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
