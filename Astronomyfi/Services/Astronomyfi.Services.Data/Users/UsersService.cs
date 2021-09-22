namespace Astronomyfi.Services.Data.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Common;
    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IRepository<ApplicationUser> usersRepository;
        private readonly ICloudinaryService cloudinaryService;

        public UsersService(IRepository<ApplicationUser> usersRepository, ICloudinaryService cloudinaryService)
        {
            this.usersRepository = usersRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task UpdateAvatarAsync(EditAvatarViewModel input)
        {
            var user = this.GetUser(input.Id);

            if (input.NewImage != null)
            {
                var imageUrl = await this.cloudinaryService.UploadPhotoAsync(input.NewImage, input.Id, GlobalConstants.CloudFolderForUserImages);

                user.AvatarImgUrl = imageUrl;
            }

            this.usersRepository.Update(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = this.GetUser(userId);

            this.usersRepository.Delete(user);

            await this.usersRepository.SaveChangesAsync();
        }

        public IEnumerable<TModel> GetAllUsers<TModel>()
            => this.usersRepository.All()
            .To<TModel>()
            .ToList();

        public TModel GetUser<TModel>(string userId)
            => this.usersRepository
            .All()
            .Where(u => u.Id == userId)
            .To<TModel>()
            .FirstOrDefault();

        public ApplicationUser GetUser(string userId)
          => this.usersRepository.All()
            .FirstOrDefault(u => u.Id == userId);
    }
}
