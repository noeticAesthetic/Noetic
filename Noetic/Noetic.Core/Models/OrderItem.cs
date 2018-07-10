using System.ComponentModel.DataAnnotations;

namespace Noetic.Core.Models
{
    public class OrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        //[StringLength(50), MinLength(3)]
        //[MaxLength(50), MinLength(3)]
        [StringLength(50, MinimumLength =3)]
        public string ProductName { get; set; }
        [Range(0, 10000)]
        public decimal Price { get; set; }
        [Range(0, 10000)]
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
