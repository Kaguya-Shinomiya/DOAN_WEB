using DOAN_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Controllers
{
	public class ProfileController : Controller
	{
		private readonly MhDaWContext _context;
		public ProfileController(MhDaWContext context)
		{
			_context = context;
		}
		public IActionResult Profile()
		{
			return View();
		}
		public IActionResult ProfileReview()
		{
			return View();
		}
		public IActionResult ProfileDetail()
		{
			return View();
		}
		public IActionResult ProfileDocument()
		{
			return View();
		}
		public IActionResult ProfileCreatedocument()
		{
			return View();
		}
		public IActionResult ProfilePayroll()
		{
			return View();
		}
		public IActionResult ProfileTimeoff()
		{
			return View();
		}

		public IActionResult ProfileSetting()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Change_Pass(string s, string s1)
		{
			var user = await _context.Users.FirstOrDefaultAsync(m => m.EmailUser.Equals(User.FindFirst(ClaimTypes.Email).Value) );
			if(user != null && BCrypt.Net.BCrypt.Verify(s1, user.PasswordUser))
			{
				user.PasswordUser = BCrypt.Net.BCrypt.HashPassword(s);
				_context.Update(user);
				_context.SaveChanges();
				if (User.Identity.IsAuthenticated)
				{
					return RedirectToAction("Login", "User");
				}
			}
			return RedirectToAction("ProfileSetting", "Profile");
		}
	}
}
