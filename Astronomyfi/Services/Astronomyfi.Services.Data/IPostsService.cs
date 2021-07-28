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

        Task AddPostAsync(PostFormModel post, string userId);

        Task EditPostAsync(PostFormModel post, int postId);

        Post GetById(int postId);

        Task DeletePostAsync(int postId);

        PostDetailsViewModel GetPost(int postId);
    }
}
