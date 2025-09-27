using EcommerceApp.Web.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<ProductPageViewModel> GetAllProductsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize, int? categoryId = null);
        Task AddProductAsync(AddProductViewModel model, List<IFormFile> images);
        Task<EditProductViewModel?> GetProductForEditAsync(int productId);
        Task<bool> UpdateProductAsync(EditProductViewModel model, List<IFormFile> newImages);
        Task<DeleteProductViewModel?> GetProductForDeleteAsync(int productId);
        Task DeleteProductAsync(int productId);
        Task<ProductIndexViewModel?> GetProductByIdAsync(int productId);
        Task<ProductPageViewModel> GetPopularProductsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize, int? categoryId = null);
        Task<ProductPageViewModel> GetNewArrivalsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize, int? categoryId = null);    
        Task DeleteImageAsync(int productId, string imageUrl);
    }
}
