using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticsBottom : ViewComponent
    {
        AdminManager manager = new AdminManager(new EFAdminDAL());
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        CommentManager commentManager = new CommentManager(new EFCommentDAL());
        public IViewComponentResult Invoke()
        {
            var admin = manager.GetById(1);
            ViewBag.AdminName = admin.Name;
            ViewBag.AdminDesc = admin.Description;
            ViewBag.AdminImage = admin.ImageUrl;
            return View();
        }
    }
}
