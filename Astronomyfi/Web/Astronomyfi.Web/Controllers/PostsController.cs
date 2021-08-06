namespace Astronomyfi.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data.Categories;
    using Astronomyfi.Services.Data.Posts;
    using Astronomyfi.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICategoriesService categoryService;
        private readonly IPostsService postsService;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public PostsController(ICategoriesService categoryService, IPostsService postsService, IDeletableEntityRepository<Category> categoriesRepository, UserManager<ApplicationUser> userManager)
        {
            this.categoryService = categoryService;
            this.postsService = postsService;
            this.categoriesRepository = categoriesRepository;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var posts = this.postsService.GetAllPosts<PostListingViewModel>();
            return this.View(posts);
        }

        [Authorize]
        public IActionResult Create() => this.View(new PostFormModel
        {
            Categories = this.categoryService.GetCategoriesById<PostCategoryViewModel>(),
            Types = this.postsService.GetPostTypes(),
        });

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PostFormModel post)
        {
            if (!this.categoriesRepository.All().Any(c => c.Id == post.CategoryId))
            {
                this.ModelState.AddModelError(nameof(post.CategoryId), "Category does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                post.Categories = this.categoryService.GetCategoriesById<PostCategoryViewModel>();
                post.Types = this.postsService.GetPostTypes();

                return this.View(post);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            user.AccountScore++;

            await this.postsService.AddPostAsync(
                post.Id,
                post.Title,
                post.Content,
                post.CategoryId,
                post.Type,
                user.Id);

            return this.RedirectToAction("All", "Posts");
        }

        public async Task<IActionResult> Edit(int postId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var postModel = this.postsService.GetById(postId);

            if (postModel.AuthorId != user.Id)
            {
                return this.Unauthorized();
            }

            var post = this.postsService.GetById<PostFormModel>(postId);

            post.Types = this.postsService.GetPostTypes();
            post.Categories = this.categoryService.GetCategoriesById<PostCategoryViewModel>();

            return this.View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormModel post, int postId)
        {
            if (!this.ModelState.IsValid)
            {
                post.Categories = this.categoryService.GetCategoriesById<PostCategoryViewModel>();
                post.Types = this.postsService.GetPostTypes();

                return this.View(post);
            }

            await this.postsService.EditPostAsync(
                postId,
                post.Title,
                post.Content,
                post.CategoryId,
                post.Type);

            return this.RedirectToAction("Details", "Posts", new { postId = postId });
        }

        public async Task<IActionResult> Delete(int postId)
        {
            var postModel = this.postsService.GetById(postId);

            if (postModel == null)
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            if (user.Id != postModel.AuthorId)
            {
                return this.Unauthorized();
            }

            var post = this.postsService.GetById<PostDetailsViewModel>(postId);

            return this.View(post);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(int postId)
        {
            await this.postsService.DeletePostAsync(postId);

            return this.RedirectToAction("All", "Posts");
        }

        public IActionResult Details(int postId)
        {
            var currentPost = this.postsService.GetPost<PostDetailsViewModel>(postId);

            return this.View(currentPost);
        }
    }
}
