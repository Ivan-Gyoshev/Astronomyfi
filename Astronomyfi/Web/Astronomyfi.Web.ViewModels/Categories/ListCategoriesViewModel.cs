namespace Astronomyfi.Web.ViewModels.Categories
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class ListCategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }
    }
}
