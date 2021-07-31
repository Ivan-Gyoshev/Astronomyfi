namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data;
    using Astronomyfi.Web.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(IUsersService usersService, UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> AccountDetails()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var userView = this.usersService.GetUser<AccountDetailsViewModel>(currentUser.Id);

            return this.View(userView);
        }
    }
}
