using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	public class ManageController : Controller
	{
		public IActionResult Manage()
		{
			return View();
		}
		public IActionResult LeadershipManage()
		{
			return View();
		}

		public IActionResult SuperAdmin()
		{
			return View();
		}
	}
}
