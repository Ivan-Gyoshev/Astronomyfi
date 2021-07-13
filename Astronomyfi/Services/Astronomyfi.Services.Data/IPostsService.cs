namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Web.ViewModels.Posts;

    public interface IPostsService
    {
        IEnumerable<TypeOfPost> GetPostTypes();

        Task AddPostAsync(CreatePostViewModel post, string userId);
    }
}
