namespace Astronomyfi.Services.Data.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository, IDeletableEntityRepository<Post> postsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.postsRepository = postsRepository;
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

        public TModel GetPostsByCategory<TModel>(int categoryId)
        {
            if (this.postsRepository.All().Any(p => p.CategoryId == categoryId))
            {
                var categoryPosts = this.categoriesRepository.All()
                 .Where(p => p.Id == categoryId)
                 .To<TModel>()
                 .FirstOrDefault();

                return categoryPosts;
            }
            else
            {
                var emptyCategory = this.categoriesRepository.All()
                    .Where(c => c.Id == categoryId)
                    .To<TModel>()
                    .FirstOrDefault();

                return emptyCategory;
            }
        }

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
    }
}
