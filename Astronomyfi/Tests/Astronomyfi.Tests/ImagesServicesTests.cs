namespace Astronomyfi.Services.Data.Tests
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Images;
    using Astronomyfi.Web.ViewModels.Images;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ImagesServicesTests : BaseTestsService
    {
        private IImagesService Service
           => this.ServiceProvider.GetRequiredService<IImagesService>();

        [Theory]
        [InlineData(1, "testUrl", "testDescription")]
        public async Task PostAsyncShouldWorkCorrectly(int id, string url, string description)
        {
            var image = new AddImageInputModel
            {
                Id = 1,
                ImageUrl = "testUrl",
                Description = "testDescription",
            };

            await this.Service.PostAsync(image);

            var result = this.DbContext.Images.Count();
            var expected = 1;

            Assert.True(result == expected);
        }

        [Fact]
        public async Task ApproveAsyncShouldWorkCorrectly()
        {
            var image = await this.CreateImageAsync();

            await this.Service.ApproveAsync(image.Id);

            Assert.True(image.IsApproved);
        }

        private async Task<Image> CreateImageAsync()
        {
            var image = new Image
            {
                Id = 1,
                ImageUrl = "testUrl",
                Description = "testDescription",
                IsApproved = false,
            };

            await this.DbContext.AddAsync(image);
            await this.DbContext.SaveChangesAsync();

            return image;
        }
    }
}
