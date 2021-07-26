namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        Task CreateCommentAsync(string content, string userId, int postId);

        IEnumerable<PostCommentsViewModel> ListComments(int postId);
    }
}
