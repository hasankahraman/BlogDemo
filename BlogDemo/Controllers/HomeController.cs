using BlogDemo.Models;
using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        Context context = new Context();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writer = writerManager.GetWriterFromEmail(usermail);

            ViewBag.TotalBlogs = blogManager.GetAll().Count;
            ViewBag.AuthorsTotalBlogs = blogManager.GetByAuthor(writer.Id).Count;
            ViewBag.TotalCategories = categoryManager.GetAll().Count;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
    }
}
