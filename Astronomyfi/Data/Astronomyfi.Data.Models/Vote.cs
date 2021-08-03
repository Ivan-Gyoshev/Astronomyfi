﻿namespace Astronomyfi.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Common.Models;
    using Astronomyfi.Data.Models.Enums;

    public class Vote : BaseDeletableModel<int>
    {
        public TypeOfVote Type { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ForumUser Author { get; set; }

        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
