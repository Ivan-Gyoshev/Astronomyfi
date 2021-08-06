namespace Astronomyfi.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Common.Models;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class Image : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(ImageDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public bool IsApproved { get; set; }
    }
}
