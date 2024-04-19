using DOAN_WEB.Models;

namespace DOAN_WEB.ViewModel
{
	public class EmployeesViewModel
	{
		public List<User>? User { get; set; }
		//public List<UserRole>? UserRole { get; set; }
		public List<UserTeam>? UserTeam { get; set; }
		public List<Team>? Team { get; set; }
		public List<ChucVu>? ChucVu { get; set; }
		public List<Company>? Company { get; set; }
	}
}
