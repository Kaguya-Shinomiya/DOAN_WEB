using DOAN_WEB.Models;
using DOAN_WEB.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Security.Claims;


namespace DOAN_WEB.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly MhDaWContext _context;
        public EmployeeManagementController(MhDaWContext context)
        {
			_context = context;
        }

        public async Task<IActionResult> Index()//Dashboard
        {
			var user = await _context.Users.FirstOrDefaultAsync(m => m.EmailUser.Equals(User.FindFirst(ClaimTypes.Email).Value));
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var chucvus = await _context.ChucVus.ToListAsync();
			var teams = await _context.Teams.ToListAsync();
			var userteams = await _context.UserTeams.ToListAsync();
			var viewModel = new HomeViewModel
			{
				User1 = user,
				User = users,
				ChucVu = chucvus,
				Team = teams,
				UserTeam = userteams,
			};
			return View(viewModel);
        }

		public async Task<IActionResult> IndexEmployee()
		{
			var user = await _context.Users.FirstOrDefaultAsync(m => m.EmailUser.Equals(User.FindFirst(ClaimTypes.Email).Value));
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var chucvus = await _context.ChucVus.ToListAsync();
			var teams = await _context.Teams.ToListAsync();
			var userteams = await _context.UserTeams.ToListAsync();
			var viewModel = new HomeViewModel
			{
				User1 = user,
				User = users,
				ChucVu = chucvus,
				Team = teams,
				UserTeam = userteams,
			};
			return View(viewModel);
		}

		public IActionResult SuperAdmin()
		{
			return View();
		}
		
		
		public IActionResult Activities()
		{
			return View();
		}
	}
}
