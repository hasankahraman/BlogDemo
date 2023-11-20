using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogDemo.Controllers
{
	public class NewsletterController : Controller
	{
		NewsletterManager manager = new NewsletterManager(new EFNewsletterDAL());
		[HttpGet]
		public PartialViewResult PVSignUpForNewsletter()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult PVSignUpForNewsletter(Newsletter newsletter)
		{
			newsletter.Status = true;
			newsletter.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());

			manager.Add(newsletter);
			return PartialView();
		}

	}
}
