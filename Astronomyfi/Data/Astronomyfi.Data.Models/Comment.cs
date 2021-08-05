namespace Astronomyfi.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Common.Models;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment() => this.Votes = new HashSet<Vote>();

        [Required]
        [MaxLength(CommentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
