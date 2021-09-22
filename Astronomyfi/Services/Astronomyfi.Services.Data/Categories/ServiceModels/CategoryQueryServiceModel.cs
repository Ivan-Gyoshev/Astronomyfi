namespace Astronomyfi.Services.Data.Categories.ServiceModels
{
    using System.Collections.Generic;

    using Astronomyfi.Web.ViewModels.Categories;
    using Astronomyfi.Web.ViewModels.Posts;

    public class CategoryQueryServiceModel
    {
        public int TotalPosts { get; set; }

        public int CurrentPage { get; set; }

        public int PostsPerPage { get; set; }

        public CategorySpecifyViewModel Posts { get; set; }
    }
}
