using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents
{
	public class CommentsOfBlog : ViewComponent
	{
		CommentManager manager = new CommentManager(new EFCommentDAL());

		public IViewComponentResult Invoke()
		{
			var comments = manager.GetAll(1);
			return View(comments);
		}
	}
}
