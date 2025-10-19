using EcommerceApp.Data.Models;
using EcommerceApp.Web.ViewModels.Manage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.ViewComponents
{
    [ViewComponent(Name = "UserNavigation")]
    public class UserNavigationViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserNavigationViewComponent(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(null);
            }

            string userId = userManager.GetUserId(UserClaimsPrincipal);
            var user = await userManager.FindByIdAsync(userId);

            var model = new ProfilePictureViewModel
            {
                ProfilePictureUrl = user?.ProfilePictureUrl ?? DefaultProfilePicturePath
            };

            return View(model);
        }
    }
}
