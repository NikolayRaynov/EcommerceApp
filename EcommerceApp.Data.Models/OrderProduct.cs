using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EcommerceApp.Common.EntityValidationConstants.Product;

namespace EcommerceApp.Data.Models
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the parent order to which this item belongs.")]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; } = null!;

        [Required]
        [Comment("Identifier of the product in the order item.")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        [Required]
        [Range(MinQuantity, MaxQuantity)]
        [Comment("Quantity of the product in the order item.")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("The price of the product at the time of ordering.")]
        public decimal PriceAtTimeOfPurchase { get; set; }
    }
}
