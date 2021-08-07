namespace Astronomyfi.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
            => this.categoriesService = categoriesService;

        public IActionResult Add() => this.View();

        [HttpPost]
        public async Task<IActionResult> Add(CategoryInputModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.categoriesService.AddCategoryAsync(
                category.Name,
                category.Description,
                category.ImageUrl);

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult Edit(int id)
        {
            var category = this.categoriesService.GetCategoryById<CategoryInputModel>(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoriesService.EditCategoryAsync(input.Name, input.Description, input.ImageUrl, input.Id);

            return this.RedirectToAction("All", "Categories");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isExisting = this.categoriesService.IsExisting(id);
            if (!isExisting)
            {
                return this.NotFound();
            }

            await this.categoriesService.DeleteCategoryAsync(id);

            return this.RedirectToAction("All", "Categories");
        }
    }
}
