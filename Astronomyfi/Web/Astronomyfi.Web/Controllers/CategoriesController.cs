namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult All()
        {
            var categories = this.categoryService.GetCategories<ListCategoriesViewModel>();
            return this.View(categories);
        }

        [Authorize]
        public IActionResult Add() => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddCategoryViewModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.categoryService.AddCategoryAsync(
                category.Name,
                category.Description,
                category.ImageUrl);

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult Specify(int categoryId)
        {
            var posts = this.categoryService.GetPostsByCategory<CategorySpecifyViewModel>(categoryId);

            return this.View(posts);
        }
    }
}
