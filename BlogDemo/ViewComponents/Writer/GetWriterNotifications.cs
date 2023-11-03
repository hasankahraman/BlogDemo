using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class GetWriterNotifications : ViewComponent
    {
        NotificationManager manager = new NotificationManager(new EFNotificationDAL());
        public IViewComponentResult Invoke()
        {
            var notifications = manager.GetAll();
            return View(notifications);
        }
    }
}
