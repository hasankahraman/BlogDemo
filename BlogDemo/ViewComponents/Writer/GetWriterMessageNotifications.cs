using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class GetWriterMessageNotifications : ViewComponent
    {
        MessageManager manager = new MessageManager(new EFMessageDAL());
        public IViewComponentResult Invoke()
        {
            string userMail = "deve@akhisar.com";
            var inbox = manager.GetInboxByWriter(1);
            return View(inbox);
        }
    }
}
