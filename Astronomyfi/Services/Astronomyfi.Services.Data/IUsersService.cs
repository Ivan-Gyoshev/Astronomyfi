namespace Astronomyfi.Services.Data
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Web.ViewModels.Users;

    public interface IUsersService
    {
        TModel GetUser<TModel>(string userId);

        ApplicationUser GetUser(string userId);

        Task UpdateAvatarAsync(EditAvatarViewModel input);
    }
}
