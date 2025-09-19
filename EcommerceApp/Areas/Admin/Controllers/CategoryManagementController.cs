using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class CategoryManagementController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoryManagementController(ICategoryService categoryService, IWebHostEnvironment iWebHostEnvironment)
        {
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync();
            var viewModel = categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string webRootPath = webHostEnvironment.WebRootPath;
                await categoryService.AddAsync(model, webRootPath);

                return RedirectToAction(nameof(Index), "CategoryManagement", new {area = AdminRoleName});
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                bool exists = await categoryService.ExistsByIdAsync(id);
                if (!exists)
                {
                    return RedirectToAction(nameof(Index), "CategoryManagement", new { area = AdminRoleName });
                }

                EditCategoryViewModel? viewModel = await categoryService.GetCategoryForEditAsync(id);
                if (viewModel == null)
                {
                    return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
                }

                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 500 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return RedirectToAction("Error" ,"Home", new {area = "", statusCode = 400});
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                string webRootPath = webHostEnvironment.WebRootPath;
                await categoryService.UpdateAsync(id, viewModel, webRootPath);

                return RedirectToAction(nameof(Index), "CategoryManagement", new { area = AdminRoleName });
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Error", "Home", new { area = "", statusCode = 404 });
            }
            catch (IOException)
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
