namespace Astronomyfi.Web.ViewModels
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class AccountDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string AvatarImgUrl { get; set; }

        public int AccountScore { get; set; }
    }
}
