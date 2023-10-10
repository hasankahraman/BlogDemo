using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager manager = new CategoryManager(new EFCategoryDAL());
        public IActionResult Index()
        {
            var categories = manager.GetAll();
            return View(categories);
        }
    }
}
