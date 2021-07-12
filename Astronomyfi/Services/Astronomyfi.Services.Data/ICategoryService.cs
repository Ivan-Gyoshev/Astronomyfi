namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Web.ViewModels.Categories;
    using Astronomyfi.Web.ViewModels.Posts;

    public interface ICategoryService
    {
        IEnumerable<ListCategoriesViewModel> GetCategories();

        IEnumerable<PostCategoryViewModel> GetCategoriesById();

        Task AddCategoryAsync(AddCategoryViewModel category);
    }
}
