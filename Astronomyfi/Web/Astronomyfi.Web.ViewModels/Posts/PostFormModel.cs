namespace Astronomyfi.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Models.Enums;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class PostFormModel
    {
        [Required]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        public TypeOfPost Type { get; set; }

        public IEnumerable<PostCategoryViewModel> Categories { get; set; }

        public IEnumerable<TypeOfPost> Types { get; set; }
    }
}
