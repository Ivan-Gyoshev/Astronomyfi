namespace Astronomyfi.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Common.Models;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(CategoryDescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
