namespace Astronomyfi.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Web.ViewModels.Categories;
    using Astronomyfi.Web.ViewModels.Posts;

    public interface ICategoriesService
    {
        IEnumerable<TModel> GetCategories<TModel>();

        IEnumerable<TModel> GetCategoriesById<TModel>();

        Task AddCategoryAsync(string name, string description, string imageUrl);

        TModel GetPostsByCategory<TModel>(int categoryId);
    }
}
