using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Entities
{
    [Table("GoodsProperties")]
    public class GoodsProperties
    {
        [Key]
        public int IdGoodsProperties { get; set; }
        public string Nature { get; set; }
    }
}
