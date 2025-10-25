using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using MockQueryable;
using Moq;

namespace EcommerceApp.Services.Tests;

[TestFixture]
public class FavoriteProductServiceTests
{
    private Mock<IRepository> repositoryMock;
    private FavoriteProductService favoriteProductService;

    [SetUp]
    public void Setup()
    {
        this.repositoryMock = new Mock<IRepository>();
        this.favoriteProductService = new FavoriteProductService(this.repositoryMock.Object);
    }

    [Test]
    public async Task AddToFavoritesAsync_WhenProductAlreadyInFavorites_ShouldReturnFalse()
    {
        string userId = "userWithFavorite";
        int productId = 1;

        var existingProduct = new Product 
        { 
            Id = productId 
        };

        var existingFavoriteProduct = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { existingProduct }
        };

        var favoriteProductData = new List<FavoriteProduct> { existingFavoriteProduct }
            .AsQueryable()
            .BuildMock();

        this.repositoryMock
            .Setup(r => r.All<FavoriteProduct>())
            .Returns(favoriteProductData);

        bool result = await this.favoriteProductService
            .AddToFavoritesAsync(productId, userId);

        Assert.IsFalse(result);

        this.repositoryMock.Verify(r => r.AddAsync(It.IsAny<FavoriteProduct>()), Times.Never());
        this.repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never());
    }

    [Test]
    public async Task AddToFavoritesAsync_WhenUserHasNoFavoritesRecord_ShouldCreateRecordAndAddProduct()
    {
        string userId = "newUserFavorites";
        int productId = 1;

        var productToAdd = new Product
        {
            Id = productId,
            Name = "Test",
            Description = "Testtest"
        };

        var emptyFavoriteProductsData = new List<FavoriteProduct>()
            .AsQueryable()
            .BuildMock();

        FavoriteProduct capturedFavoriteRecord = null;

        this.repositoryMock.SetupSequence(r => r.All<FavoriteProduct>())
                       .Returns(emptyFavoriteProductsData)
                       .Returns(emptyFavoriteProductsData);

        this.repositoryMock
            .Setup(r => r.GetByIdAsync<Product>(productId))
            .ReturnsAsync(productToAdd);

        this.repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<FavoriteProduct>()))
            .Callback<FavoriteProduct>(fp => capturedFavoriteRecord = fp)
            .Returns(Task.CompletedTask);

        this.repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(1);

        bool result = await this.favoriteProductService
            .AddToFavoritesAsync(productId, userId);

        repositoryMock.Verify(r => r.AddAsync(It.IsAny<FavoriteProduct>()), Times.Once());
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());
        Assert.IsTrue(result);
        Assert.IsNotNull(capturedFavoriteRecord);
        Assert.AreEqual(userId, capturedFavoriteRecord.UserId);
        Assert.IsTrue(capturedFavoriteRecord.Products.Any(d => d.Id == productId));
    }

    [Test]
    public async Task AddToFavoritesAsync_WhenUserHasFavoritesRecord_ShouldAddProductToExistingRecord()
    {
        string userId = "userWithExistingFavorites";
        int productIdToAdd = 2;
        int alreadyFavoriteProductId = 1;

        var productToBeAdded = new Product
        {
            Id = productIdToAdd,
            Name = "Test"
        };

        var existingUserFavorites = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product>
            {
                new Product
                {
                    Id = alreadyFavoriteProductId
                }
            }
        };

        var noMatchingFavoriteQuery = new List<FavoriteProduct>
        {
            new FavoriteProduct
            {
                UserId = userId,
                Products = new List<Product>
                {
                    new Product
                    {
                        Id = alreadyFavoriteProductId
                    }
                }
            }
        }
        .AsQueryable()
        .BuildMock();

        var userFavoritesQuery = new List<FavoriteProduct> { existingUserFavorites }
            .AsQueryable()
            .BuildMock();

        repositoryMock.SetupSequence(r => r.All<FavoriteProduct>())
                       .Returns(noMatchingFavoriteQuery)
                       .Returns(userFavoritesQuery);

        repositoryMock
            .Setup(r => r.GetByIdAsync<Product>(productIdToAdd))
            .ReturnsAsync(productToBeAdded);

        repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(1);

        bool result = await this.favoriteProductService
            .AddToFavoritesAsync(productIdToAdd, userId);

        repositoryMock.Verify(r => r.AddAsync(It.IsAny<FavoriteProduct>()), Times.Never());
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());
        Assert.IsTrue(result);
        Assert.AreEqual(2, existingUserFavorites.Products.Count);
        Assert.IsTrue(existingUserFavorites.Products.Any(d => d.Id == productIdToAdd));
    }

    [Test]
    public async Task AddToFavoritesAsync_WhenProductToAddIsNotFound_ShouldNotAddAndReturnTrue()
    {
        string userId = "user1";
        int nonExistentProductId = 99;

        var emptyFavoritesForExistingCheck = new List<FavoriteProduct>()
            .AsQueryable()
            .BuildMock();

        var userFavoritesRecord = new FavoriteProduct 
        { 
            UserId = userId, 
            Products = new List<Product>() 
        };
        var favoritesForUserRecordGet = new List<FavoriteProduct> { userFavoritesRecord }
        .AsQueryable()
        .BuildMock();

        repositoryMock.SetupSequence(r => r.All<FavoriteProduct>())
                       .Returns(emptyFavoritesForExistingCheck)
                       .Returns(favoritesForUserRecordGet);

        repositoryMock
            .Setup(r => r.GetByIdAsync<Product>(nonExistentProductId))
            .ReturnsAsync((Product)null);

        repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(1);

        bool result = await this.favoriteProductService.AddToFavoritesAsync(nonExistentProductId, userId);

        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());
        Assert.IsTrue(result);
        Assert.IsFalse(userFavoritesRecord.Products.Any(d => d.Id == nonExistentProductId));
    }

    [Test]
    public async Task GetAllFavoritesAsync_ShouldReturnMappedProducts_WhenFavoritesExist()
    {
        string userId = "userWithFavorites";
        var imageForProduct1 = new Image { Url = "/images/test.jpg" };
        var imageForProduct2 = new Image { Url = "/images/test1.jpg" };

        var product1 = new Product
        {
            Id = 1,
            Name = "Test",
            Description = "Testtest",
            Images = new List<Image> { imageForProduct1 }
        };
        var product2 = new Product
        {
            Id = 2,
            Name = "Testt",
            Description = "TesttestTesttest",
            Images = new List<Image> { imageForProduct2 }
        };

        var userFavoriteRecord = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { product1, product2 }
        };

        var favoriteProductsData = new List<FavoriteProduct> { userFavoriteRecord }
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.AllReadonly<FavoriteProduct>())
            .Returns(favoriteProductsData);

        var result = (await this.favoriteProductService.GetAllFavoritesAsync(userId)).ToList();

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);

        var TestProduct1 = result.FirstOrDefault(d => d.Id == 1);
        Assert.IsNotNull(TestProduct1);
        Assert.AreEqual("Test", TestProduct1.Name);
        Assert.AreEqual("Testtest", TestProduct1.Description);
        Assert.AreEqual(1, TestProduct1.ImageUrls.Count);
        Assert.AreEqual("/images/test.jpg", TestProduct1.ImageUrls.First());

        var TestProduct2 = result.FirstOrDefault(d => d.Id == 2);
        Assert.IsNotNull(TestProduct2);
        Assert.AreEqual("Testt", TestProduct2.Name);
    }

    [Test]
    public async Task GetAllFavoritesAsync_ShouldReturnEmptyList_WhenUserHasNoFavorites()
    {
        string userId = "userWithoutFavorites";
        var emptyFavoriteProductsData = new List<FavoriteProduct>()
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.AllReadonly<FavoriteProduct>())
            .Returns(emptyFavoriteProductsData);

        var result = await this.favoriteProductService.GetAllFavoritesAsync(userId);

        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public async Task IsInFavoriteAsync_ShouldReturnTrue_WhenProductIsInFavorites()
    {
        string userId = "user1";
        int productId = 1;
        var favoriteProduct = new Product 
        { 
            Id = productId 
        };

        var favoriteRecord = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { favoriteProduct }
        };

        var data = new List<FavoriteProduct> { favoriteRecord }
            .AsQueryable()
            .BuildMock();

        repositoryMock.Setup(r => r.All<FavoriteProduct>()).Returns(data);

        bool result = await this.favoriteProductService.IsInFavoriteAsync(productId, userId);

        Assert.IsTrue(result);
    }

    [Test]
    public async Task IsInFavoriteAsync_ShouldReturnFalse_WhenProductIsNotInFavorites()
    {
        string userId = "user1";
        int targetProductId = 1;
        int actualFavoriteProductId = 2;
        var actualFavoriteProduct = new Product 
        { 
            Id = actualFavoriteProductId 
        };

        var favoriteRecord = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { actualFavoriteProduct }
        };

        var data = new List<FavoriteProduct> { favoriteRecord }
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.All<FavoriteProduct>())
            .Returns(data);

        bool result = await this.favoriteProductService.IsInFavoriteAsync(targetProductId, userId);

        Assert.IsFalse(result);
    }

    [Test]
    public async Task IsInFavoriteAsync_ShouldReturnFalse_WhenUserHasNoFavoritesRecord()
    {
        string userId = "userNoRecords";
        int productId = 1;

        var data = new List<FavoriteProduct>()
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.All<FavoriteProduct>())
            .Returns(data);

        bool result = await this.favoriteProductService.IsInFavoriteAsync(productId, userId);

        Assert.IsFalse(result);
    }

    [Test]
    public async Task RemoveFromFavoritesAsync_WhenProductExistsAndOthersRemain_ShouldUpdateRecord()
    {
        string userId = "user1";
        int productIdToRemove = 1;
        int otherProductId = 2;

        var productToRemove = new Product
        {
            Id = productIdToRemove
        };
        var otherProduct = new Product
        {
            Id = otherProductId
        };
        var userFavoriteRecord = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { productToRemove, otherProduct }
        };
        var data = new List<FavoriteProduct> { userFavoriteRecord }
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.All<FavoriteProduct>())
            .Returns(data);

        repositoryMock
            .Setup(r => r.Update(userFavoriteRecord));

        repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(1);

        await this.favoriteProductService.RemoveFromFavoritesAsync(productIdToRemove, userId);

        repositoryMock.Verify(r => r.Update(userFavoriteRecord), Times.Once());
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());
        Assert.AreEqual(1, userFavoriteRecord.Products.Count);
        Assert.IsFalse(userFavoriteRecord.Products.Any(d => d.Id == productIdToRemove));
        Assert.IsTrue(userFavoriteRecord.Products.Any(d => d.Id == otherProductId));
    }

    [Test]
    public async Task RemoveFromFavoritesAsync_WhenLastProductRemoved_ShouldDeleteRecord()
    {
        string userId = "user1";
        int productIdToRemove = 1;

        var productToRemove =
            new Product
            {
                Id = productIdToRemove
            };
        var userFavoriteRecord = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { productToRemove }
        };

        var data = new List<FavoriteProduct> { userFavoriteRecord }
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.All<FavoriteProduct>())
            .Returns(data);

        repositoryMock
            .Setup(r => r.Delete(userFavoriteRecord));

        repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .ReturnsAsync(1);

        await this.favoriteProductService.RemoveFromFavoritesAsync(productIdToRemove, userId);

        repositoryMock.Verify(r => r.Delete(userFavoriteRecord), Times.Once());
        repositoryMock.Verify(r => r.Update(It.IsAny<FavoriteProduct>()), Times.Never());
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());
        Assert.IsEmpty(userFavoriteRecord.Products);
    }

    [Test]
    public void RemoveFromFavoritesAsync_WhenUserHasNoFavoritesRecord_ShouldThrowInvalidOperationException()
    {
        string userId = "userNoRecord";
        int productId = 1;
        var data = new List<FavoriteProduct>()
            .AsQueryable()
            .BuildMock();

        repositoryMock
            .Setup(r => r.All<FavoriteProduct>())
            .Returns(data);

        var ex = Assert.ThrowsAsync<InvalidOperationException>(() =>
            this.favoriteProductService.RemoveFromFavoritesAsync(productId, userId));
        Assert.AreEqual("This product is not in your favorites.", ex.Message);
    }

    [Test]
    public async Task RemoveFromFavoritesAsync_WhenDestinationNotInRecord_ShouldNotChangeListButStillUpdateAndSave()
    {
        string userId = "user1";
        int productIdToRemove = 99;
        int existingProductId = 1;

        var existingProduct = new Product 
        { 
            Id = existingProductId 
        };

        var userFavoriteRecord = new FavoriteProduct
        {
            UserId = userId,
            Products = new List<Product> { existingProduct }
        };

        var data = new List<FavoriteProduct> { userFavoriteRecord }
            .AsQueryable()
            .BuildMock();

        repositoryMock.Setup(r => r.All<FavoriteProduct>()).Returns(data);
        repositoryMock.Setup(r => r.Update(userFavoriteRecord));
        repositoryMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

        await this.favoriteProductService.RemoveFromFavoritesAsync(productIdToRemove, userId);

        repositoryMock.Verify(r => r.Update(userFavoriteRecord), Times.Once());
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once());
        Assert.AreEqual(1, userFavoriteRecord.Products.Count);
        Assert.IsTrue(userFavoriteRecord.Products.Any(d => d.Id == existingProductId));
    }
}
