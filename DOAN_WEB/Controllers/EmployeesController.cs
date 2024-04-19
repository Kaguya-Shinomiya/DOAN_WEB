using DOAN_WEB.Models;
using DOAN_WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace DOAN_WEB.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly MhDaWContext _context;
		public EmployeesController(MhDaWContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Employees()
		{
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var chucvus = await _context.ChucVus.ToListAsync();
			var teams = await _context.Teams.ToListAsync();
			var userteams = await _context.UserTeams.ToListAsync();
			var viewModel = new EmployeesViewModel
			{
				User = users,
				ChucVu = chucvus,
				Team = teams,
				UserTeam = userteams,
			};
			return View(viewModel);
		}
		public IActionResult EmployeeTeam()
		{
			return View();
		}
		public async Task<IActionResult> EmployeeOffice()
		{
			var company = await _context.Companies.ToListAsync();
			var viewModel = new EmployeesViewModel
			{
				Company = company,
			};
			return View(viewModel);
		}
		public async Task<IActionResult> AddEmployee()
		{
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var chucvus = await _context.ChucVus.ToListAsync();
			var teams = await _context.Teams.ToListAsync();
			var userteams = await _context.UserTeams.ToListAsync();
			var company = await _context.Companies.ToListAsync();
			var viewModel = new EmployeesViewModel
			{
				User = users,
				ChucVu = chucvus,
				Team = teams,
				UserTeam = userteams,
				Company = company,
			};
			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> AddEmployee(User u)
		{
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			if(u != null)
			{
				var tmp = u.UserName;
				u.IdUser = users.Count();
				u.LineManager = 0;
				u.PasswordUser = BCrypt.Net.BCrypt.HashPassword("Aa12345678");
				u.ImgUser = "null_user.png";
				u.IsDelete = false;
				await _context.AddAsync(u);
				await _context.SaveChangesAsync();

			}
			return View(u);
		}
		public IActionResult EmployeeGrid()
		{
			return View();
		}
	}
}
