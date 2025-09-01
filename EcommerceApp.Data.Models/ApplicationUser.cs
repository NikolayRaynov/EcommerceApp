using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Cart Cart { get; set; } = null!;
    }
}
