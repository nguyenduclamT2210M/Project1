using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Project1.Models
{
    public class GoodModel
    {
        [Key]
        public int IdGoods { get; set; }

        public int IdBill { get; set; }
        [ForeignKey("IdBill")]
        public BillModel Bill { get; set; }
        public int IdServiceType { get; set; }
        [ForeignKey("IdServiceType")]
        public SericeTypeModel ServiceType { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
