namespace Astronomyfi.Web.ViewModels.Users
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class UsersDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string AvatarImgUrl { get; set; }

        public int AccountScore { get; set; }
    }
}
