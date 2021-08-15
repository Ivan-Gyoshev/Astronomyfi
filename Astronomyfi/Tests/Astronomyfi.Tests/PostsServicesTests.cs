namespace Astronomyfi.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Data.Repositories;
    using Astronomyfi.Services.Data.Posts;
    using Astronomyfi.Services.Data.Tests.Common;
    using Astronomyfi.Web.ViewModels.Posts;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit;

    public class PostsServicesTests : BaseTestsService
    {
        private IPostsService Service
            => this.ServiceProvider.GetRequiredService<IPostsService>();

        [Theory]
        [InlineData(1, "TestTitle", "Test content", (TypeOfPost)1, 1, "TestUserId")]
        public async Task AddPostShouldSuccessfullyCreatePost(int id, string title, string content, TypeOfPost type, int categoryId, string userId)
        {
            var error = "PostsService AddPostAsync() method does not work!";

            // Arange
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext;

            var postsRepository = new EfRepository<Post>(dbContext);

            var postsService = new PostsService(postsRepository);

            // Act
            await postsService.AddPostAsync(id, title, content, categoryId, type, userId);

            var actualResult = postsRepository.All().First();

            // Assert
            Assert.True(actualResult.Id == id, error);
            Assert.True(actualResult.Title == title, error);
            Assert.True(actualResult.Content == content, error);
            Assert.True(actualResult.Type == type, error);
            Assert.True(actualResult.CategoryId == categoryId, error);
            Assert.True(actualResult.AuthorId == userId, error);
        }

        [Theory]
        [InlineData("Title1", "Test content", 1, (TypeOfPost)10)]
        public async Task EditPostShouldWorkCorrectly(string title, string content, int categoryId, TypeOfPost type)
        {
            var post = await this.CreatePostAsync();

            await this.Service.EditPostAsync(1, title, content, categoryId, type);

            Assert.True(post.Title == title);
        }

        [Fact]
        public async Task GetByIdShouldWorkCorrectly()
        {
            var post = await this.CreatePostAsync();

            var result = this.Service.GetById(post.Id);

            Assert.True(post == result);
        }

        [Fact]
        public async Task DeleteShouldWorkCorrectly()
        {
            var post = await this.CreatePostAsync();

            await this.Service.DeletePostAsync(post.Id);

            Assert.True(this.DbContext.Posts.Count() == 0);
        }

        [Fact]
        public async Task GetPostTypeShouldWorkCorrectly()
        {
            var listTypes = new List<TypeOfPost>();
            listTypes.Add((TypeOfPost)10);
            listTypes.Add((TypeOfPost)20);
            listTypes.Add((TypeOfPost)30);
            listTypes.Add((TypeOfPost)40);
            listTypes.Add((TypeOfPost)50);

            var postTypes = this.Service.GetPostTypes();

            Assert.True(listTypes.Count() == postTypes.Count());
        }

        private async Task<Post> CreatePostAsync()
        {
            var post = new Post
            {
                Id = 1,
                Title = "TestTitle",
                Content = "Test content",
                CategoryId = 1,
                Type = (TypeOfPost)1,
                AuthorId = "TestUserId",
                CreatedOn = DateTime.UtcNow,
            };

            await this.DbContext.AddAsync(post);
            await this.DbContext.SaveChangesAsync();

            return post;
        }
    }
}
