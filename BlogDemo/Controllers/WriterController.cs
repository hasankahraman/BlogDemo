using BlogDemo.Models;
using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
	{
		WriterManager manager = new WriterManager(new EFWriterDAL());

        [AllowAnonymous]
        public IActionResult Index()
		{
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult PVLeftMenu()
		{
			return PartialView();
		}
        [AllowAnonymous]
        public IActionResult PVWriterFooter()
        {
            return PartialView();
        }
		[HttpGet]
		public IActionResult UpdateWriter()
		{
			var writer = manager.GetById(1);
			return View(writer);
		}
        [HttpPost]
        public IActionResult UpdateWriter(Writer writer)
        {
			WriterValidator validator = new WriterValidator();
			ValidationResult result = validator.Validate(writer);

			if (result.IsValid)
			{
				writer.Image = writer.Image;
				manager.Update(writer);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(ProfileImage profileImage)
        {
            Writer writer = new Writer();
            writer.Name = profileImage.Name;
            writer.About = profileImage.About;
            writer.Title = profileImage.Title;
            writer.Email = profileImage.Email;
            writer.Password = profileImage.Password;

            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);

            if (profileImage.Image != null)
            {
                var extension = Path.GetExtension(profileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                profileImage.Image.CopyTo(stream);
                
                
                writer.Image = newImageName;
                writer.Status = true;
                writer.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
                
                manager.Add(writer);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
