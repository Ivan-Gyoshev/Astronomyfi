namespace Astronomyfi.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class CategoryInputModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryMaxLength, MinimumLength = CategoryMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(CategoryDescriptionMaxLength, MinimumLength = CategoryDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}
