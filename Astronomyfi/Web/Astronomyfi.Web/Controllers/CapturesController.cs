namespace Astronomyfi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CapturesController : Controller
    {
        public IActionResult Index() => this.View();

        public IActionResult All() => this.View();
    }
}
