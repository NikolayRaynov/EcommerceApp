using EcommerceApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceApp.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(this.SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            var products = new List<Product>();

            for (int i = 1; i <= 15; i++)
            {
                var productName = $"Product Name {i}";
                var productDescription = $"This is the description for Product {i}. It's a high-quality product with excellent features.";
                var productPrice = 10.00m + (i * 2.5m);

                var imageGuid = Guid.NewGuid().ToString();
                var productImagePath = $"/images/Products/{imageGuid}.png";

                products.Add(new Product
                {
                    Id = i,
                    Name = productName,
                    Description = productDescription,
                    Price = productPrice,
                    Image = productImagePath,
                    CreatedOn = DateTime.UtcNow.AddDays(-i)
                });
            }

            return products;
        }
    }
}