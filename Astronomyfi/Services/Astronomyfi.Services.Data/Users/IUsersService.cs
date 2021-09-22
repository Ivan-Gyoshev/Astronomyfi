namespace Astronomyfi.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Users;

    public interface IUsersService
    {
        Task UpdateAvatarAsync(EditAvatarViewModel input);

        Task DeleteUserAsync(string userId);

        TModel GetUser<TModel>(string userId);

        IEnumerable<TModel> GetAllUsers<TModel>();

        ApplicationUser GetUser(string userId);
    }
}
