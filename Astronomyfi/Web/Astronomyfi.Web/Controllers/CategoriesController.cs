namespace Astronomyfi.Web.Controllers
{
    using System.Linq;

    using Astronomyfi.Data;
    using Astronomyfi.Services.Data;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult All()
        {
            var categories = this.categoryService.GetCategories();
            return this.View(categories);
        }

        public IActionResult Add() => this.View();

        //[HttpPost]
        //public IActionResult Add(AddCategoryViewModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View();
        //    }

        //    //return this.RedirectToAction("All", "Categories");
        //}
    }
}
