using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticsMain: ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        CommentManager commentManager = new CommentManager(new EFCommentDAL());
        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlogs = blogManager.GetAll().Count;
            ViewBag.TotalContact = contactManager.GetAll().Count;
            ViewBag.TotalComments = commentManager.GetAll().Count;
            return View();
        }
    }
}
