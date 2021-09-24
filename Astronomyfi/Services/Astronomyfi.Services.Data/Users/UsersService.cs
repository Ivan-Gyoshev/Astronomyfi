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
        private readonly IRepository<Post> postsRepository;
        private readonly IRepository<Image> imagesRepository;
        private readonly IRepository<Comment> commentsRepository;
        private readonly IRepository<Vote> votesRepository;
        private readonly ICloudinaryService cloudinaryService;

        public UsersService(IRepository<ApplicationUser> usersRepository, ICloudinaryService cloudinaryService, IRepository<Post> postsRepository, IRepository<Image> imagesRepository, IRepository<Comment> commentsRepository, IRepository<Vote> votesRepository)
        {
            this.usersRepository = usersRepository;
            this.cloudinaryService = cloudinaryService;
            this.postsRepository = postsRepository;
            this.imagesRepository = imagesRepository;
            this.commentsRepository = commentsRepository;
            this.votesRepository = votesRepository;
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

        // Still in Work

        //public async Task DeleteUserAsync(string userId)
        //{
        //    var user = this.GetUser(userId);

        //    if (this.postsRepository.All().Any(p => p.AuthorId == user.Id))
        //    {
        //        var postsToDelete = this.postsRepository.All().Where(p => p.AuthorId == user.Id).ToList();

        //        foreach (var post in postsToDelete)
        //        {
        //            foreach (var comment in post.Comments)
        //            {
        //                this.commentsRepository.Delete(comment);
        //            }

        //            this.postsRepository.Delete(post);
        //        }

        //        await this.postsRepository.SaveChangesAsync();
        //    }

        //    if (this.commentsRepository.All().Any(c => c.Author.Id == userId))
        //    {
        //        var commentsToDelete = this.commentsRepository.All().Where(i => i.AuthorId == user.Id).ToList();

        //        foreach (var comment in commentsToDelete)
        //        {
        //            this.commentsRepository.Delete(comment);
        //        }

        //        await this.commentsRepository.SaveChangesAsync();
        //    }

        //    if (this.votesRepository.All().Any(c => c.AuthorId == user.Id))
        //    {
        //        var votesToDelete = this.votesRepository.All().Where(i => i.AuthorId == user.Id).ToList();

        //        foreach (var vote in votesToDelete)
        //        {
        //            this.votesRepository.Delete(vote);
        //        }

        //        await this.votesRepository.SaveChangesAsync();
        //    } 
        //    if (this.imagesRepository.All().Any(i => i.AuthorId == user.Id))
        //    {
        //        var imagesToDelete = this.imagesRepository.All().Where(i => i.AuthorId == user.Id).ToList();

        //        foreach (var image in imagesToDelete)
        //        {
        //            this.imagesRepository.Delete(image);
        //        }

        // await this.imagesRepository.SaveChangesAsync();
        //    }

        //    this.usersRepository.Delete(user);

        //    await this.usersRepository.SaveChangesAsync();
        //}

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
