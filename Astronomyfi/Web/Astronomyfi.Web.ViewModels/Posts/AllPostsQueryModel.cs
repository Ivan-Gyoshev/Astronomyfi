namespace Astronomyfi.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllPostsQueryModel
    {
        public const int PostsPerPage = 6;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
