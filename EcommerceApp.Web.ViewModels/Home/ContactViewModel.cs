using System.ComponentModel.DataAnnotations;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Web.ViewModels.Home
{
    public class ContactViewModel
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(MaxEmailLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxMessageLength)]
        public string Message { get; set; } = string.Empty;
    }
}
