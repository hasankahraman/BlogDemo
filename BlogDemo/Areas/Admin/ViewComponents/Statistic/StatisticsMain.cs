﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogDemo.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticsMain: ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogDAL());
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        CommentManager commentManager = new CommentManager(new EFCommentDAL());
        public IViewComponentResult Invoke()
        {
            ViewBag.TotalBlogs = blogManager.GetAll().Count;
            ViewBag.TotalContact = contactManager.GetAll().Count;
            ViewBag.TotalComments = commentManager.GetAll().Count;

            string api = "601ef98c36e59e172130cc6ee7cfee57";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Izmir,tr&mode=xml&units=metric&lang=tr&APPID=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Degree = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
