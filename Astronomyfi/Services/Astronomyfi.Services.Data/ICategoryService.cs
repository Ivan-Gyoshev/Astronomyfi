namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Web.ViewModels.Categories;

    public interface ICategoryService
    {
        IEnumerable<ListCategoriesViewModel> GetCategories();

        Task AddCategoryAsync(AddCategoryViewModel category);
    }
}
