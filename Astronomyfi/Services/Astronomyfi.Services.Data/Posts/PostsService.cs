﻿namespace Astronomyfi.Services.Data.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Services.Mapping;

    public class PostsService : IPostsService
    {
        private readonly IRepository<Post> postsRepository;

        public PostsService(IRepository<Post> postsRepository)
            => this.postsRepository = postsRepository;

        public async Task AddPostAsync(int id, string title, string content, int categoryId, TypeOfPost type, string userId)
        {
            Enum.TryParse(typeof(TypeOfPost), type.ToString(), out object typeResult);

            var postData = new Post
            {
                Id = id,
                Title = title,
                Content = content,
                CategoryId = categoryId,
                AuthorId = userId,
                Type = (TypeOfPost)typeResult,
            };

            await this.postsRepository.AddAsync(postData);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task EditPostAsync(int postId, string title, string content, int categoryId, TypeOfPost type)
        {
            var currentPost = this.GetById(postId);

            currentPost.Title = title;
            currentPost.CategoryId = categoryId;
            currentPost.Content = content;
            currentPost.Type = type;

            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = this.GetById(postId);

            post.IsDeleted = true;
            post.DeletedOn = DateTime.UtcNow;

            await this.postsRepository.SaveChangesAsync();
        }

        public IEnumerable<TModel> GetAllPosts<TModel>()
            => this.postsRepository.All()
                  .OrderByDescending(c => c.CreatedOn)
                 .To<TModel>()
                 .ToList();

        public TModel GetPost<TModel>(int postId)
             => this.postsRepository.All()
                .Where(p => p.Id == postId)
                .To<TModel>()
                .FirstOrDefault();

        public IEnumerable<TypeOfPost> GetPostTypes()
             => Enum.GetValues(typeof(TypeOfPost))
            .Cast<TypeOfPost>()
            .ToList();

        public Post GetById(int postId)
            => this.postsRepository.All()
            .Where(p => p.Id == postId)
            .FirstOrDefault();
    }
}
