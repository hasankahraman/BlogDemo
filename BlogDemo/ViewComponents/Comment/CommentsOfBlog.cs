using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Comment
{
	public class CommentsOfBlog : ViewComponent
	{
		CommentManager manager = new CommentManager(new EFCommentDAL());

		public IViewComponentResult Invoke(int blogId)
		{
			var comments = manager.GetAll(blogId);
			if (comments.Count == 0)
			{
				ViewBag.nocomment = "No comments has been written. Be the first one to comment.";
			}
			return View(comments);
		}
	}
}
