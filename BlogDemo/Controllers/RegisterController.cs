using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager manager = new WriterManager(new EFWriterDAL());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            writer.Status = true;
            writer.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());


            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                manager.Add(writer);
                return RedirectToAction("Index", "Blog");
            }else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Writer writer)
        {
            var toLogin = manager.Login(writer);

            if (toLogin == null)
            {
                return View();
            }else
            {
                return RedirectToAction("Index", "Blog");
            }

        }
    }
}
