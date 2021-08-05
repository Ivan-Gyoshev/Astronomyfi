namespace Astronomyfi.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Astronomyfi.Web.ViewModels.Comments;
    using AutoMapper;

    public class PostDetailsViewModel : IMapFrom<Post>, IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public int VotesCount { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ApplicationUser Author { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<PostCommentsViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostDetailsViewModel>()
                 .ForMember(x => x.VotesCount, options =>
                 {
                     options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                 });
        }
    }
}
