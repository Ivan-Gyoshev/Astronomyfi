namespace Astronomyfi.Web.ViewModels.Images
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class AddImageInputModel : IMapFrom<Image>
    {
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser Author { get; set; }
    }
}
