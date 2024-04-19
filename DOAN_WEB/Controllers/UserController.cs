using DOAN_WEB.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.Scripting;
using System.Security.Claims;
using DOAN_WEB.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DOAN_WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly MhDaWContext _context;
        public UserController(MhDaWContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
            var chucvus = await _context.ChucVus.ToListAsync();
            var viewModel = new UserViewModel
            {
                User = users,
                ChucVu = chucvus,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
            var chucvus = await _context.ChucVus.ToListAsync();
            var viewModel = new UserViewModel
            {
                User = users,
                ChucVu = chucvus,
                Register = model.Register,
            };
            if (model.Register != null)
            {
				var users1 = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
				var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailUser.Trim() == model.Register.EmailUser.Trim());
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Register.PasswordUser, user.PasswordUser))
                {
                    var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Email, user.EmailUser),//Email
                         new Claim(ClaimTypes.Role, user.MaCvNavigation.Permission.ToString()),//Quyền
                         new Claim(ClaimTypes.Uri, user.ImgUser.ToString()), // Hình ảnh
                         new Claim(ClaimTypes.Name, user.UserName),
                         //new Claim(ClaimTypes, )
                    };
                    var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),authProperties);
					return RedirectToAction("Index", "EmployeeManagement");
				}
                else
                {
                    ViewBag.ErrorMessage = "Email hoặc mật khẩu không đúng.";
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

		public async Task<IActionResult> Register()
		{
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var chucvus = await _context.ChucVus.ToListAsync();
			var viewModel = new UserViewModel
			{
				User = users,
				ChucVu = chucvus,
			};
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserViewModel model)
		{
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var chucvus = await _context.ChucVus.ToListAsync();
			var viewModel = new UserViewModel
			{
				User = users,
				ChucVu = chucvus,
				Register = model.Register,
			};
			if (model.Register != null)
			{
				var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Trim() ==model.Register.UserName.Trim());
				if (existingUser != null)
				{
					ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
					return View(viewModel);
				}
                model.Register.IdUser = users.Count();
				model.Register.PasswordUser = BCrypt.Net.BCrypt.HashPassword(model.Register.PasswordUser);
				model.Register.MaCv = 6;
				model.Register.IsDelete = false;
                model.Register.ImgUser = "null_user.png";
				_context.Users.Add(model.Register);
				await _context.SaveChangesAsync();
				return RedirectToAction("Login", "User");
			}
			return View(viewModel);
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "User");
		}
		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}
