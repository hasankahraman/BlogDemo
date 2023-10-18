using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error(int code)
		{
			return View();
		}
	}
}
