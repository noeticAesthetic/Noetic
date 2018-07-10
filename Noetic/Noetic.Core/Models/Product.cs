using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Noetic.Core.Models
{
    public class Product : BaseEntity
    {
        [DisplayName("Product Name"), StringLength(50)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [Range(0, 10000)]
        public int Quantity { get; set; }
        [Range(0, 10000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
