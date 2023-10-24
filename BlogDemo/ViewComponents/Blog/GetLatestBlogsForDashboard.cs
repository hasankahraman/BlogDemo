using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.ViewComponents.Blog
{
    public class GetLatestBlogsForDashboard : ViewComponent
    {
        BlogManager manager = new BlogManager(new EFBlogDAL());
        public IViewComponentResult Invoke()
        {
            var blogs = manager.GetWithCategory().OrderByDescending(x=> x.CreatedAt).ToList();
            return View(blogs);
        }
    }
}
