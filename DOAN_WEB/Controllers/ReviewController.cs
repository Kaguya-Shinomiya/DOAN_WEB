using Microsoft.AspNetCore.Mvc;

namespace 
	Controllers
{
	public class ReviewController : Controller
	{
		public IActionResult Review()
		{
			return View();
		}
		public IActionResult ReviewType()
		{
			return View();
		}
		public IActionResult AddReview()
		{
			return View();
		}
	}
}
