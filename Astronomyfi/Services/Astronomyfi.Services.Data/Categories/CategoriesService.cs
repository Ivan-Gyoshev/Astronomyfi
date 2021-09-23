namespace Astronomyfi.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Categories.ServiceModels;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Categories;
    using Astronomyfi.Web.ViewModels.Posts;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository, IDeletableEntityRepository<Post> postsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.postsRepository = postsRepository;
        }

        public CategoryQueryServiceModel Filter(int categoryId, int currentPage = 1, int postsPerPage = int.MaxValue)
        {
            var postQuery = this.postsRepository.All().Where(p => p.CategoryId == categoryId);

            var totalPosts = postQuery.ToList().Count();

            var category = this.GetCategory(categoryId);

            var posts = this.GetPosts(postQuery.Skip((currentPage - 1) * postsPerPage).Take(postsPerPage));

            return new CategoryQueryServiceModel
            {
                TotalPosts = totalPosts,
                CurrentPage = currentPage,
                PostsPerPage = postsPerPage,
                Categories = category,
                Posts = posts,
            };
        }

        public async Task AddCategoryAsync(string name, string description, string imageUrl)
        {
            var categoryData = new Category
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
            };

            await this.categoriesRepository.AddAsync(categoryData);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(string name, string description, string imageUrl, int categoryId)
        {
            var category = this.GetCategoryById(categoryId);

            category.Name = name;
            category.Description = description;
            category.ImageUrl = imageUrl;

            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = this.GetCategoryById(categoryId);

            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;

            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<TModel> GetCategories<TModel>()
          => this.categoriesRepository.All()
            .To<TModel>()
            .ToList();

        public T GetCategoryById<T>(int categoryId)
            => this.categoriesRepository.All()
            .Where(c => c.Id == categoryId)
            .To<T>()
            .FirstOrDefault();

        public Category GetCategoryById(int categoryId)
            => this.categoriesRepository.All()
            .Where(c => c.Id == categoryId)
            .FirstOrDefault();

        public bool IsExisting(int categoryId)
            => this.categoriesRepository.All()
            .Any(c => c.Id == categoryId);

        private IEnumerable<PostListingViewModel> GetPosts(IQueryable<Post> postQuery)
           => postQuery
               .To<PostListingViewModel>()
               .ToList();

        private CategorySpecifyViewModel GetCategory(int categoryId)
            => this.categoriesRepository
            .All()
            .Where(c => c.Id == categoryId)
            .To<CategorySpecifyViewModel>()
            .FirstOrDefault();
    }
}
