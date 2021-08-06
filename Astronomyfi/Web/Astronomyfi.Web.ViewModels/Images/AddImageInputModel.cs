namespace Astronomyfi.Web.ViewModels.Images
{
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Common;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class AddImageInputModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ImageDescriptionMaxLength, MinimumLength = ImageDescriptionMinLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; } = GlobalConstants.ImageDefault;

        public IFormFile NewImage { get; set; }

        public string AuthorId { get; set; }
    }
}
