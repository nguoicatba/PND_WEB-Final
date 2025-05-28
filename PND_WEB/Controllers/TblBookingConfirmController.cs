using Azure;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //Booking 

        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            var booking = await _context.TblBookingConfirms
                .Where(q => q.StaffName == user.Staff_Name)
                .ToListAsync();

            return View(booking);
        }
        public async Task<IActionResult> Create()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var model = new TblBookingConfirm
            {
                BookingId = await PredictBookingCode(),
                Status = "Chờ lấy hàng",
                StaffName = user.Staff_Name,
                CreatedDate = DateTime.Now,
                ETD = DateTime.Today,
                ETA = DateTime.Today.AddDays(15),
                GoodType = "AI" // Default good type
            };
            return View(model);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,BookingDate,GoodType,ETD,ETA,POL,POD,VesselName,ContainerType,ContainerQuantity,FlightNumber,Airline,PackageQuantity,GrossWeight,ChargeableWeight,Volume,CargoDescription,Status,Remarks,CreatedDate,UpdatedDate,StaffName,Contact,PICcompany,QuotationId")] TblBookingConfirm booking)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(username);
                booking.BookingId = await GenerateBookingCode();
                booking.CreatedDate = DateTime.Now;
                booking.StaffName = user.Staff_Name;
                booking.ETD = DateTime.Today;
                booking.ETA = DateTime.Today.AddDays(15);
                booking.Status = "Chờ lấy hàng";

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            booking.BookingId = await PredictBookingCode();
            return View(booking);
        }


        // GET: TblBookingConfirm/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.TblBookingConfirms
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: TblBookingConfirm/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.TblBookingConfirms.FindAsync(id);
            ViewBag.StatusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Chờ lấy hàng", Text = "Chờ lấy hàng" },
                new SelectListItem { Value = "Đang vận chuyển", Text = "Đang vận chuyển" },
                new SelectListItem { Value = "Đã hủy", Text = "Đã hủy" },
                new SelectListItem { Value = "Hoàn thành", Text = "Hoàn thành" }
            };

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: TblBookingConfirm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BookingId,CustomerId,BookingDate,GoodType,ETD,ETA,POL,POD,VesselName,ContainerType,ContainerQuantity,FlightNumber,Airline,PackageQuantity,GrossWeight,ChargeableWeight,Volume,CargoDescription,Status,Remarks,CreatedDate,UpdatedDate,StaffName,Contact,PICcompany,QuotationId")] TblBookingConfirm booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    booking.UpdatedDate = DateTime.Now;
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.TblBookingConfirms.AnyAsync(e => e.BookingId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: TblBookingConfirm/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.TblBookingConfirms
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: TblBookingConfirm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var booking = await _context.TblBookingConfirms.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.TblBookingConfirms.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        /// <summary>
        ///âsss
        public async Task<JsonResult> PortGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = _context.Cports.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.PortName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.PortName,
                text = data.PortName,
                code = data.Code,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Port",
                    code = "-1",
                    disabled = true
                });
            }

            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "Code",
                    header_name = "Port Name"
                }
            });
        }

        public async Task<JsonResult> CustomerGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = _context.TblCustomers.Where(data => data.CustomerId.ToLower().Contains(q.ToLower()) || data.CompanyName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.CustomerId,
                text = data.CompanyName,
                code = data.CustomerId,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Customer",
                    code = "-1",
                    disabled = true
                });
            }

            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "CustomerID",
                    header_name = "CompanyName"
                }
            });
        }
    }
}
