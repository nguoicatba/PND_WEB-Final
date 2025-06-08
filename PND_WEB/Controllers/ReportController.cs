using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly DataContext _context;

        public ReportController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> JobStatistics(DateTime? fromDate, DateTime? toDate)
        {
            // Nếu không có ngày được chọn, mặc định lấy tháng hiện tại
            if (!fromDate.HasValue)
                fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (!toDate.HasValue)
                toDate = DateTime.Now;

            // Lấy danh sách jobs trong khoảng thời gian
            var jobs = await _context.TblJobs
                .Include(j => j.AgentNavigation)
                .Include(j => j.CarrierNavigation)
                .Include(j => j.TblHbls)
                .Where(j => j.JobDate >= fromDate && j.JobDate <= toDate)
                .ToListAsync();

            // Tính toán các thống kê
            var jobStats = new JobStatisticsViewModel
            {
                FromDate = fromDate.Value,
                ToDate = toDate.Value,
                TotalJobs = jobs.Count,
                AverageHblsPerJob = jobs.Any() ? jobs.Average(j => j.TblHbls.Count) : 0,

                // Thống kê theo Mode
                JobsByMode = jobs.GroupBy(j => j.Mode ?? "N/A")
                    .Select(g => new JobStatsByMode
                    {
                        Mode = g.Key,
                        Count = g.Count()
                    })
                    .ToList(),

                // Thống kê theo GoodsType
                JobsByGoodsType = jobs.GroupBy(j => j.GoodsType ?? "N/A")
                    .Select(g => new JobStatsByGoodsType
                    {
                        GoodsType = g.Key,
                        Count = g.Count()
                    })
                    .ToList(),

                // Thống kê theo Agent
                JobsByAgent = jobs.GroupBy(j => j.AgentNavigation.AgentName)
                    .Select(g => new JobStatsByAgent
                    {
                        AgentName = g.Key,
                        Count = g.Count()
                    })
                    .ToList(),

                // Thống kê theo Carrier
                JobsByCarrier = jobs.GroupBy(j => j.CarrierNavigation.CarrierName)
                    .Select(g => new JobStatsByCarrier
                    {
                        CarrierName = g.Key,
                        Count = g.Count()
                    })
                    .ToList(),

                // Thống kê theo POL
                JobsByPol = jobs.GroupBy(j => j.Pol ?? "N/A")
                    .Select(g => new JobStatsByPort
                    {
                        PortName = g.Key,
                        Count = g.Count()
                    })
                    .ToList(),

                // Thống kê theo POD
                JobsByPod = jobs.GroupBy(j => j.Pod ?? "N/A")
                    .Select(g => new JobStatsByPort
                    {
                        PortName = g.Key,
                        Count = g.Count()
                    })
                    .ToList(),

                // Thống kê theo tháng
                JobsByMonth = jobs.GroupBy(j => new { j.JobDate.Year, j.JobDate.Month })
                    .Select(g => new JobStatsByMonth
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToList(),

                // Danh sách job gần đây
                RecentJobs = jobs.OrderByDescending(j => j.JobDate)
                    .Take(10)
                    .Select(j => new JobDetailViewModel
                    {
                        JobId = j.JobId,
                        JobDate = j.JobDate,
                        Mode = j.Mode,
                        GoodsType = j.GoodsType,
                        AgentName = j.AgentNavigation.AgentName,
                        CarrierName = j.CarrierNavigation.CarrierName,
                        Pol = j.Pol,
                        Pod = j.Pod,
                        Etd = j.Etd,
                        Eta = j.Eta,
                        HblCount = j.TblHbls.Count
                    })
                    .ToList()
            };

            return View(jobStats);
        }

        [HttpGet]
        public async Task<IActionResult> GetJobChartData(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
                fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (!toDate.HasValue)
                toDate = DateTime.Now;

            // Lấy danh sách jobs trong khoảng thời gian
            var jobs = await _context.TblJobs
                .Where(j => j.JobDate >= fromDate && j.JobDate <= toDate)
                .ToListAsync();

            var jobsByMonth = jobs.GroupBy(j => new { j.JobDate.Year, j.JobDate.Month })
                .Select(g => new
                {
                    Date = $"{g.Key.Year}-{g.Key.Month}",
                    Count = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToList();

            var jobsByMode = jobs.GroupBy(j => j.Mode ?? "N/A")
                .Select(g => new
                {
                    Mode = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return Json(new { jobsByMonth, jobsByMode });
        }

        public async Task<IActionResult> Profit(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue)
                fromDate = DateTime.Now.AddMonths(-1);
            if (!toDate.HasValue)
                toDate = DateTime.Now;

            ViewBag.Filter = new ProfitReportFilterModel
            {
                FromDate = fromDate.Value,
                ToDate = toDate.Value
            };

            var job = await _context.TblJobs
                .Where(j => j.JobDate >= fromDate && j.JobDate <= toDate)
                .Include(j => j.AgentNavigation)
                .Include(j => j.CarrierNavigation)
                .ToListAsync();

            var hbls = await _context.TblHbls
                .Where(h => job.Select(j => j.JobId).Contains(h.RequestId))
                .Include(h => h.ShipperNavigation)
                .Include(h => h.CneeNavigation)
                .ToListAsync();
            //((item.SerPrice ?? 0) * (item.SerQuantity ?? 0) * (item.ExchangeRate ?? 1) * (1 + (item.SerVat ?? 0) / 100) + (item.MVat ?? 0)
             List<ProfitReportViewModel> profitReports = new List<ProfitReportViewModel>();
            foreach (var hbl in hbls)
            {
                var jobDetails = job.FirstOrDefault(j => j.JobId == hbl.RequestId);
                if (jobDetails == null) continue;
                var totalBuy = await _context.TblHblCharges
                    .Where(hc => hc.HblId == hbl.Hbl && hc.Checked==true && hc.Buy == true)
                    .SumAsync(hc => (hc.SerPrice ?? 0) * (hc.SerQuantity ?? 0) * (hc.ExchangeRate ?? 1) * (1 + (hc.SerVat ?? 0) / 100) + (hc.MVat ?? 0));
                var totalSell = await _context.TblHblCharges
                    .Where(hc => hc.HblId == hbl.Hbl && hc.Checked == true && hc.Sell == true)
                    .SumAsync(hc => (hc.SerPrice ?? 0) * (hc.SerQuantity ?? 0) * (hc.ExchangeRate ?? 1) * (1 + (hc.SerVat ?? 0) / 100) + (hc.MVat ?? 0));
                profitReports.Add(new ProfitReportViewModel
                {
                    Hbl = hbl,
                    Job = jobDetails,
                    TotalBuy = totalBuy,
                    TotalSell = totalSell,
                    Profit = totalSell - totalBuy
                });
            }

            return View(profitReports);
        }
    }
} 