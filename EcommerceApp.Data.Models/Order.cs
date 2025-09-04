using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EcommerceApp.Common.EntityValidationConstants.Order;

namespace EcommerceApp.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Date and time when the order was placed.")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Comment("Identifier of the user who placed the order.")]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("The total amount for the order.")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(OrderAddressMaxLength)]
        [Comment("Shipping address for the order.")]
        public string ShippingAddress { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [Comment("Current status of the order")]
        public string Status { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
