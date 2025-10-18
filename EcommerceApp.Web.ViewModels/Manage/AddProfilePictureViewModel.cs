using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Web.ViewModels.Manage
{
    public class AddProfilePictureViewModel
    {
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; } = null!;
    }
}
