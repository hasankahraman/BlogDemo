﻿using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogDemo.Controllers
{
    public class MessageController : Controller
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

        public IActionResult GetDetails(int id)
        {
            var message = manager.GetDetailsWithWriter(id);
            return View(message);
        }
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(Message message)
        {
            int writerId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            message.FromId = writerId;
            message.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Status = true;
            manager.Add(message);
            return RedirectToAction("Inbox");
        }
    }
}
