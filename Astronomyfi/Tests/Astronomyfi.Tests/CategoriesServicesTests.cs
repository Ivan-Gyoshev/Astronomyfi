namespace Astronomyfi.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Repositories;
    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Services.Data.Tests.Common;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CategoriesServicesTests : BaseTestsService
    {
        private ICategoriesService Service
            => this.ServiceProvider.GetRequiredService<ICategoriesService>();

        [Theory]
        [InlineData("TestName", "TestDescription", "TestImageUrl")]
        public async Task AddCategoryShouldSuccessfullyCreatePost(string name, string description, string imageUrl)
        {
            var error = "CategoriesService AddPostAsync() method does not work!";

            // Arange
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext;

            var categoriesRepository = new EfDeletableEntityRepository<Category>(dbContext);

            var categoriesService = new CategoriesService(categoriesRepository, null);

            // Act
            await categoriesService.AddCategoryAsync(name, description, imageUrl);

            var actualResult = categoriesRepository.All().First();

            // Assert
            Assert.True(actualResult.Name == name, error);
            Assert.True(actualResult.Description == description, error);
            Assert.True(actualResult.ImageUrl == imageUrl, error);
        }

        [Theory]
        [InlineData("Name1", "TestDescription!", "TestImage1")]
        public async Task EditCategoryShouldWorkCorrectly(string name, string description, string imageUrl)
        {
            var category = await this.CreateCategoryAsync();

            await this.Service.EditCategoryAsync(name, description, imageUrl,1);

            Assert.True(category.Name == name);
            Assert.True(category.Description == description);
            Assert.True(category.ImageUrl == imageUrl);
        }

        [Fact]
        public async Task GetByIdShouldWorkCorrectly()
        {
            var category = await this.CreateCategoryAsync();

            var result = this.Service.GetCategoryById(category.Id);

            Assert.True(category == result);
        }

        [Fact]
        public async Task DeleteShouldWorkCorrectly()
        {
            var category = await this.CreateCategoryAsync();

            await this.Service.DeleteCategoryAsync(category.Id);

            Assert.True(this.DbContext.Posts.Count() == 0);
        }

        [Fact]
        public async Task IsExistingShouldWorkCorrectly()
        {
            var category = await this.CreateCategoryAsync();

            var result = this.Service.IsExisting(category.Id);

            Assert.True(result);
        }

        private async Task<Category> CreateCategoryAsync()
        {
            var category = new Category
            {
                Id = 1,
                Name = "TestName",
                Description = "TetstDescription",
                ImageUrl = "TestImageUrl",
            };

            await this.DbContext.AddAsync(category);
            await this.DbContext.SaveChangesAsync();

            return category;
        }
    }
}
