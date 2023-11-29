using BlogDemo.Models;
using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    public class WriterController : Controller
	{
		WriterManager manager = new WriterManager(new EFWriterDAL());
		//AppUserManager userManager = new AppUserManager(new EFAppUserDAL());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        Context context = new Context();

        [Authorize]
        public IActionResult Index()
		{
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;

            var writer = manager.GetWriterFromEmail(userMail);
            ViewBag.userName = writer.Name;
            return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult PVLeftMenu()
		{
			return PartialView();
		}
        public IActionResult PVWriterFooter()
        {
            return PartialView();
        }
		[HttpGet]
		public async Task<IActionResult> UpdateWriter()
		{
            //var userName = User.Identity.Name;
            //var usermail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerToUpdate = userManager.GetAll().Where(x=> x.Email == usermail).FirstOrDefault();

            var writer = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserUpdateViewModel model = new AppUserUpdateViewModel();
            model.Email = writer.Email;
            model.NameSurname = writer.NameSurname;
            model.ImageUrl = writer.ImageUrl;
            //model.Password = writer.PasswordHash;
            return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> UpdateWriter(AppUserUpdateViewModel model)
        {
            //WriterValidator validator = new WriterValidator();
            //ValidationResult result = validator.Validate(writer);

            //if (result.IsValid)
            //{
            //	writer.Image = writer.Image;
            //	manager.Update(writer);
            //	return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //	foreach (var item in result.Errors)
            //	{
            //		ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //             }
            //             return View();
            //         }


            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.Email;
            values.NameSurname = model.NameSurname;
            values.ImageUrl = model.ImageUrl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Home");

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
