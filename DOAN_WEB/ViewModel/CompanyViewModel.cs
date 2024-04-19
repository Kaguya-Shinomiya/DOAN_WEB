using DOAN_WEB.Models;

namespace DOAN_WEB.ViewModel
{
	public class CompanyViewModel
	{
		public List<User>? User { get; set; }
		public User User1 { get; set; }
		public List<Document>? Document { get; set; }
		public List<Company>? Company { get; set; }
		public string? DocName { get; set; }
		public int CurrentPage { get; set; } // Trang hiện tại
		public int TotalPages { get; set; } // Tổng số trang
	}
}
