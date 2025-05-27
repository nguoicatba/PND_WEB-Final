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
            string selectedThang = thang ?? DateTime.Now.Month.ToString("00");
            string yearPattern = $"QTN{namThongKe}";

            var excludedStatuses = new[] { "Đang đàm phán", "Đã hủy" };

            var quotations = await _context.Quotations
                .Where(q => q.QuotationId.StartsWith(yearPattern)
                         && !excludedStatuses.Contains(q.Qsatus))
                .ToListAsync();

            var groupedData = quotations
                .GroupBy(q => q.QuotationId.Substring(7, 2))
                .Select(g => new ThongKeQuotationViewModel
                {
                    Thang = g.Key,
                    SoLuongQuotation = g.Count()
                })
                .OrderBy(x => x.Thang)
                .ToList();

            var staffMonthStats = quotations
                .Where(q => string.IsNullOrEmpty(thang) || q.QuotationId.Substring(7, 2) == selectedThang)
                .GroupBy(q => new { StaffName = q.StaffName, Month = q.QuotationId.Substring(7, 2) })
                .Select(g => new ThongKeNguoiDungTheoThangViewModel
                {
                    StaffName = g.Key.StaffName,
                    Thang = g.Key.Month,
                    SoLuongQuotation = g.Count()
                })
                .OrderBy(x => x.StaffName)
                .ThenBy(x => x.Thang)
                .ToList();

            //bổ sung tháng không có báo giá
            var allMonths = Enumerable.Range(1, 12)
                .Select(month => new ThongKeQuotationViewModel
                {
                    Thang = month.ToString("00"),
                    SoLuongQuotation = groupedData.FirstOrDefault(x => x.Thang == month.ToString("00"))?.SoLuongQuotation ?? 0
                })
                .ToList();

            return View(new BaoCaoThongKeViewModel
            {
                Nam = namThongKe,
                ThongKeTheoThang = allMonths,
                ThongKeNguoiDungTheoThang = staffMonthStats,
                Thang = selectedThang
            });
        }
    }
}
