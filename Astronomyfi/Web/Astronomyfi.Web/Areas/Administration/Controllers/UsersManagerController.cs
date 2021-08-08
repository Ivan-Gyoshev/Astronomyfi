namespace Astronomyfi.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Users;
    using Astronomyfi.Web.ViewModels.Administration.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersManagerController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersManagerController(IUsersService usersService, UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var users = this.usersService.GetAllUsers<UsersListingViewModel>();

            return this.View(users);
        }

        public async Task<IActionResult> Ban(string userId)
        {
            await this.usersService.BanUserAsync(userId);

            return this.RedirectToAction("All");
        }
    }
}
