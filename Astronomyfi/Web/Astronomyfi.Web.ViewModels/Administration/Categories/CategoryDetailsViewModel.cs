namespace Astronomyfi.Web.ViewModels.Administration.Categories
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class CategoryDetailsViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
