using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePictureUrl { get; set; }
        public Cart Cart { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; } = new List<FavoriteProduct>();
    }
}
