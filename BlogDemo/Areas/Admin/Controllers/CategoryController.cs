using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using BussinessLayer.ValidationRules;

namespace BlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager manager = new CategoryManager(new EFCategoryDAL());
        CategoryValidator validator = new CategoryValidator();
        public IActionResult Index(int page=1)
        {
            var categories = manager.GetAll().ToPagedList(page, 5);
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            FluentValidation.Results.ValidationResult result = validator.Validate(category);

            if (result.IsValid)
            {
                category.Status = true;
                category.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());

                manager.Add(category);
                return RedirectToAction("Index");
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
            var categoryToDelete = manager.GetById(id);
            manager.Delete(categoryToDelete);
            return RedirectToAction("Index");
        }
    }
}
