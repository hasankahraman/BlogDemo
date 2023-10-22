using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.ViewComponents.Writer
{
    public class GetWriterNotifications : ViewComponent
    {
        //MessageManager manager = new MessageManager();
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
