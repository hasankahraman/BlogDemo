using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    
    public class GetWriterAboutsForDashboard : ViewComponent
    {
        WriterManager manager = new WriterManager(new EFWriterDAL());

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;

            var writer = manager.GetWriterFromEmail(userMail);
            return View(writer);
        }

    }
}
