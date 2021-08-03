﻿// ReSharper disable VirtualMemberCallInConstructor
namespace Astronomyfi.Data.Models
{
    using System;

    using Astronomyfi.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ForumRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ForumRole()
            : this(null)
        {
        }

        public ForumRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
