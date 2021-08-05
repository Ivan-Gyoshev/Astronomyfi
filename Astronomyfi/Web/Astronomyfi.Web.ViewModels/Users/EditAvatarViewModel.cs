namespace Astronomyfi.Web.ViewModels.Users
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class EditAvatarViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string AvatarImgUrl { get; set; }

        public IFormFile NewImage { get; set; }
    }
}
