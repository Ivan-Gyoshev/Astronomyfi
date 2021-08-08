namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoriesService = categoryService;
        }

        public IActionResult All()
        {
            var categories = this.categoriesService.GetCategories<ListCategoriesViewModel>();
            return this.View(categories);
        }

        public IActionResult Specify(int categoryId)
        {
            var posts = this.categoriesService.GetPostsByCategory<CategorySpecifyViewModel>(categoryId);

            return this.View(posts);
        }
    }
}