using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;


namespace PND_WEB.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger,DataContext context )
        {
            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View(await _context.Modes.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveData([FromBody] List<Mode> data)
        {
            if (data == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            // 1. Lấy danh sách Mode hiện có trong DB
            var existingList = await _context.Modes.ToListAsync();

            // 2. Tạo danh sách Code từ client gửi lên
            var codesFromClient = data.Select(d => d.Code).ToList();

            // 3. Cập nhật hoặc thêm mới
            foreach (var item in data)
            {
                var existing = existingList.FirstOrDefault(x => x.Code == item.Code);
                if (existing != null)
                {
                    // Cập nhật
                    existing.Note = item.Note;
                    // Cập nhật thêm các trường khác nếu có
                }
                else
                {
                    // Thêm mới
                    await _context.Modes.AddAsync(item);
                }
            }

            // 4. Xóa các bản ghi không còn trong dữ liệu client gửi lên
            var toDelete = existingList.Where(x => !codesFromClient.Contains(x.Code)).ToList();
            if (toDelete.Any())
            {
                _context.Modes.RemoveRange(toDelete);
            }

            // 5. Lưu thay đổi vào CSDL
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Lưu dữ liệu thành công!" });

        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
            {
                return View("NotFound");
            }
           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
