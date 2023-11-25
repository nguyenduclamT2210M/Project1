using Project1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Entities
{
    [Table("Bills")]
    public class Bills
    {
        [Key]
        public int IdBill { get; set; }
        public int IdGoods { get; set; }
        [ForeignKey("IdGoods")]
        public Goods Good { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public int IdReceiver { get; set; }
        [ForeignKey("IdReceiver")]
        public Receivers Receiver { get; set; }
        public int IdGoodsProperties { get; set; }
        [ForeignKey("IdGoodsProperties")]
        public GoodsProperties Properties { get; set; }
        public int Payment { get; set; }
        public string GoodsCondition { get; set; }
        public decimal Price { get; set; }
    }
}
