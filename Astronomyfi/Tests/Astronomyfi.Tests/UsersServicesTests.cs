namespace Astronomyfi.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Repositories;
    using Astronomyfi.Services.Data.Tests.Common;
    using Astronomyfi.Services.Data.Users;
    using Astronomyfi.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit;

    public class UsersServicesTests : BaseTestsService
    {
        private ICloudinaryService Cloudinary => this.ServiceProvider.GetRequiredService<ICloudinaryService>();

        private IUsersService Service =>
          this.ServiceProvider.GetRequiredService<IUsersService>();

        [Fact]
        public async Task GetUserShouldReturnCorrectData()
        {
            var user = await this.CreateUserAsync();

            var cloudinaryService = new Mock<ICloudinaryService>();

            var result = this.Service.GetUser(user.Id);

            Assert.True(user == result);
        }

        [Fact]
        public async Task BanUserShouldWorkCorrectly()
        {
            var user = await this.CreateUserAsync();

            await this.Service.BanUserAsync(user.Id);

            var result = this.DbContext.Users.Count();
            var expected = 0;

            Assert.True(result == expected);
        }

        [Fact]
        public async Task UpdateAvatarAsyncShouldWorkCorrectlyWhenNewImageIsNull()
        {
            var user = await this.CreateUserAsync();

            var userUpdate = new EditAvatarViewModel
            {
                Id = "TestId",
                Username = "TestImageUrl",
                AvatarImgUrl = "TestImageUrl",
                NewImage = null,
            };

            await this.Service.UpdateAvatarAsync(userUpdate);

            Assert.True(user.AvatarImgUrl == userUpdate.AvatarImgUrl);
        }

        private async Task<ApplicationUser> CreateUserAsync()
        {
            var user = new ApplicationUser
            {
                Id = "TestId",
                UserName = "TestUserName",
                Email = "TestEmail@email.com",
                AvatarImgUrl = "TestImageUrl",
            };

            await this.DbContext.AddAsync(user);
            await this.DbContext.SaveChangesAsync();

            return user;
        }
    }
}
