namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data;
    using Astronomyfi.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ForumsController : BaseController
    {
        private readonly ICategoriesService categoryService;
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public ForumsController(ICategoriesService categoryService, IPostsService postsService, IDeletableEntityRepository<Category> categoriesRepository, UserManager<ApplicationUser> userManager)
        {
            this.categoryService = categoryService;
            this.postsService = postsService;
            this.categoriesRepository = categoriesRepository;
            this.userManager = userManager;
        }

        public IActionResult All() => this.View();

        public IActionResult Create() => this.View(new CreatePostViewModel
        {
            Categories = this.categoryService.GetCategoriesById(),
            Types = this.postsService.GetPostTypes(),
        });

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostViewModel post)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.postsService.AddPostAsync(post, user.Id);

            return this.RedirectToAction("All", "Forums");
        }
    }
}
