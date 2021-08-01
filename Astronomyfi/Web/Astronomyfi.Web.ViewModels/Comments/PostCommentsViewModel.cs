namespace Astronomyfi.Web.ViewModels.Comments
{
    using System;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class PostCommentsViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
