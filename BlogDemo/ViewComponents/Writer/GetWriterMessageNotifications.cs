﻿using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.ViewComponents.Writer
{
    public class GetWriterMessageNotifications : ViewComponent
    {
        MessageManager manager = new MessageManager(new EFMessageDAL());
        Context context = new Context();

        public IViewComponentResult Invoke()
        {
            int writerId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var inbox = manager.GetInboxByWriter(writerId);
            return View(inbox);
        }
    }
}
