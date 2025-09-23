using EcommerceApp.Web.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using static EcommerceApp.Common.ApplicationConstants;

namespace EcommerceApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<ProductPageViewModel> GetAllProductsAsync(int pageNumber = DefaultPageNumber, 
            int pageSize = DefaultPageSize, string? searchTerm = null);
        Task<int> AddProductAsync(AddProductViewModel model, List<IFormFile> images);
        Task<EditProductViewModel?> GetProductForEditAsync(int productId);
        Task<bool> UpdateProductAsync(EditProductViewModel model, List<IFormFile> newImages);
        Task<DeleteProductViewModel?> GetProductForDeleteAsync(int productId);
        Task<bool> DeleteProductAsync(int productId);
        Task<int> GetProductCountAsync(string? searchTerm = null);
        Task<ProductIndexViewModel?> GetProductByIdAsync(int productId);
        Task<ProductPageViewModel> GetPopularProductsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize);
        Task<ProductPageViewModel> GetNewArrivalsAsync(int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize);    
        Task DeleteImageAsync(int destinationId, string imageUrl);
    }
}
