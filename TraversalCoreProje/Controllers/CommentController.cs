using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        [Route("Comment/AddComment/{id:int}")]
        public async Task<IActionResult> AddComment(Comment comment,int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.Date = DateTime.Now;
            comment.CommentState = true;
            comment.AppUserID= user.Id;
            comment.DestinationID = id;
            _commentService.TInsert(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
