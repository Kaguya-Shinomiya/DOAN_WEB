using DOAN_WEB.Models;
using DOAN_WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DOAN_WEB.Controllers
{
	public class CalendarController : Controller
	{
		private readonly MhDaWContext _context;
		public CalendarController(MhDaWContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Calendar()
		{
			var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
			var userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
			//var chucvus = await _context.ChucVus.ToListAsync();
			var viewModel = new CalendarViewModel
			{
				User = users,
			};
			if (User.Identity.IsAuthenticated && userEmailClaim != null)
			{
				User s = await _context.Users.FirstOrDefaultAsync(m => m.EmailUser.Equals(User.FindFirst(ClaimTypes.Email).Value));
				if (s != null)
				{
					int user_id = s.IdUser;
					var calendar = await _context.Calendars.Where(t => t.IdUser == user_id).ToListAsync();
					viewModel = new CalendarViewModel
					{
						Calendars = calendar,
						User = users,
					};

					var defaultEvents = new List<object>();
					if (calendar.Count() != 0)
					{
						foreach (var item in calendar)
						{
							var eventObject = new
							{
								//id = item.IdCal,
								title = item.CalName,
								start = DateTime.Parse(item.CalDate?.ToString("dd/MM/yyyy HH:mm:ss")), // Đảm bảo rằng Start có định dạng hợp lệ để chuyển đổi thành Date
								className = item.CalType
							};

							defaultEvents.Add(eventObject);
						}
						//Console.WriteLine(defaultEvents);
						//ViewBag.EventData = new JavaScriptSerializer().Serialize(eventData);
						ViewBag.DefaultEventsJson = JsonConvert.SerializeObject(defaultEvents.ToArray()); // Gán giá trị JSON cho ViewBag.DefaultEventsJson
					}
					else
					{
						ViewBag.DefaultEventsJson = JsonConvert.SerializeObject("");  // Đảm bảo rằng ViewBag.DefaultEventsJson là rỗng nếu calendar là rỗng
					}
				}
				else
				{
					return NotFound();
					
				}
			}
			return View(viewModel);
		}
		[HttpPost]
		public IActionResult Move_Event(Calendar c)
		{
			if (c != null)
			{
				/*string s = c.IdCal.ToString();
				if (_context.Calendars.Any(t => t.CalDate == DateTime.Parse(s.Substring(0, s.IndexOf(" "))) && t.CalName == s.Substring(s.IndexOf(" ") + 1)))
				{
					var Cal = _context.Calendars.FirstOrDefault(t => t.CalDate == DateTime.Parse(s.Substring(0, s.IndexOf(" "))) && t.CalName == s.Substring(s.IndexOf(" ") + 1));
					if (ModelState.IsValid)
					{
						c.IdCal = Cal.IdCal;
						c.IdUser = Cal.IdUser;
						c.CalType = c.CalType;
						_context.Calendars.Update(c);
						_context.SaveChanges();
						return RedirectToAction("Calendar");
					}
				}*/
				return RedirectToAction("Login", "User");
			}
			return RedirectToAction("Employees", "Employees");
		}

		[HttpPost]
		public async Task<IActionResult> Add_Event(Calendar c)
		{
			try
			{
				var user = await _context.Users.FirstOrDefaultAsync(m => m.EmailUser.Equals(User.FindFirst(ClaimTypes.Email).Value));
				//var d = User.FindFirst(ClaimTypes.Email).Value;
				if (c != null && c.CalDate != null && user != null)
				{
					if (!_context.Calendars.Any(t => t.CalDate == c.CalDate && t.CalName == c.CalName && t.CalType == c.CalType))
					{
						
						c.CalDate = DateTime.Parse(c.CalDate.ToString().Replace("{", "").Replace("}", "")).AddHours(7);
						var cal_id = await _context.Calendars.Select(t => t.IdCal).ToListAsync();
						if (cal_id.Count > 0)
							c.IdCal = cal_id.Max() + 1;
						else
							c.IdCal = 0;
						c.IdUser = user.IdUser;
						await _context.Calendars.AddAsync(c);
						await _context.SaveChangesAsync();
					}
				}
			}
			catch (Exception ex)
			{
				// Xử lý ngoại lệ ở đây
				Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
			}
			return View(c);
		}

		[HttpPost]
		public IActionResult Delete_Event(string id)
		{
			int id_cal = Int32.Parse(id.Substring(id.IndexOf("c")+1));
			var item = _context.Calendars.FirstOrDefault(p => p.IdCal == id_cal-1);
			if (item == null)
			{
				return NotFound();
			}
			_context.Calendars.Remove(item); // Xóa tài liệu từ cơ sở dữ liệu
			_context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
			return RedirectToAction("Calendar"); // Trả về mã thành công
		}
		[HttpPost]
		public IActionResult Update_Event(Calendar c, string id)
		{
			int id_cal = Int32.Parse(id.Substring(id.IndexOf("c") + 1))-1;
			if (c != null /*&& _context.Calendars.Any(t => t.IdCal == c.IdCal)*/)
			{

				var cal = _context.Calendars.FirstOrDefault(t => t.IdCal == id_cal);
				if (cal != null) {
					cal.CalName = c.CalName;
					// Kiểm tra xem dữ liệu đã được binding thành công chưa
					//if (ModelState.IsValid)
					//{
						// Cập nhật thông tin của công ty
						_context.Calendars.Update(cal);
						_context.SaveChanges(); // Sử dụng SaveChanges() thay vì SaveChangesAsync()

						// Chuyển hướng sau khi cập nhật thành công
						return RedirectToAction("Calendar");
					//}
				}
			}
			// Trả về view nếu có lỗi xảy ra hoặc không tìm thấy đối tượng cần cập nhật
			return View(c);
		}
	}
}
/*
 
					var dateTime = new Date(start);

					// Lấy thông tin về ngày, tháng và năm
					var day = dateTime.getDate();
					var month = dateTime.getMonth() + 1; // Lưu ý: Tháng trong JavaScript bắt đầu từ 0, nên cần cộng thêm 1
					var year = dateTime.getFullYear();

					var parts = next_title.split(/[\s/:]+/); // Tách chuỗi thành các phần bằng khoảng trắng, dấu hai chấm (:), dấu gạch chéo (/)
					// parts sẽ chứa mảng các phần tử ['19', '4', '2024', '16', '55', '00']

					// Lấy các phần tử từ mảng parts
					//var day = parseInt(parts[0]);
					//var month = parseInt(parts[1]) - 1; // Giảm đi 1 vì tháng trong JavaScript bắt đầu từ 0 (0 - 11)
					//var year = parseInt(parts[2]);
					var hour = parseInt(parts[0]);
					var minute = parseInt(parts[1]);
					//var second = parseInt(parts[5]);

					// Tạo đối tượng Date
					var dateTime = new Date(year, month, day, hour, minute, 0);

					// Tạo định dạng mới "Ngày/Tháng/Năm"
					//var formattedDate = day + '/' + month + '/' + year;


					var formData = new FormData();

					// Lấy giá trị từ các input và thêm vào formData
					formData.append('CalName', title);
					formData.append('CalDate', dateTime.toISOString());
					formData.append('CalType', categoryClass);

					// Gửi AJAX request với dữ liệu formData
					$.ajax({
						url: '/Calendar/Add_Event', // Địa chỉ xử lý yêu cầu AJAX
						type: 'POST',
						data: formData,
						contentType: false,
						processData: false,
						success: function (result) {
							//$('#addcompany').modal('hide'); // Ẩn modal sau khi thêm thành công
							//window.location.reload(); // Tải lại trang sau khi thêm thành công
							//alert("Thành công");
						},
						error: function (xhr, status, error) {
							// Xử lý lỗi nếu có
						}
					});
 
 */