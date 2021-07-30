namespace Astronomyfi.Data.Models.Common
{
    public static class DataConstants
    {
        // Category constants
        public const int CategoryMinLength = 4;
        public const int CategoryMaxLength = 50;

        public const int CategoryDescriptionMinLength = 10;
        public const int CategoryDescriptionMaxLength = 100;

        // Post Constants
        public const int PostTitleMinLength = 3;
        public const int PostTitleMaxLength = 25;

        public const int PostContentMinLength = 10;
        public const int PostContentMaxLength = 600;

        // Comments Constants
        public const int CommentMinLength = 2;
        public const int CommentMaxLength = 150;

        // Users
        public const int UsernameMinLength = 6;
        public const int UsernameMaxLength = 20;
    }
}
