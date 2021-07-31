namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
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

        public IEnumerable<TModel> GetCategories<TModel>()
        {
            var categories = this.categoriesRepository.All()
                .To<TModel>()
                .ToList();

            return categories;
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

        public IEnumerable<TModel> GetCategoriesById<TModel>()
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
    }
}
