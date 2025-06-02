using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PND_WEB.Controllers
{
    public class BaocaoThongke : Controller
    {
        private readonly DataContext _context;

        public BaocaoThongke(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Bestsale(int? nam, string? thang)
        {
            int namThongKe = nam ?? DateTime.Now.Year;
            string yearPattern = $"BK{namThongKe}";

            var excludedStatuses = new[] { "Chờ lấy hàng", "Đã hủy" };

            var bookings = await _context.TblBookingConfirms
                .Where(q => q.BookingId.StartsWith(yearPattern)
                         && !excludedStatuses.Contains(q.Status))
                .ToListAsync();

            var groupedData = bookings
                .GroupBy(q => q.BookingId.Substring(6, 2))
                .Select(g => new ThongKeBookingViewModel
                {
                    Thang = g.Key,
                    SoLuongBooking = g.Count()
                })
                .OrderBy(x => x.Thang)
                .ToList();

            var staffMonthStats = bookings;
            if (!string.IsNullOrEmpty(thang))
            {
                staffMonthStats = staffMonthStats.Where(q => q.BookingId.Substring(6, 2) == thang).ToList();
            }

            var staffMonthGrouped = staffMonthStats
                .GroupBy(q => new { StaffName = q.StaffName, Month = q.BookingId.Substring(6, 2) })
                .Select(g => new ThongKeNguoiDungTheoThangViewModel
                {
                    StaffName = g.Key.StaffName,
                    Thang = g.Key.Month,
                    SoLuongBooking = g.Count()
                })
                .OrderBy(x => x.StaffName)
                .ThenBy(x => x.Thang)
                .ToList();

            var allMonths = Enumerable.Range(1, 12)
                .Select(month => new ThongKeBookingViewModel
                {
                    Thang = month.ToString("00"),
                    SoLuongBooking = groupedData.FirstOrDefault(x => x.Thang == month.ToString("00"))?.SoLuongBooking ?? 0
                })
                .ToList();

            return View(new BaoCaoThongKeViewModel
            {
                Nam = namThongKe,
                ThongKeTheoThang = allMonths,
                ThongKeNguoiDungTheoThang = staffMonthGrouped,
                Thang = thang ?? ""
            });
        }
    }
}
