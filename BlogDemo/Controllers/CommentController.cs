using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager manager = new CommentManager(new EFCommentDAL());
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PVCommentsOfBlogs(int blogId)
		{
			var comments = manager.GetAll(blogId);
			return PartialView(comments);
		}

		public PartialViewResult PVAddComment(int blogId)
		{
			var comments = manager.GetAll(blogId);
			return PartialView(comments);
		}
	}
}
