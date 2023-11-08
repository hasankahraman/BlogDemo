using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{

    public class RegisterController : Controller
    {
        WriterManager manager = new WriterManager(new EFWriterDAL());
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Writer writer)
        {
            var toLogin = manager.Login(writer);

            if (toLogin == null)
            {
                return View();
            }
            else
            {
                var claims = new List<Claim> 
                { 
                    new Claim(ClaimTypes.Email, writer.Email) 
                };
                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //HttpContext.Session.SetString("username", writer.Email);
                return RedirectToAction("Index", "Writer");
            }

        }
    }
}
