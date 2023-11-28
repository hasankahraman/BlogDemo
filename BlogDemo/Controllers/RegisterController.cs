using BlogDemo.Models;
using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public RegisterController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        //WriterManager manager = new WriterManager(new EFWriterDAL());
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Index(Writer writer)
        //{
        //    writer.Status = true;
        //    writer.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());

        //    WriterValidator validator = new WriterValidator();
        //    ValidationResult result = validator.Validate(writer);
        //    if (result.IsValid)
        //    {
        //        manager.Add(writer);
        //        return RedirectToAction("Index", "Home");
        //    }else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //        return View();
        //    }
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login", "Register");
        }
    }
}
