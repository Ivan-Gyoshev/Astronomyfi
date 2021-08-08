namespace Astronomyfi.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Users;

    public interface IUsersService
    {
        TModel GetUser<TModel>(string userId);

        IEnumerable<TModel> GetAllUsers<TModel>();

        Task BanUserAsync(string userId);

        ApplicationUser GetUser(string userId);

        Task UpdateAvatarAsync(EditAvatarViewModel input);
    }
}
