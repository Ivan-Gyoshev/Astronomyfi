namespace Astronomyfi.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Services.Mapping;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class PostFormModel : IMapFrom<Post>, IMapFrom<Category>
    {
        public int Id { get; set; }

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
