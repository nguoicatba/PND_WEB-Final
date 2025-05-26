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

        public async Task<IActionResult> Bestsale(int? nam)
        {
            int namThongKe = nam ?? DateTime.Now.Year;
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

            var staffStats = quotations
                .GroupBy(q => q.StaffName)
                .Select(g => new ThongKeNguoiDungViewModel
                {
                    StaffName = g.Key,
                    SoLuongQuotation = g.Count()
                })
                .OrderByDescending(x => x.SoLuongQuotation)
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
                ThongKeTheoNguoiDung = staffStats
            });
        }
    }
}
