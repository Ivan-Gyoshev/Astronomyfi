namespace Astronomyfi.Web.ViewModels.Posts
{
    using Astronomyfi.Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class CreatePostViewModel
    {
        [Required]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; }

        [Required]
        public TypeOfPost Type { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<PostCategoryViewModel> Categories { get; set; }
    }
}
