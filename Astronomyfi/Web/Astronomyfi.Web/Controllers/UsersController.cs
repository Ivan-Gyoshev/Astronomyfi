namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Users;
    using Astronomyfi.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(IUsersService usersService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> AccountDetails()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var userView = this.usersService.GetUser<UsersDetailsViewModel>(currentUser.Id);

            return this.View(userView);
        }

        public async Task<IActionResult> EditAvatar()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var userView = this.usersService.GetUser<EditAvatarViewModel>(user.Id);

            return this.View(userView);
        }

        [HttpPost]
        public async Task<IActionResult> EditAvatarConfirm(EditAvatarViewModel input)
        {
            var user = this.usersService.GetUser(input.Id);

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.EditAvatar));
            }

            await this.usersService.UpdateAvatarAsync(input);

            return this.RedirectToAction("AccountDetails", "Users", new { userId = input.Id });
        }

        public async Task<IActionResult> Delete()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var userView = this.usersService.GetUser<UsersDetailsViewModel>(currentUser.Id);

            return this.View(userView);
        }
    }
}
