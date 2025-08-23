using EcommerceApp.Data.Repository;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using EcommerceApp.Services.Data.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EcommerceAppServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();

			return services;
        }
    }
}
