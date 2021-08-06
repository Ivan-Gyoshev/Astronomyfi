namespace Astronomyfi.Web.ViewModels.Images
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class ImageListingViewModel : IMapFrom<Image>
    {
        public string Description { get; set; }

        public ApplicationUser Author { get; set; }

        public string ImageUrl { get; set; }
    }
}
