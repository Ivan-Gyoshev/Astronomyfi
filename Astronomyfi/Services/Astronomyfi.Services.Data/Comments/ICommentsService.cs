namespace Astronomyfi.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;

    public interface ICommentsService
    {
        Task CreateCommentAsync(string content, string userId, int postId);

        Task EditCommentAsync(string content, int postId, int commentId);

        Task DeleteCommentAsync(int postId, int commentId);

        IEnumerable<TModel> ListComments<TModel>(int postId);

        T GetById<T>(int postId, int commentId);

        Comment GetById(int postId, int commentId);
    }
}
