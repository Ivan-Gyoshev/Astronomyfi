namespace Astronomyfi.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Web.ViewModels.Comments;

    public class PostDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        [Display(Name = "Created On")]
        public string CreatedOn { get; set; }

        public IEnumerable<PostCommentsViewModel> Comments { get; set; }
    }
}
