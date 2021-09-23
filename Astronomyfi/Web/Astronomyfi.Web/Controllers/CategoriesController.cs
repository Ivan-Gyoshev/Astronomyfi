namespace Astronomyfi.Web.Controllers
{
    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoryService)
            => this.categoriesService = categoryService;

        public IActionResult All()
        {
            var categories = this.categoriesService.GetCategories<ListCategoriesViewModel>();
            return this.View(categories);
        }

        public IActionResult Specify([FromQuery] CategoryPostsQueryModel query, int categoryId)
        {
            var queryResult = this.categoriesService.Filter(categoryId, query.CurrentPage, CategoryPostsQueryModel.PostsPerPage);

            query.Category = queryResult.Categories;
            query.TotalPosts = queryResult.TotalPosts;
            query.Posts = queryResult.Posts;

            return this.View(query);
        }
    }
}
