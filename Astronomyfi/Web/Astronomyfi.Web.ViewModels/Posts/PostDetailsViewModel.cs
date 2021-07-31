namespace Astronomyfi.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Comments;

    public class PostDetailsViewModel : IMapFrom<Post>, IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Author { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<PostCommentsViewModel> Comments { get; set; }
    }
}
