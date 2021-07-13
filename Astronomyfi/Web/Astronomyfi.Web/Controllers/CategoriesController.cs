namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Services.Data;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService) => this.categoryService = categoryService;

        public IActionResult All()
        {
            var categories = this.categoryService.GetCategories();
            return this.View(categories);
        }

        [HttpGet]
        public IActionResult Add() => this.View();

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.categoryService.AddCategoryAsync(category);

            return this.RedirectToAction("All", "Categories");
        }
    }
}
