using Microsoft.AspNetCore.Mvc;

namespace DOAN_WEB.Controllers
{
	public class SettingsController : Controller
	{
		public IActionResult Settings()
		{
			return View();
		}
		public IActionResult SettingsTimeoff()
		{
			return View();
		}
	}
}
