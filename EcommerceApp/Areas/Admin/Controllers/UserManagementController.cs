using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Admin.UserManagement;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Areas.Admin.Controllers
{

    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserManagementController : Controller
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<AllUsersViewModel> allUsers = await this.userService
                .GetAllUsersAsync();

                return this.View(allUsers);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            bool assignResult = await this.userService
                .AssignUserToRoleAsync(userId, role);

            if (!assignResult)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            bool assignResult = await this.userService
                .RemoveUserRoleAsync(userId, role);

            if (!assignResult)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                await this.userService.DeleteUserAsync(userId);
                return this.RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }
    }
}
