using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult PVNavBar()
        {
            return PartialView();
        }
    }
}
