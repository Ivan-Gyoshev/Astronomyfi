namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Categories;
    using Astronomyfi.Web.ViewModels.Posts;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoriesRepository) => this.categoriesRepository = categoriesRepository;

        public IEnumerable<ListCategoriesViewModel> GetCategories()
        {
            var categories = this.categoriesRepository.All()
                .Select(c => new ListCategoriesViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,

                    // TODO Posts Count
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
