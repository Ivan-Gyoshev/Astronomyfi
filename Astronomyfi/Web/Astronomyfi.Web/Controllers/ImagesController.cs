namespace Astronomyfi.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ImagesController : Controller
    {
        public IActionResult Index() => this.View();

        public IActionResult All() => this.View();

        [Authorize]
        public IActionResult Post() => this.View();

        //public IActionResult Post(PostPictureViewModel)
        //{

        //}
    }
}
