namespace Astronomyfi.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using Astronomyfi.Web.ViewModels.Posts;

    public class CategorySpecifyViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
