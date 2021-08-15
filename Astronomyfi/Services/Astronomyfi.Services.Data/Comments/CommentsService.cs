namespace Astronomyfi.Services.Data.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository) 
            => this.commentsRepository = commentsRepository;

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

        public async Task EditCommentAsync(string content, int postId, int commentId)
        {
            var comment = this.GetById(postId, commentId);

            comment.Content = content;

            await this.commentsRepository.SaveChangesAsync();
        }

        public IEnumerable<TModel> ListComments<TModel>(int postId)
           => this.commentsRepository
                .All()
                .Where(c => c.PostId == postId)
                .To<TModel>()
                .ToList();

        public async Task DeleteCommentAsync(int postId, int commentId)
        {
            var comment = this.GetById(postId, commentId);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;

            await this.commentsRepository.SaveChangesAsync();
        }

        public T GetById<T>(int postId, int commentId)
           => this.commentsRepository.All()
           .Where(c => c.PostId == postId & c.Id == commentId)
           .To<T>()
           .FirstOrDefault();

        public Comment GetById(int postId, int commentId)
          => this.commentsRepository.All()
                .FirstOrDefault(c => c.PostId == postId
                && c.Id == commentId);
    }
}
