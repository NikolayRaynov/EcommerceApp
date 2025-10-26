using EcommerceApp.Common.Enums;
using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;

namespace EcommerceApp.Services.Tests;

public class OrderServiceTests
{
    private Mock<IRepository> repositoryMock;
    private Mock<UserManager<ApplicationUser>> userManagerMock;
    private OrderService orderService;

    [SetUp]
    public void Setup()
    {
        repositoryMock = new Mock<IRepository>();
        var userStore = new Mock<IUserStore<ApplicationUser>>();
        userManagerMock = new Mock<UserManager<ApplicationUser>>(
            userStore.Object, null, null, null, null, null, null, null, null
        );

        orderService = new OrderService(repositoryMock.Object, userManagerMock.Object);
    }

    [Test]
    public async Task GetCheckoutDetailsAsync_Should_Return_ViewModel_With_Products()
    {
        string userId = "user1";

        var product = new Product
        {
            Id = 1,
            Name = "Phone",
            Description = "Nice phone",
            Price = 500,
            Images = new List<Image> { new Image { Url = "img1.jpg" } }
        };

        var cart = new Cart
        {
            UserId = userId,
            CartProducts = new List<CartProduct>
            {
                new CartProduct { Product = product, Quantity = 2 }
            }
        };

        repositoryMock
            .Setup(r => r.AllReadonly<Cart>())
            .Returns(new List<Cart> { cart }
            .AsQueryable()
            .BuildMock());

        var result = await orderService.GetCheckoutDetailsAsync(userId);

        Assert.That(result.Subtotal, Is.EqualTo(1000));
        Assert.That(result.TotalAmount, Is.GreaterThan(result.Subtotal));
        Assert.That(result.OrderItems.Count, Is.EqualTo(1));
        Assert.That(result.OrderItems.First().ProductName, Is.EqualTo("Phone"));
    }

    [Test]
    public async Task GetCheckoutDetailsAsync_Should_Return_Empty_When_No_Cart()
    {
        repositoryMock
            .Setup(r => r.AllReadonly<Cart>())
            .Returns(new List<Cart>()
            .AsQueryable()
            .BuildMock());

        var result = await orderService.GetCheckoutDetailsAsync("noUser");

        Assert.That(result.Subtotal, Is.EqualTo(0));
        Assert.That(result.TotalAmount, Is.EqualTo(result.ShippingCost));
    }

    [Test]
    public async Task ClearUserCartAsync_Should_Delete_Products_From_Cart()
    {
        string userId = "user1";
        var cart = new Cart
        {
            UserId = userId,
            CartProducts = new List<CartProduct>
            {
                new CartProduct { ProductId = 1, Quantity = 1 }
            }
        };

        repositoryMock
            .Setup(r => r.All<Cart>())
            .Returns(new List<Cart> { cart }
            .AsQueryable()
            .BuildMock());

        repositoryMock.Setup(r => r.DeleteRange(It.IsAny<IEnumerable<CartProduct>>()));
        repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .Returns(Task.FromResult(0));

        await orderService.ClearUserCartAsync(userId);

        repositoryMock.Verify(r => r.DeleteRange(cart.CartProducts), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task UpdateUserOrderStatusAsync_Should_Update_Status()
    {
        var order = new Order { Id = 1, Status = OrderStatus.Pending };

        repositoryMock
            .Setup(r => r.All<Order>())
            .Returns(new List<Order> { order }
            .AsQueryable()
            .BuildMock());

        repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .Returns(Task.FromResult(0));

        await orderService.UpdateUserOrderStatusAsync(1, OrderStatus.Delivered);

        Assert.That(order.Status, Is.EqualTo(OrderStatus.Delivered));
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public void UpdateUserOrderStatusAsync_Should_Throw_When_Order_Not_Found()
    {
        repositoryMock
            .Setup(r => r.All<Order>())
            .Returns(new List<Order>()
            .AsQueryable()
            .BuildMock());

        Assert.ThrowsAsync<InvalidOperationException>(
            async () => await orderService.UpdateUserOrderStatusAsync(99, OrderStatus.Pending)
        );
    }
}
