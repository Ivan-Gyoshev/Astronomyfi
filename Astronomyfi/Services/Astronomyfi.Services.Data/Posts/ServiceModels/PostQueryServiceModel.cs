namespace Astronomyfi.Services.Data.Posts.ServiceModels
{
    using System.Collections.Generic;

    using Astronomyfi.Web.ViewModels.Posts;

    public class PostQueryServiceModel
    {
        public int TotalPosts { get; set; }

        public int CurrentPage { get; set; }

        public int PostsPerPage { get; set; }

        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
