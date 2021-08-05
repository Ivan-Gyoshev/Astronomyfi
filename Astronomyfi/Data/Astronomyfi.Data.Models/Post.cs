namespace Astronomyfi.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Common.Models;
    using Astronomyfi.Data.Models.Enums;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public TypeOfPost Type { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
