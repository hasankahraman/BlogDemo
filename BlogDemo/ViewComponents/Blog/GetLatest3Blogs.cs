using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Blog
{
    public class GetLatest3Blogs : ViewComponent
    {
        BlogManager manager = new BlogManager(new EFBlogDAL());
        public IViewComponentResult Invoke()
        {
            var blogs = manager.GetLatest3Blogs();
            return View(blogs);
        }
    }
}
