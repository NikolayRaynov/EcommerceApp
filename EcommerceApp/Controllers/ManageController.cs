using EcommerceApp.Data.Models;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Manage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Controllers
{
    public class ManageController : Controller
    {
        private readonly IFileService fileService;
        private readonly UserManager<ApplicationUser> userManager;

        public ManageController(IFileService fileService, UserManager<ApplicationUser> userManager)
        {
            this.fileService = fileService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }

            var model = new AddProfilePictureViewModel();

            ViewData["CurrentProfilePictureUrl"] = user.ProfilePictureUrl ?? DefaultProfilePicturePath;

            return View(model);
        }

        [HttpGet]
        public IActionResult UploadProfilePicture()
        {
            return View(new AddProfilePictureViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(AddProfilePictureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }

            try
            {
                string imageUrl = await this.fileService.SaveProfilePictureAsync(model.ProfileImage, userId);

                user.ProfilePictureUrl = imageUrl;
                await this.userManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }
    }
}
