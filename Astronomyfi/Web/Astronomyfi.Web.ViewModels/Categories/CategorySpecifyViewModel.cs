namespace Astronomyfi.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Posts;

    public class CategorySpecifyViewModel : IMapFrom<Category>, IMapFrom<Post>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ForumUser Author { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<PostListingViewModel> Posts { get; set; }
    }
}
