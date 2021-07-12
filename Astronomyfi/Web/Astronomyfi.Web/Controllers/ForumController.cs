namespace Astronomyfi.Web.Controllers
{
    using Astronomyfi.Services.Data;
    using Astronomyfi.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : BaseController
    {
        private readonly ICategoryService categoryService;

        public ForumController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult All() => this.View();

        public IActionResult Create()
        {
            return this.View(new CreatePostViewModel
            {
                Categories = this.categoryService.GetCategoriesById(),
            });
        }
    }
}
