namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;

    using Astronomyfi.Web.ViewModels.Categories;

    public interface ICategoryService
    {
        IEnumerable<ListCategoriesViewModel> GetCategories();
    }
}
