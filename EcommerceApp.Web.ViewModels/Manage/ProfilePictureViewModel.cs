using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Web.ViewModels.Manage
{
    public class ProfilePictureViewModel
    {
        public string ProfilePictureUrl { get; set; } = null!;
        public long ProfilePictureVersion { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Profile Picture")]
        public IFormFile? ProfileImage { get; set; }
    }
}