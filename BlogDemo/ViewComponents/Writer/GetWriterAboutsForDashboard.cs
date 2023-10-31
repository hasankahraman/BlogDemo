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
            var abouts = manager.GetById(1);
            return View(abouts);
        }

    }
}
