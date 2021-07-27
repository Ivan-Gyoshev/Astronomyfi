namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateCommentAsync(string content, string userId, int postId)
        {
            var newComment = new Comment
            {
                Content = content,
                AuthorId = userId,
                PostId = postId,
            };

            await this.commentsRepository.AddAsync(newComment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public IEnumerable<PostCommentsViewModel> ListComments(int postId)
        {
            var comments = this.commentsRepository
                .All()
                .Where(c => c.PostId == postId)
                .Select(c => new PostCommentsViewModel
                {
                    Content = c.Content,
                    CreatedOn = c.CreatedOn.ToString("dd-MM-yyy HH:mm"),
                    Author = c.Author.UserName,
                })
                .ToList();

            return comments;
        }
    }
}
