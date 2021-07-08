namespace Astronomyfi.Web.Controllers
{
    using System.Linq;

    using Astronomyfi.Data;
    using Astronomyfi.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ApplicationDbContext data;

        public CategoriesController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var categories = this.data.Categories
                .Select(c => new ListCategoriesViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,

                    // TODO: Posts Count
                })
                .ToList();

            return this.View(categories);
        }

        public IActionResult Add()
        {
            return this.View();
        }
    }
}
