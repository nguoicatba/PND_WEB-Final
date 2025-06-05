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

            // Get top 3 customers with most bookings
            var topCustomers = await _context.TblBookingConfirms
                .GroupBy(b => b.CustomerId)
                .Select(g => new TopCustomerViewModel
                {
                    CustomerId = g.Key,
                    BookingCount = g.Count(),
                    CompanyName = _context.TblCustomers
                        .Where(c => c.CustomerId == g.Key)
                        .Select(c => c.CompanyName)
                        .FirstOrDefault() ?? "Unknown"
                })
                .OrderByDescending(x => x.BookingCount)
                .Take(3)
                .ToListAsync();

            ViewBag.TopCustomers = topCustomers;

            var booking = await _context.TblBookingConfirms
                .OrderByDescending(q => q.BookingId)
                .Take(5)
                .ToListAsync();

            return View(booking);
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
