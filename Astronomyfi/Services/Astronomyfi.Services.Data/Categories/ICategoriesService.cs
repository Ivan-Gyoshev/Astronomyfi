namespace Astronomyfi.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<TModel> GetCategories<TModel>();

        IEnumerable<TModel> GetCategoriesById<TModel>();

        Task AddCategoryAsync(string name, string description, string imageUrl);

        TModel GetPostsByCategory<TModel>(int categoryId);
    }
}
