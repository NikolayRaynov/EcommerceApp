using EcommerceApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.SeedCategories());
        }

        private List<Category> SeedCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Laptops" },
                new Category { Id = 2, Name = "Monitors" },
                new Category { Id = 3, Name = "Keyboards" },
                new Category { Id = 7, Name = "Games" },
            };
            return categories;
        }
    }
}
