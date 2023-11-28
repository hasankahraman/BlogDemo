using BlogDemo.API.DataAccessLayer;
using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.ViewComponents.Writer
{
    
    public class GetWriterAboutsForDashboard : ViewComponent
    {
        WriterManager manager = new WriterManager(new EFWriterDAL());
        private readonly UserManager<AppUser> _userManager;
        DataAccessLayer.Concrete.Context context = new DataAccessLayer.Concrete.Context();

        public GetWriterAboutsForDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {


            var userName = User.Identity.Name;
            ViewBag.userMail = userName;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writer = manager.GetWriterFromEmail(userMail);

            return View(writer);
        }

    }
}
