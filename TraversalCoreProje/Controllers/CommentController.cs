using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        [Route("Comment/AddComment/{id:int}")]
        public IActionResult AddComment(Comment comment,int id)
        {
            comment.Date = DateTime.Now;
            comment.CommentState = true;
            comment.DestinationID = id;
            _commentService.TInsert(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
