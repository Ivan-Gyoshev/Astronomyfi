namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Images;
    using Astronomyfi.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ImagesController : Controller
    {
        private readonly IImagesService imagesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ImagesController(IImagesService imagesService, UserManager<ApplicationUser> userManager)
        {
            this.imagesService = imagesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(IndexPageViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            input.UserId = user.Id;

            return this.View(input);
        }

        public IActionResult All()
        {
            var images = this.imagesService.GetAllApprovedImages<ImageListingViewModel>();

            return this.View(images);
        }

        [Authorize]
        public IActionResult Post() => this.View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(AddImageInputModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            input.AuthorId = user.Id;

            await this.imagesService.PostAsync(input);

            return this.RedirectToAction("All", "Images");
        }
    }
}
