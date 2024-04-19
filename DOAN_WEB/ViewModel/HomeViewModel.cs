using DOAN_WEB.Models;

namespace DOAN_WEB.ViewModel
{
	public class HomeViewModel
	{
		public List<Calendar>? Calendar { get; set; }
		//public List<Document>? Document { get; set; }
		public List<User>? User { get; set; }
		public User User1 { get; set; }
		public List<UserRole>? UserRole { get; set; }
		public List<UserTeam>? UserTeam { get; set; } 
		public List<Team>? Team { get; set; }
		public List<ChucVu>? ChucVu { get; set; }
	}
}
