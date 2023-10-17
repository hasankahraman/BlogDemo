using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

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
		[HttpGet]
		public IActionResult PVAddComment()
		{
			return View();
		}
		[HttpPost]
		public PartialViewResult PVAddComment(Comment comment)
		{
			comment.Status = true;
			comment.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.BlogId = 9;

			manager.Add(comment);
			return PartialView();
		}
	}
}
