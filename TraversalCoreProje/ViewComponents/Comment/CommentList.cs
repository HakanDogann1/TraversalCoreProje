using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.Comment
{
    public class CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;
        
        public CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            using var context = new Context();
            ViewBag.v1=context.Comments.Where(x=>x.DestinationID==id).Count();
            var values = _commentService.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
