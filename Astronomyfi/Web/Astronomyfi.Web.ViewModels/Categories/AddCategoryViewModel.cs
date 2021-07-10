namespace Astronomyfi.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class AddCategoryViewModel
    {
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
