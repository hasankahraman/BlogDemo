using BlogDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = user.Email,
                    UserName = user.Username,
                    NameSurname = user.NameSurname,

                };

                var result = await _userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Register");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(user);
        }
    }
}
