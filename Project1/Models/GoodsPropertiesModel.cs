using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class GoodsPropertiesModel
    {
        [Key]
        public int IdGoodsProperties { get; set; }
        [Required]
        public string Nature { get; set; }
    }
}
