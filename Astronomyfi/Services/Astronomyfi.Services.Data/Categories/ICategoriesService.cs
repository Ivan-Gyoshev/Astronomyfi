namespace Astronomyfi.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Categories.ServiceModels;

    public interface ICategoriesService
    {
        Task AddCategoryAsync(string name, string description, string imageUrl);

        Task EditCategoryAsync(string name, string description, string imageUrl, int categoryId);

        Task DeleteCategoryAsync(int categoryId);

        CategoryQueryServiceModel Filter(int categoryId, int currentPage = 1, int postsPerPage = int.MaxValue);

        IEnumerable<TModel> GetCategories<TModel>();

        T GetCategoryById<T>(int categoryId);

        Category GetCategoryById(int categoryId);

        TModel GetPostsByCategory<TModel>(int categoryId);

        bool IsExisting(int categoryId);
    }
}
