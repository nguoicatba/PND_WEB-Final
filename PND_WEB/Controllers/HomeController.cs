using System.Diagnostics;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.Services;
using PND_WEB.ViewModels;


namespace PND_WEB.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        //pdf

        private readonly IViewRenderService _viewRenderService;
        private readonly IConverter _converter;

        public HomeController(ILogger<HomeController> logger,DataContext context, IConverter converter, IViewRenderService viewRenderService)
        {
            _logger = logger;
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.CompletedBookingsCount = _context.TblBookingConfirms.Count(q => q.Status == "Hoàn thành");
            ViewBag.WaitBookingsCount = _context.TblBookingConfirms.Count(q => q.Status == "Đang vận chuyển");

            string todayPrefix = $"BK{DateTime.Now:yyyyMM}";
            ViewBag.TodayBookingsCount = _context.TblBookingConfirms.Count(q => q.BookingId.StartsWith(todayPrefix));

            var booking = await _context.TblBookingConfirms
                .OrderByDescending(q => q.BookingId)
                .Take(5)
                .ToListAsync();

            return View(booking);

        }

        [ClaimAuthorize("Job", "Create")]
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
            else if (statuscode == 403)
            {
                return View("AccessDenied");
            }

                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
