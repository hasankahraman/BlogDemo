﻿using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlogDemo.Controllers
{
    public class BlogController : Controller
    {
		BlogManager manager = new BlogManager(new EFBlogDAL());
		CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());

		BlogValidator validator = new BlogValidator();

		[AllowAnonymous]
        public IActionResult Index()
        {
			var blogs = manager.GetWithCategory();
            return View(blogs);
        }

        public PartialViewResult PVHeader()
        {
            return PartialView();
        }
		public PartialViewResult PVFooter()
		{
			return PartialView();
		}
		public PartialViewResult PvSign()
		{
			return PartialView();
		}
		public PartialViewResult PVSocial()
		{
			return PartialView();
		}
		public IActionResult GetDetails(int id)
		{
			var blog = manager.GetById(id);
			return View(blog);
		}
		public IActionResult GetBlogsOfWriter()
		{
			var blogs = manager.GetWithCategoryByWriter(1);
			return View(blogs);
		}
		[HttpGet]
		public IActionResult Add()
		{
			List<SelectListItem> categories = (from x in categoryManager.GetAll().ToList()
											   select new SelectListItem
											   {
												   Text = x.Name,
												   Value = x.Id.ToString(),
											   }).ToList();
			ViewBag.Categories = categories;
			return View();
		}
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            FluentValidation.Results.ValidationResult result = validator.Validate(blog);

			if (result.IsValid)
			{
				blog.Status = true;
				blog.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
				blog.WriterId = 1;

				manager.Add(blog);
				return RedirectToAction("GetBlogsOfWriter", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
            return View();
        }

		public IActionResult Delete(int id)
		{
			var blogToDelete = manager.GetById(id);
			manager.Delete(blogToDelete);
			return RedirectToAction("GetBlogsOfWriter", "Blog");
		}

        [HttpGet]
        public IActionResult Update(int id)
        {
            var blogToUpdate = manager.GetById(id);
            List<SelectListItem> categories = (from x in categoryManager.GetAll().ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString(),
                                               }).ToList();
            ViewBag.Categories = categories;
            return View(blogToUpdate);
        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            FluentValidation.Results.ValidationResult result = validator.Validate(blog);

            if (result.IsValid)
            {
    //            blog.Status = true;
				blog.WriterId = 1;
				//blog.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());

                manager.Update(blog);
                return RedirectToAction("GetBlogsOfWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


    }
}
