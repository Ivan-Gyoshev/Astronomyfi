namespace Astronomyfi.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Astronomyfi.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image() => this.Id = Guid.NewGuid().ToString();

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public string Extension { get; set; }
    }
}
