using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class BillModel
    {
        [Key] 
        public int IdBill { get; set; }
        public int IdGoods { get; set; }
        [ForeignKey("IdGoods")]
        public GoodModel Good { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public UserModel User { get; set; }
        public int IdReceiver { get; set; }
        [ForeignKey("IdReceiver")]
        public ReceiverModel Receiver { get; set; }
        public int IdGoodsProperties { get; set; }
        [ForeignKey("IdGoodsProperties")]
        public GoodsPropertiesModel Properties { get; set; }
        public int Payment { get; set; }
        public string GoodsCondition { get; set; }
        public decimal Price { get; set; }
    }
}
