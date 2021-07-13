namespace Astronomyfi.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Identity;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository, UserManager<ApplicationUser> userManager)
        {
            this.postsRepository = postsRepository;
        }

        public async Task AddPostAsync(CreatePostViewModel post, string userId)
        {
            Enum.TryParse(typeof(TypeOfPost), post.Type.ToString(), out object type);

            var postData = new Post
            {
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                AuthorId = userId,
                Type = (TypeOfPost)type,
            };

            await this.postsRepository.AddAsync(postData);
            await this.postsRepository.SaveChangesAsync();
        }

        public IEnumerable<TypeOfPost> GetPostTypes()
             => Enum.GetValues(typeof(TypeOfPost))
            .Cast<TypeOfPost>()
            .ToList();
    }
}
