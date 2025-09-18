using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Category;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;
        private readonly IFileService fileService;
        private readonly IWebHostEnvironment webHostEnviroment;

        public CategoryService(IRepository repository, IFileService fileService, IWebHostEnvironment webHostEnviroment)
        {
            this.repository = repository;
            this.fileService = fileService;
            this.webHostEnviroment = webHostEnviroment;
        }

        public async Task AddAsync(AddCategoryViewModel model, string webRootPath)
        {
            string sanitizedFolderName = fileService.SanitizeFolderName(model.Name);
            string categoryFolderPath = Path.Combine(webRootPath, "images", sanitizedFolderName);

            try
            {
                if (!Directory.Exists(categoryFolderPath))
                {
                    Directory.CreateDirectory(categoryFolderPath);
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to create a folder: {categoryFolderPath}", ex);
            }

            var category = new Category()
            {
                Name = model.Name
            };

            await repository.AddAsync(category);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await repository.AllReadonly<Category>().AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var categories = await repository
                .AllReadonly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryViewModel?> GetByIdAsync(int id)
        {
            var category = await repository
                .AllReadonly<Category>()
                .Where(c => c.Id == id)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task<EditCategoryViewModel?> GetCategoryForEditAsync(int id)
        {
            var categoryForEdit = await repository
                .AllReadonly<Category>()
                .Where(c => c.Id == id)
                .Select(c => new EditCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

            return categoryForEdit;
        }

        public async Task<string?> GetCategoryNameByIdAsync(int id)
        {
            var categoryNameId = await repository
                .AllReadonly<Category>()
                .Where(c => c.Id == id)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            return categoryNameId;
        }

        public async Task UpdateAsync(int id, EditCategoryViewModel model, string webRootPath)
        {
            var category = await repository.GetByIdAsync<Category>(id);

            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category not found.");
            }

            string oldCategoryName = fileService.SanitizeFolderName(category.Name);
            string newCategoryName = fileService.SanitizeFolderName(model.Name);

            if (oldCategoryName != newCategoryName)
            {
                string oldFolderPath = Path.Combine(webRootPath, "images", oldCategoryName);
                string newFolderPath = Path.Combine(webRootPath, "images", newCategoryName);

                try
                {
                    if (Directory.Exists(oldFolderPath))
                    {
                        if (Directory.Exists(newFolderPath))
                        {
                            throw new IOException($"The target folder '{newFolderPath}' already exists. Renaming is impossible.");
                        }

                        Directory.Move(oldFolderPath, newFolderPath);
                    }
                }
                catch (Exception ex)
                {
                    throw new IOException($"Failed to rename/create folder from '{oldFolderPath}' to '{newFolderPath}'", ex);
                }
            }

            category.Name = newCategoryName;

            await repository.SaveChangesAsync();
        }
    }
}
