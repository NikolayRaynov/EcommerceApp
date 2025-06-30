using EcommerceApp.Data.Repository;
using EcommerceApp.Data.Repository.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EcommerceAppServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

			return services;
        }
    }
}
