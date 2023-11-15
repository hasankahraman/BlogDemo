using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticsThird : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        CommentManager commentManager = new CommentManager(new EFCommentDAL());
        public IViewComponentResult Invoke()
        {
            ViewBag.LatestBlogName = blogManager.GetLatest3Blogs().OrderByDescending(x => x.CreatedAt).FirstOrDefault().Title;
            ViewBag.LatestBlogDesc = blogManager.GetLatest3Blogs().OrderByDescending(x => x.CreatedAt).FirstOrDefault().Content.Substring(0, 25);
            ViewBag.TotalComments = commentManager.GetAll().Count;
            return View();
        }
    }
}
