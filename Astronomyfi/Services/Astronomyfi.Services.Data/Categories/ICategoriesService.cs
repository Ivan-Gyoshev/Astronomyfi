namespace Astronomyfi.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<TModel> GetCategories<TModel>();

        IEnumerable<TModel> GetCategoriesById<TModel>();

        Task AddCategoryAsync(string name, string description, string imageUrl);

        Task EditCategoryAsync(string name, string description, string imageUrl, int categoryId);

        Task DeleteCategoryAsync(int categoryId);

        T GetCategoryById<T>(int categoryId);

        Category GetCategoryById(int categoryId);

        TModel GetPostsByCategory<TModel>(int categoryId);

        bool IsExisting(int categoryId);
    }
}
