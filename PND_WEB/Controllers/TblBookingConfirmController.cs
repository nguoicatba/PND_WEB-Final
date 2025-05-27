using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.Services;

namespace PND_WEB.Controllers
{
    public class TblBookingConfirmController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IConverter _converter;
        private readonly IViewRenderService _viewRenderService;

        public TblBookingConfirmController(DataContext context, UserManager<AppUserModel> userManager, IConverter converter, IViewRenderService viewRenderService)
        {
            _context = context;
            _userManager = userManager;
            _converter = converter;
            _viewRenderService = viewRenderService;
        }

        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            var quotations = await _context.TblBookingConfirms
                .Where(q => q.StaffName == user.Staff_Name)
                .ToListAsync();

            return View(quotations);
        }


        // FUNCTIONS
        public async Task<string> PredictBookingCode()
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"BK{datePart}";

            var bookingWithPrefix = await _context.TblBookingConfirms
                .Where(q => q.BookingId.StartsWith(prefix))
                .Select(q => q.BookingId)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var bookingid in bookingWithPrefix)
            {
                if (bookingid.Length >= prefix.Length + 3 &&
                    int.TryParse(bookingid.Substring(prefix.Length, 3), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            int nextNumber = maxNumber + 1;

            return $"{prefix}{nextNumber:D3}";
        }



        public async Task<string> GenerateBookingCode()
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"BK{datePart}";

            var bookingWithPrefix = await _context.TblBookingConfirms
                .Where(q => q.BookingId.StartsWith(prefix))
                .Select(q => q.BookingId)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var bookingId in bookingWithPrefix)
            {
                if (bookingId.Length >= prefix.Length + 3 &&
                    int.TryParse(bookingId.Substring(prefix.Length, 3), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            int nextNumber = maxNumber + 1;

            return $"{prefix}{nextNumber:D3}";
        }


        //Quotations
        public async Task<IActionResult> Create()
        {
            var username = User.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);
            var model = new TblBookingConfirm
            {
                BookingId = await PredictBookingCode(),
                Status = "Đã chốt, đang chờ lấy hàng",
                StaffName = user.Staff_Name,
                CreatedDate = DateTime.Now,
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,BookingDate,GoodType,ETD,ETA,POL,POD,VesselName,ContainerType,ContainerQuantity,FlightNumber,Airline,PackageQuantity,GrossWeight,ChargeableWeight,Volume,CargoDescription,Status,Remarks,CreatedDate,UpdatedDate,StaffName,Contact,PICcompany")] TblBookingConfirm booking)
        {
            if (ModelState.IsValid)
            {
                booking.BookingId = await GenerateBookingCode();

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            booking.BookingId = await PredictBookingCode();
            return View(booking);
        }
    }
}
