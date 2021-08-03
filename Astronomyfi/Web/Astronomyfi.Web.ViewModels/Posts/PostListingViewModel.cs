namespace Astronomyfi.Web.ViewModels.Posts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class PostListingViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Comments")]
        public int CommentsCount { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public ForumUser Author { get; set; }

        public string Type { get; set; }
    }
}
