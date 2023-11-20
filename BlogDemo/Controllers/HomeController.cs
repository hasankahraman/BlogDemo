using BlogDemo.Models;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.TotalBlogs = blogManager.GetAll().Count;
            ViewBag.AuthorsTotalBlogs = blogManager.GetByAuthor(1).Count;
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
