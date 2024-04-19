using DOAN_WEB.Models;
using DOAN_WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace DOAN_WEB.Controllers
{
	public class CompanyController : Controller
	{
		private readonly MhDaWContext _context;
		public CompanyController(MhDaWContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Company(int page = 1)
		{
            var users = await _context.Users.Where(m => m.IsDelete == false).ToListAsync();
            var document = await _context.Documents.ToListAsync();

            int pageSize = 1; // Chỉ hiển thị một công ty trên mỗi trang

            int totalCount = await _context.Companies.CountAsync(); // Tổng số công ty trong cơ sở dữ liệu
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize); // Tổng số trang

            var companies = await _context.Companies
                .Skip((page - 1) * pageSize) // Bỏ qua các công ty trên các trang trước đó
                .Take(pageSize) // Lấy một công ty trên trang hiện tại
                .ToListAsync(); // Sử dụng ToListAsync để tránh blocking

            var viewModel = new CompanyViewModel
            {
                User = users,
                Document = document,
                Company = companies,
                CurrentPage = page,
                TotalPages = totalPages
            };
            return View(viewModel);
        }
		[HttpPost]
		public async Task<IActionResult> Add_Document(Document d, IFormFile DocName)
		{
			var user = await _context.Users.FirstOrDefaultAsync(m => m.EmailUser.Equals(User.FindFirst(ClaimTypes.Email).Value));
			if (DocName != null)
			{
				await SaveDoc(DocName);
				var filename = DocName.FileName;
				string filePath = "wwwroot/assets/document/" + filename;
				if (System.IO.File.Exists(filePath))
				{
					var fileInfo = new FileInfo(filePath);
					d.DocSize = fileInfo.Length;
					d.DocName = filename;

					var document = _context.Documents.Select(t => t.IdDoc).ToList();
					if (document.Count() == 0)
					{
						d.IdDoc = 1;
					}
					else
					{
						d.IdDoc = document.Max() + 1;
					}
					d.DocType = Path.GetExtension(filename).ToUpper().Substring(1);
					d.DocDate = DateTime.Now;

					d.IdUser = user.IdUser;
					_context.Documents.Add(d);
					_context.SaveChanges();
					return RedirectToAction("Company");
				}
			}
			return View(d);
		}

		[HttpPost]
		public IActionResult Delete_Document(int id)
		{
			var item = _context.Documents.FirstOrDefault(p => p.IdDoc == id);
			if (item == null)
			{
				return NotFound();
			}
			_context.Documents.Remove(item); // Xóa tài liệu từ cơ sở dữ liệu
			_context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
			return RedirectToAction("Company"); // Trả về mã thành công
		}
		private async Task<string> SaveDoc(IFormFile doc)
		{
			var savePath = Path.Combine("wwwroot/assets/document", doc.FileName);
			using (var fileStream = new FileStream(savePath, FileMode.Create))
			{
				await doc.CopyToAsync(fileStream);
			}
			return doc.FileName;
		}

		[HttpPost]
		public async Task<IActionResult> Add_Company(Company c)
		{	
			if (c != null)
			{
				var comp = await _context.Companies.Select(t => t.Idcompany).ToListAsync();
				c.Idcompany =  comp.Count()+1;

				_context.Companies.Add(c);
				_context.SaveChanges();
				return RedirectToAction("Company");

			}
			return View(c);
		}
		[HttpPost]
		public IActionResult Edit_Company(Company c)
		{
			if (c != null && _context.Companies.Any(t => t.Idcompany == c.Idcompany))
			{
				// Kiểm tra xem dữ liệu đã được binding thành công chưa
				if (ModelState.IsValid)
				{
					// Cập nhật thông tin của công ty
					_context.Companies.Update(c);
					_context.SaveChanges(); // Sử dụng SaveChanges() thay vì SaveChangesAsync()

					// Chuyển hướng sau khi cập nhật thành công
					return RedirectToAction("Company");
				}
			}

			// Trả về view nếu có lỗi xảy ra hoặc không tìm thấy đối tượng cần cập nhật
			return View(c);
		}


	}
}
