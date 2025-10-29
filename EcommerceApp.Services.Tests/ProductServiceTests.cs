using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Category;
using EcommerceApp.Web.ViewModels.Product;
using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;

namespace EcommerceApp.Services.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IRepository> repositoryMock;
        private readonly Mock<ICategoryService> categoryServiceMock;
        private readonly Mock<IHtmlSanitizer> sanitizerMock;
        private readonly Mock<IFileService> fileServiceMock;
        private readonly Mock<UserManager<ApplicationUser>> userManagerMock;

        private readonly ProductService service;

        public ProductServiceTests()
        {
            repositoryMock = new Mock<IRepository>();
            categoryServiceMock = new Mock<ICategoryService>();
            sanitizerMock = new Mock<IHtmlSanitizer>();
            fileServiceMock = new Mock<IFileService>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null
            );

            fileServiceMock.Setup(f => f.SanitizeFolderName(It.IsAny<string>())).Returns((string n) => n);

            service = new ProductService(
                repositoryMock.Object,
                categoryServiceMock.Object,
                sanitizerMock.Object,
                fileServiceMock.Object,
                userManagerMock.Object
            );
        }

        [Test]
        public async Task AddProductAsync_Should_Add_Product_Successfully()
        {
            var category = new CategoryViewModel 
            { 
                Id = 1, 
                Name = "Electronics" 
            };

            categoryServiceMock
                .Setup(c => c.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(category);

            var imageMock = new Mock<IFormFile>();

            imageMock
                .Setup(f => f.FileName)
                .Returns("test.jpg");

            imageMock
                .Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var model = new AddProductViewModel
            {
                Name = "Laptop",
                Description = "Good laptop",
                CategoryId = 1,
                Price = 1000
            };

            repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            repositoryMock
                .Setup(r => r.SaveChangesAsync())
                .Returns(Task.FromResult(0));

            await service.AddProductAsync(model, new List<IFormFile> { imageMock.Object });

            repositoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.AtLeastOnce);
        }

        [Test]
        public async Task GetProductForEditAsync_Should_Return_Product()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Phone",
                Description = "Smartphone",
                Price = 500,
                Images = new List<Image> 
                { 
                    new Image 
                    {
                        Url = "/img/1.jpg" 
                    } 
                }
            };

            var data = new List<Product> { product }
                .AsQueryable()
                .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Product>())
                .Returns(data);

            var result = await service.GetProductForEditAsync(1);

            Assert.NotNull(result);
            Assert.AreEqual("Phone", result.Name);
        }

        [Test]
        public async Task UpdateProductAsync_Should_Return_True_When_Successful()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Old Name",
                Description = "Old Desc",
                CategoryId = 1,
                Images = new List<Image>()
            };

            repositoryMock
                .Setup(r => r.GetByIdAsync<Product>(1))
                .ReturnsAsync(product);

            repositoryMock
                .Setup(r => r.SaveChangesAsync())
                .Returns(Task.FromResult(0));

            var category = new CategoryViewModel 
            { 
                Id = 1, 
                Name = "Electronics" 
            };

            categoryServiceMock
                .Setup(c => c.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(category);

            var imageMock = new Mock<IFormFile>();

            imageMock
                .Setup(f => f.FileName)
                .Returns("test.jpg");

            imageMock
                .Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var model = new EditProductViewModel
            {
                Id = 1,
                Name = "Updated Name",
                Description = "Updated Desc",
                Price = 1200
            };

            var result = await service
                .UpdateProductAsync(model, new List<IFormFile> { imageMock.Object });

            Assert.True(result);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.AtLeastOnce);
        }

        [Test]
        public async Task GetProductByIdAsync_Should_Return_Correct_Product()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Phone",
                Description = "Smartphone",
                Price = 500,
                Images = new List<Image> 
                { 
                    new Image 
                    { 
                        Url = "/img/1.jpg" 
                    } 
                }
            };

            var data = new List<Product> { product }
                .AsQueryable()
                .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Product>())
                .Returns(data);

            var result = await service.GetProductByIdAsync(1);

            Assert.NotNull(result);
            Assert.AreEqual("Phone", result.Name);
        }

        [Test]
        public async Task DeleteProductAsync_Should_Delete_Product_Successfully()
        {
            var product = new Product
            {
                Id = 1,
                CategoryId = 1,
                Images = new List<Image> 
                { 
                    new Image 
                    { 
                        Url = "test.jpg" 
                    } 
                },
                Reviews = new List<Review>()
            };

            var category = new CategoryViewModel 
            { 
                Id = 1,
                Name = "Electronics" 
            };

            categoryServiceMock
                .Setup(c => c.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(category);

            var data = new List<Product> { product }
                .AsQueryable()
                .BuildMock();

            repositoryMock
                .Setup(r => r.All<Product>())
                .Returns(data);

            repositoryMock
                .Setup(r => r.SaveChangesAsync())
                .Returns(Task.FromResult(0));

            await service.DeleteProductAsync(1);

            repositoryMock.Verify(r => r.Delete(It.IsAny<Product>()), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.AtLeastOnce);
        }

        [Test]
        public async Task GetProductCountByCategoryAsync_Should_Return_Results()
        {
            var category = new Category 
            { 
                Name = "Electronics" 
            };

            var productsList = new List<Product>
            {
                new Product 
                { 
                    Id = 1, 
                    Category = category 
                },
                new Product 
                { 
                    Id = 2, 
                    Category = category 
                }
            };

            var products = productsList
                .AsQueryable()
                .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Product>())
                .Returns(products);

            var result = await service.GetProductCountByCategoryAsync();

            Assert.AreEqual("Electronics", result.First().CategoryName);
            Assert.AreEqual(2, result.First().ProductCount);
        }

        [Test]
        public async Task GetLowStockProducts_Should_Return_Products()
        {
            var productsList = new List<Product>
            {
                new Product 
                { 
                    Name = "Phone", 
                    StockQuantity = 3 
                },
                new Product 
                { 
                    Name = "TV", 
                    StockQuantity = 2 
                }
            };

            var products = productsList
                .AsQueryable()
                .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Product>())
                .Returns(products);

            var result = await service.GetLowStockProducts();

            Assert.AreEqual(2, result.Count());
        }
    }
}