namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<TypeOfPost> GetPostTypes();

        IEnumerable<PostListingViewModel> GetAllPosts();

        Task AddPostAsync(CreatePostViewModel post, string userId);

        PostDetailsViewModel GetPost(int postId);
    }
}
