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

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
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

        public IEnumerable<PostListingViewModel> GetAllPosts()
        {
            var posts = this.postsRepository.All()
                 .Select(p => new PostListingViewModel
                 {
                     Id = p.Id,
                     Title = p.Title,
                     CommentsCount = p.Comments.Count(),
                     Author = p.Author.UserName,
                     CreatedOn = p.CreatedOn.ToString("dd/MM/yyy/ hh:mm"),
                     Type = p.Type.ToString(),
                 })
                 .ToList();

            return posts;
        }

        public PostDetailsViewModel GetPost(int postId)
        {
            var currentPost = this.postsRepository.All()
                .Where(p => p.Id == postId)
                .Select(p => new PostDetailsViewModel
                {
                    Title = p.Title,
                    Content = p.Content,
                    Author = p.Author.UserName,
                    Category = p.Category.Name,
                    CategoryId = p.CategoryId,
                    Type = p.Type.ToString(),
                    CreatedOn = p.CreatedOn.ToString("dd/MM/yyyy hh:mm"),
                })
                .FirstOrDefault();

            return currentPost;
        }

        public IEnumerable<TypeOfPost> GetPostTypes()
             => Enum.GetValues(typeof(TypeOfPost))
            .Cast<TypeOfPost>()
            .ToList();
    }
}
