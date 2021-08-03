namespace Astronomyfi.Web.ViewModels.Users
{
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Mapping;

    public class UsersDetailsViewModel : IMapFrom<ForumUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string AvatarImgUrl { get; set; }

        public int AccountScore { get; set; }

        public int PostsCount { get; set; }

        public int CommentsCount { get; set; }
    }
}
