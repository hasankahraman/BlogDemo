using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
