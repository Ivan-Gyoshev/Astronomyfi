namespace Astronomyfi.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class CreateCommentViewModel
    {
        public int PostId { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Content { get; set; }
    }
}
