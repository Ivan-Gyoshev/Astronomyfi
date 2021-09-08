namespace Astronomyfi.Services.Data.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;

    public interface IPostsService
    {
        Task AddPostAsync(int id, string title, string content, int categoryId, TypeOfPost type, string userId);

        Task EditPostAsync(int postId, string title, string content, int categoryId, TypeOfPost type);

        Task DeletePostAsync(int postId);

        IEnumerable<TModel> GetAllPosts<TModel>();

        IEnumerable<TypeOfPost> GetPostTypes();

        Post GetById(int postId);

        TModel GetPost<TModel>(int postId);
    }
}
