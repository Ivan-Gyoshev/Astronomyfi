namespace Astronomyfi.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using Astronomyfi.Web.ViewModels.Posts;

    public class CategoryPostsQueryModel
    {
        public const int PostsPerPage = 6;

        public int TotalPosts { get; set; }

        public int CurrentPage { get; set; } = 1;

        public CategorySpecifyViewModel Categories { get; set; }
    }
}
