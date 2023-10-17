using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Blog
{
    public class GetOtherBlogsOfAuthor : ViewComponent
    {
        BlogManager manager = new BlogManager(new EFBlogDAL());
        public IViewComponentResult Invoke()
        {
            var blogs = manager.GetByAuthor(1);
            return View(blogs);
        }
    }
}
