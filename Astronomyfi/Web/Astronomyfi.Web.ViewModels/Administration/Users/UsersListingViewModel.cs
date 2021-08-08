namespace Astronomyfi.Web.ViewModels.Administration.Users
{
    using System;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class UsersListingViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
