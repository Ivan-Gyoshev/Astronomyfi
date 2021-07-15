namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
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

        public IEnumerable<ListCategoriesViewModel> GetCategories()
        {
            var categories = this.categoriesRepository.All()
                .Select(c => new ListCategoriesViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    PostsCount = this.postsRepository.All().Where(p => p.Category.Name == c.Name)
                    .Count(),
                })
                .ToList();

            return categories;
        }

        public async Task AddCategoryAsync(AddCategoryViewModel category)
        {
            var categoryData = new Category
            {
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
            };

            await this.categoriesRepository.AddAsync(categoryData);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<PostCategoryViewModel> GetCategoriesById()
          => this.categoriesRepository.All()
            .Select(c => new PostCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToList();
    }
}
