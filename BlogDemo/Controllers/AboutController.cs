using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	public class AboutController : Controller
	{
		AboutManager manager = new AboutManager(new EFAboutDAL());
		public IActionResult Index()
		{
			var abouts = manager.GetAll();
			return View(abouts);
		}

		public PartialViewResult PVStayConnect()
		{
			return PartialView();
		}
	}
}
