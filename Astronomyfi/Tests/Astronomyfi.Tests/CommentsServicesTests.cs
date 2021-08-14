using Astronomyfi.Data.Models;
using Astronomyfi.Data.Repositories;
using Astronomyfi.Services.Data.Comments;
using Astronomyfi.Services.Data.Tests.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Astronomyfi.Services.Data.Tests
{
    public class CommentsServicesTests : BaseTestsService
    {
        private ICommentsService Service
            => this.ServiceProvider.GetRequiredService<ICommentsService>();

        [Theory]
        [InlineData("testContent", "testUserId", 1)]
        public async Task CreateCommentShouldWorkCorrectly(string content, string userId, int postId)
        {
            // Arange
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext;

            var commentsRepository = new EfDeletableEntityRepository<Comment>(dbContext);

            var commentsService = new CommentsService(commentsRepository);

            // Act
            await commentsService.CreateCommentAsync(content, userId, postId);

            var actualResult = commentsRepository.All().First();

            // Assert
            Assert.True(actualResult.Content == content);
            Assert.True(actualResult.AuthorId == userId);
            Assert.True(actualResult.PostId == postId);
        }

        [Theory]
        [InlineData("Content1")]
        public async Task EditCategoryShouldWorkCorrectly(string content)
        {
            var comment = await this.CreateCommentAsync();

            await this.Service.EditCommentAsync(content, comment.PostId, comment.Id);

            Assert.True(comment.Content == content);
        }

        [Fact]
        public async Task GetByIdShouldWorkCorrectly()
        {
            var comment = await this.CreateCommentAsync();

            var result = this.Service.GetById(comment.PostId, comment.Id);

            Assert.True(comment == result);
        }

        [Fact]
        public async Task DeleteShouldWorkCorrectly()
        {
            var comment = await this.CreateCommentAsync();

            await this.Service.DeleteCommentAsync(comment.PostId, comment.Id);

            Assert.True(this.DbContext.Comments.Count() == 0);
        }

        private async Task<Comment> CreateCommentAsync()
        {
            var comment = new Comment
            {
                Id = 1,
                Content = "TestContent",
                AuthorId = "TestId",
            };

            await this.DbContext.AddAsync(comment);
            await this.DbContext.SaveChangesAsync();

            return comment;
        }
    }
}
