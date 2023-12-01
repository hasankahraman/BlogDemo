using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager manager = new CommentManager(new EFCommentDAL());
        public IActionResult Index()
        {
            var comments = manager.GetWithBlog();
            return View(comments);
        }
    }
}
