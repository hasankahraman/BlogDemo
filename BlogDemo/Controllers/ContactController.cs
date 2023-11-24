using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager manager = new ContactManager(new EFContactDAL());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.Status = true;
            contact.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            manager.Add(contact);
            return RedirectToAction("Index");
        }
    }
}
