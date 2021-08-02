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

        [Authorize]
        public async Task<IActionResult> Edit(int postId, int commentId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var commentModel = this.commentsService.GetById(postId, commentId);

            if (commentModel.AuthorId != user.Id)
            {
                return this.Unauthorized();
            }

            var comment = this.commentsService.GetById<EditCommentViewModel>(postId, commentId);

            return this.View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCommentViewModel comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(comment);
            }

            await this.commentsService.EditCommentAsync(
                comment.Content,
                comment.PostId,
                comment.Id);

            return this.RedirectToAction("Details", "Posts", new { postId = comment.PostId });
        }

        public async Task<IActionResult> Delete(int postId, int commentId)
        {
            var commentModel = this.commentsService.GetById(postId, commentId);

            if (commentModel == null)
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            if (user.Id != commentModel.AuthorId)
            {
                return this.Unauthorized();
            }

            var post = this.commentsService.GetById<DeleteCommentViewModel>(postId, commentId);

            return this.View(post);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(int postId, int commentId)
        {
            await this.commentsService.DeleteCommentAsync(postId, commentId);

            return this.RedirectToAction("Details", "Posts", new { postId = postId });
        }
    }
}
