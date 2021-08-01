namespace Astronomyfi.Web.ViewModels.Comments
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class EditCommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public int PostId { get; set; }

        public int Id { get; set; }
    }
}
