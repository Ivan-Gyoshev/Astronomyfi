namespace Astronomyfi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            return this.View();
        }
    }
}
