using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticsBottom : ViewComponent
    {
        AdminManager manager = new AdminManager(new EFAdminDAL());
        AppUserManager AppUserManager = new AppUserManager(new EFAppUserDAL());
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        CommentManager commentManager = new CommentManager(new EFCommentDAL());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            int writerId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var admin = AppUserManager.GetById(writerId);
            ViewBag.AdminName = admin.NameSurname;
            ViewBag.AdminDesc = admin.Email;
            ViewBag.AdminImage = admin.ImageUrl;
            return View();
        }
    }
}
