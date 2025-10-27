using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using EcommerceApp.Services.Data.Interfaces;
using MockQueryable;
using Moq;

namespace EcommerceApp.Services.Tests
{
    [TestFixture]
    public class CartServiceTests
    {
        private Mock<IRepository> repositoryMock;
        private Mock<IProductService> productServiceMock;
        private CartService cartService;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>();
            productServiceMock = new Mock<IProductService>();
            cartService = new CartService(repositoryMock.Object, productServiceMock.Object);
        }

        [Test]
        public async Task AddProductToCartAsync_Should_Add_New_Product_When_Not_In_Cart()
        {
            string userId = "user1";
            int productId = 10;
            var cart = new Cart 
            { 
                Id = 1, 
                UserId = userId 
            };

            var carts = new List<Cart> { cart }.AsQueryable().BuildMock();

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(carts);

            repositoryMock
                .Setup(r => r.All<CartProduct>())
                .Returns(new List<CartProduct>()
                .AsQueryable()
                .BuildMock());

            repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<CartProduct>()))
                .Returns(Task.CompletedTask);

            await cartService.AddProductToCartAsync(productId, userId);

            repositoryMock.Verify(r => r.AddAsync(It.Is<CartProduct>
                (cp => cp.ProductId == productId && cp.CartId == cart.Id)), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.AtLeastOnce);
        }

        [Test]
        public async Task AddProductToCartAsync_Should_Increase_Quantity_When_Product_Exists()
        {
            string userId = "user1";
            int productId = 5;
            var cart = new Cart 
            { 
                Id = 1, 
                UserId = userId 
            };

            var existingItem = new CartProduct 
            { 
                CartId = 1, 
                ProductId = 5, 
                Quantity = 1 
            };

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(new List<Cart> { cart }
                .AsQueryable()
                .BuildMock());

            repositoryMock
                .Setup(r => r.All<CartProduct>())
                .Returns(new List<CartProduct> { existingItem }
                .AsQueryable()
                .BuildMock());

            await cartService.AddProductToCartAsync(productId, userId);

            Assert.That(existingItem.Quantity, Is.EqualTo(2));
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DecreaseProductQuantityAsync_Should_Delete_When_Quantity_Reaches_Zero()
        {
            string userId = "user1";
            int productId = 5;

            var cart = new Cart 
            { 
                Id = 1, 
                UserId = userId 
            };

            var item = new CartProduct 
            { 
                CartId = 1, 
                ProductId = 5, 
                Quantity = 1 
            };

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(new List<Cart> { cart }
                .AsQueryable().BuildMock());

            repositoryMock
                .Setup(r => r.All<CartProduct>())
                .Returns(new List<CartProduct> { item }
                .AsQueryable()
                .BuildMock());

            await cartService.DecreaseProductQuantityAsync(productId, userId);

            repositoryMock.Verify(r => r.Delete(It.Is<CartProduct>(cp => cp == item)), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetCartItemCountAsync_Should_Return_Total_Quantity()
        {
            string userId = "user1";
            var cart = new Cart
            {
                Id = 1,
                UserId = userId,
                CartProducts = new List<CartProduct>
                {
                    new CartProduct { Quantity = 2 },
                    new CartProduct { Quantity = 3 }
                }
            };

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(new List<Cart> { cart }.AsQueryable().BuildMock());

            var result = await cartService.GetCartItemCountAsync(userId);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public async Task GetUserCartAsync_Should_Return_Cart_With_Items()
        {
            string userId = "user1";

            var cart = new Cart 
            { 
                Id = 1, 
                UserId = userId 
            };

            var product = new Product
            {
                Id = 5,
                Name = "Test Product",
                Price = 100m,
                Images = new List<Image>
                {
                    new Image { Url = "img1.jpg" },
                    new Image { Url = "img2.jpg" }
                }
            };

            var cartProduct = new CartProduct
            {
                CartId = 1,
                ProductId = 5,
                Quantity = 2,
                Product = product
            };

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(new List<Cart> { cart }
                .AsQueryable()
                .BuildMock());

            repositoryMock
                .Setup(r => r.All<CartProduct>())
                .Returns(new List<CartProduct> { cartProduct }
                .AsQueryable()
                .BuildMock());

            var result = await cartService.GetUserCartAsync(userId);

            Assert.IsNotNull(result);
            Assert.That(result.CartItems.Count, Is.EqualTo(1));
            Assert.That(result.CartItems.First().ProductName, Is.EqualTo("Test Product"));
            Assert.That(result.CartItems.First().Quantity, Is.EqualTo(2));
            Assert.That(result.CartItems.First().ImageUrls.Count, Is.EqualTo(2));
            Assert.That(result.ShippingCost, Is.EqualTo(EcommerceApp.Common.ApplicationConstants.DefaultShippingCost));
        }

        [Test]
        public async Task GetUserCartAsync_Should_Return_Empty_List_When_No_Items()
        {
            string userId = "user2";

            var cart = new Cart 
            { 
                Id = 2, 
                UserId = userId 
            };

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(new List<Cart> { cart }
                .AsQueryable()
                .BuildMock());

            repositoryMock
                .Setup(r => r.All<CartProduct>())
                .Returns(new List<CartProduct>()
                .AsQueryable()
                .BuildMock());

            var result = await cartService.GetUserCartAsync(userId);

            Assert.IsNotNull(result);
            Assert.That(result.CartItems.Count, Is.EqualTo(0));
            Assert.That(result.ShippingCost, Is.EqualTo(EcommerceApp.Common.ApplicationConstants.DefaultShippingCost));
        }

        [Test]
        public void RemoveProductFromCartAsync_Should_Throw_When_Product_Not_Found()
        {
            string userId = "user1";
            int productId = 5;
            
            var cart = new Cart 
            { 
                Id = 1, 
                UserId = userId 
            };

            repositoryMock
                .Setup(r => r.All<Cart>())
                .Returns(new List<Cart> { cart }
                .AsQueryable()
                .BuildMock());

            repositoryMock
                .Setup(r => r.All<CartProduct>())
                .Returns(new List<CartProduct>()
                .AsQueryable()
                .BuildMock());

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await cartService.RemoveProductFromCartAsync(productId, userId));
        }
    }
}
