using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class BlogController : Controller
    {
		BlogManager manager = new BlogManager(new EFBlogDAL());
        public IActionResult Index()
        {
			var blogs = manager.GetWithCategory();
            return View(blogs);
        }

        public PartialViewResult PVHeader()
        {
            return PartialView();
        }
		public PartialViewResult PVFooter()
		{
			return PartialView();
		}
		public PartialViewResult PvSign()
		{
			return PartialView();
		}
		public PartialViewResult PVSocial()
		{
			return PartialView();
		}
		public IActionResult GetDetails(int id)
		{
			var blog = manager.GetById(id);
			return View(blog);
		}
	}
}
