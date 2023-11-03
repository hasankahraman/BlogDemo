using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        NotificationManager manager = new NotificationManager(new EFNotificationDAL());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotifications()
        {
            var notifs = manager.GetAll();
            return View(notifs);
        }
    }
}
