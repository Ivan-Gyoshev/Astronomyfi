namespace Astronomyfi.Web.ViewModels.Posts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostListingViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Comments")]
        public int CommentsCount { get; set; }

        [Display(Name = "Created On")]
        public string CreatedOn { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }
    }
}
