using EcommerceApp.Data.Models;
using EcommerceApp.Data.Repository.Interfaces;
using EcommerceApp.Services.Data;
using EcommerceApp.Services.Data.Interfaces;
using EcommerceApp.Web.ViewModels.Category;
using Microsoft.AspNetCore.Hosting;
using MockQueryable;
using Moq;

namespace EcommerceApp.Tests.Services
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mock<IRepository> repositoryMock;
        private Mock<IFileService> fileServiceMock;
        private Mock<IWebHostEnvironment> envMock;
        private CategoryService categoryService;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>();
            fileServiceMock = new Mock<IFileService>();
            envMock = new Mock<IWebHostEnvironment>();
            categoryService = new CategoryService(repositoryMock.Object, fileServiceMock.Object, envMock.Object);
        }

        [Test]
        public async Task AddAsync_Should_Add_New_Category()
        {
            var model = new AddCategoryViewModel { Name = "Electronics" };
            string rootPath = "wwwroot";
            string folderName = "Electronics";

            fileServiceMock
                .Setup(f => f.SanitizeFolderName(model.Name))
                .Returns(folderName);

            repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Category>()))
                .Returns(Task.CompletedTask);

            await categoryService.AddAsync(model, rootPath);

            repositoryMock.Verify(r => r.AddAsync(It.Is<Category>(c => c.Name == "Electronics")), Times.Once);
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task ExistsByIdAsync_Should_Return_True_If_Category_Exists()
        {
            var categories = new List<Category>
            {
                new Category 
                { 
                    Id = 1, 
                    Name = "Books" 
                }
            }
            .AsQueryable()
            .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Category>())
                .Returns(categories);

            bool result = await categoryService.ExistsByIdAsync(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistsByIdAsync_Should_Return_False_If_Category_Does_Not_Exist()
        {
            var categories = new List<Category>()
                .AsQueryable()
                .BuildMock();
            repositoryMock
                .Setup(r => r.AllReadonly<Category>())
                .Returns(categories);

            bool result = await categoryService.ExistsByIdAsync(5);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task GetAllAsync_Should_Return_All_Categories()
        {
            var data = new List<Category>
            {
                new Category 
                { 
                    Id = 1, 
                    Name = "Electronics" 
                },
                new Category 
                { 
                    Id = 2, 
                    Name = "Books" 
                }
            }
            .AsQueryable()
            .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Category>())
                .Returns(data);

            var result = await categoryService.GetAllAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo("Electronics"));
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_CategoryViewModel_When_Found()
        {
            var data = new List<Category>
            {
                new Category 
                { 
                    Id = 5, 
                    Name = "Toys" 
                }
            }
            .AsQueryable()
            .BuildMock();

            repositoryMock
                .Setup(r => r.AllReadonly<Category>())
                .Returns(data);

            var result = await categoryService.GetByIdAsync(5);

            Assert.IsNotNull(result);
            Assert.That(result!.Name, Is.EqualTo("Toys"));
        }

        [Test]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Found()
        {
            repositoryMock
                .Setup(r => r.AllReadonly<Category>())
                .Returns(new List<Category>()
                .AsQueryable()
                .BuildMock());

            var result = await categoryService.GetByIdAsync(10);

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetCategoryNameByIdAsync_Should_Return_Name()
        {
            var data = new List<Category>
            {
                new Category 
                { 
                    Id = 3, 
                    Name = "Clothes" 
                }
            }
            .AsQueryable()
            .BuildMock();

            repositoryMock.Setup(r => r.AllReadonly<Category>()).Returns(data);

            var name = await categoryService.GetCategoryNameByIdAsync(3);

            Assert.That(name, Is.EqualTo("Clothes"));
        }

        [Test]
        public async Task UpdateAsync_Should_Update_Category_Name()
        {
            int id = 1;
            string oldName = "OldCategory";
            string newName = "NewCategory";
            string webRootPath = "wwwroot";

            var category = new Category 
            { 
                Id = id, 
                Name = oldName 
            };

            var model = new EditCategoryViewModel 
            { 
                Name = newName 
            };

            repositoryMock
                .Setup(r => r.GetByIdAsync<Category>(id))
                .ReturnsAsync(category);
            
            fileServiceMock
                .Setup(f => f.SanitizeFolderName(oldName))
                .Returns(oldName);
            
            fileServiceMock
                .Setup(f => f.SanitizeFolderName(newName))
                .Returns(newName);
            
            repositoryMock
                .Setup(r => r.SaveChangesAsync())
                .ReturnsAsync(1);

            await categoryService.UpdateAsync(id, model, webRootPath);

            Assert.That(category.Name, Is.EqualTo(newName));
            repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void UpdateAsync_Should_Throw_When_Category_Not_Found()
        {
            int id = 5;

            repositoryMock
                .Setup(r => r.GetByIdAsync<Category>(id))
                .ReturnsAsync((Category?)null);

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await categoryService.UpdateAsync(id, new EditCategoryViewModel(), "wwwroot"));
        }
    }
}