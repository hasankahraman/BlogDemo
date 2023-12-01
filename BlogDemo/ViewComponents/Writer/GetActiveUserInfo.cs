using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.ViewComponents.Writer
{
    public class GetActiveUserInfo : ViewComponent
    {
        AppUserManager manager = new AppUserManager(new EFAppUserDAL());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            int writerId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var user = manager.GetById(writerId);
            return View(user);
        }
    }
}
