using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogDemo.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager manager = new CommentManager(new EFCommentDAL());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PVAddComment()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PVAddComment(Comment comment)
		{
			comment.Status = true;
			comment.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());

			manager.Add(comment);
			return PartialView(comment);
		}
	}
}
