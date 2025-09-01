using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Data.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the user who owns the cart.")]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
