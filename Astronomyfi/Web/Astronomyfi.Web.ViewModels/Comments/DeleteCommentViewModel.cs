namespace Astronomyfi.Web.ViewModels.Comments
{
    using System;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class DeleteCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public ApplicationUser Author { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
