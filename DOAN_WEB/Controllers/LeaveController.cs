using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
	public class LeaveController : Controller
	{
		public IActionResult Leave()
		{
			return View();
		}
	}
}
