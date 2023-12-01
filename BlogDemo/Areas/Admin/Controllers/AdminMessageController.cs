using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogDemo.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager manager = new MessageManager(new EFMessageDAL());
        Context context = new Context();
        public IActionResult Inbox()
        {
            int writerId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var messages = manager.GetInboxByWriter(writerId);
            return View(messages);
        }

        public IActionResult Sentbox()
        {
            int writerId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var messages = manager.GetSentboxByWriter(writerId);
            return View(messages);
        }
        [HttpGet]
        public IActionResult Compose()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Compose(Message message)
        {
            message.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Status = true;
            message.FromId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            message.ToId = 8;
            manager.Add(message);
            return RedirectToAction("Sentbox");
        }
    }
}
