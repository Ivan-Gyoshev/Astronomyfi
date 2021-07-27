namespace Astronomyfi.Web.Controllers
{
    using System.Threading.Tasks;

    using Astronomyfi.Data.Models;
    using Astronomyfi.Services.Data;
    using Astronomyfi.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentViewModel comment)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                return this.RedirectToAction("Details", "Posts", new { postId = comment.PostId });
            }

            await this.commentsService.CreateCommentAsync(comment.Content, user.Id, comment.PostId);

            return this.RedirectToAction("Details", "Posts", new { postId = comment.PostId });
        }
    }
}
