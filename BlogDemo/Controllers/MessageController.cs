using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class MessageController : Controller
    {
        MessageManager manager = new MessageManager(new EFMessageDAL());
        public IActionResult Inbox()
        {
            int writerId = 2;
            var messages = manager.GetInboxByWriter(writerId);
            return View(messages);
        }
        public IActionResult Sentbox()
        {
            int writerId = 2;
            var messages = manager.GetSentboxByWriter(writerId);
            return View(messages);
        }

    }
}
