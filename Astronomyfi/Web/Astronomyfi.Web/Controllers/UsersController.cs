namespace Astronomyfi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        public IActionResult AccountDetails() => this.View();
    }
}
