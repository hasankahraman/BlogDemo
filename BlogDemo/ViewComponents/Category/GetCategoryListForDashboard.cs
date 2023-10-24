using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Category
{
    public class GetCategoryListForDashboard : ViewComponent
    {
        CategoryManager manager = new CategoryManager(new EFCategoryDAL());

        public IViewComponentResult Invoke()
        {
            var categories = manager.GetAll();
            return View(categories);
        }
    }
}
