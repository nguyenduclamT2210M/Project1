using Project1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Entities
{
    [Table("Goods")]
    public class Goods
    {
        [Key]
        public int IdGoods { get; set; }

        public int IdBill { get; set; }
        public Bills Bill { get; set; }
        public int IdServiceType { get; set; }
        [ForeignKey("IdServiceType")]
        public SericeTypes ServiceType { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }

}
