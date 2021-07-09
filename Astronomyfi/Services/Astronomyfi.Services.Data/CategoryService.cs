namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

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
    }
}
