using Microsoft.AspNetCore.Mvc;

namespace QLLuong.Controllers
{
	public class LuongController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
