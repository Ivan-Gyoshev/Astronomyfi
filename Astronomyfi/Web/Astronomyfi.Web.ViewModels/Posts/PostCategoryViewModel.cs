namespace Astronomyfi.Web.ViewModels.Posts
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class PostCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
