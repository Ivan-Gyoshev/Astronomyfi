namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;

    public interface IPostsService
    {
        IEnumerable<TModel> GetAllPosts<TModel>();

        IEnumerable<TypeOfPost> GetPostTypes();

        Task AddPostAsync(int id, string title, string content, int categoryId, TypeOfPost type, string userId);

        Task EditPostAsync(int postId, string title, string content, int categoryId, TypeOfPost type);

        T GetById<T>(int postId);

        Post GetById(int postId);

        Task DeletePostAsync(int postId);

        TModel GetPost<TModel>(int postId);
    }
}
