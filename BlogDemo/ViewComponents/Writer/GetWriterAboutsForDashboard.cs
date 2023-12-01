using BlogDemo.API.DataAccessLayer;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.ViewComponents.Writer
{
    public class GetWriterAboutsForDashboard : ViewComponent
    {
        WriterManager manager = new WriterManager(new EFWriterDAL());
        DataAccessLayer.Concrete.Context context = new DataAccessLayer.Concrete.Context();
        public IViewComponentResult Invoke()
        {

            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writer = manager.GetWriterFromEmail(userMail);

            return View(writer);
        }

    }
}
