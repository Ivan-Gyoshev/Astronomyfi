// ReSharper disable VirtualMemberCallInConstructor
namespace Astronomyfi.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Astronomyfi.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    using static Astronomyfi.Data.Models.Common.DataConstants;

    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            this.AvatarImgUrl = UserDefaultAvatar;
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string AvatarImgUrl { get; set; }

        public int AccountScore { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
