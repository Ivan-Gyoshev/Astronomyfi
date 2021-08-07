namespace Astronomyfi.Web.Areas.Administration.Controllers
{
    using Astronomyfi.Services.Data.Images;
    using Astronomyfi.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ImagesController : AdministrationController
    {
        private readonly IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
            => this.imagesService = imagesService;

        public IActionResult All()
        {
            var unapprovedImages = this.imagesService.GetAllUnapprovedImages<ImageListingViewModel>();
            return this.View(unapprovedImages);
        }

        public async Task<IActionResult> Approve(int imageId)
        {
            await this.imagesService.ApproveAsync(imageId);

            return this.Redirect("All");
        }
    }
}
