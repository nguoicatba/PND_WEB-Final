﻿using Azure;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.Services;
using PND_WEB.ViewModels;

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

        public IActionResult Index()
        {
            if (User.HasClaim("BookingComfirm", "IndexAdmin") || User.IsInRole("SuperAdmin") || User.IsInRole("CEO"))
            {
                return RedirectToAction(nameof(IndexAdmin));
            }

            if (User.HasClaim("BookingComfirm", "IndexUser"))
            {
                return RedirectToAction(nameof(IndexUser));
            }
          
            return NotFound();
        }

        public async Task<IActionResult> IndexUser()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            var booking = await _context.TblBookingConfirms
                .Where(q => q.StaffName == user.Staff_Name)
                .ToListAsync();

            return View(booking);
        }

        public async Task<IActionResult> IndexAdmin()
        {
            var booking = await _context.TblBookingConfirms
                .ToListAsync();

            return View(booking);
        }

        [ClaimAuthorize("BookingComfirm", "Create")]
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
                BookingDate = DateTime.Now,
                ETD = DateTime.Today,
                ETA = DateTime.Today.AddDays(15),
                GoodType = "AI" // Default good type
            };
            return View(model);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,BookingDate,GoodType,ETD,ETA,POL,POD,VesselName,ContainerType,ContainerQuantity,FlightNumber,Airline,PackageQuantity,GrossWeight,ChargeableWeight,Volume,CargoDescription,Status,Remarks,CreatedDate,UpdatedDate,StaffName,Contact,PICcompany,QuotationId,CNEE,Shipper")] TblBookingConfirm booking)
        {
            if (ModelState.IsValid)
            {
                var username = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(username);
                booking.BookingId = await GenerateBookingCode();
                booking.CreatedDate = DateTime.Now;
                booking.BookingDate = DateTime.Now;
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

        [ClaimAuthorize("BookingComfirm", "Details")]
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

        [ClaimAuthorize("BookingComfirm", "Edit")]
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
        public async Task<IActionResult> Edit(string id, [Bind("BookingId,CustomerId,BookingDate,GoodType,ETD,ETA,POL,POD,VesselName,ContainerType,ContainerQuantity,FlightNumber,Airline,PackageQuantity,GrossWeight,ChargeableWeight,Volume,CargoDescription,Status,Remarks,CreatedDate,UpdatedDate,StaffName,Contact,PICcompany,QuotationId,Shipper,CNEE")] TblBookingConfirm booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBooking = await _context.TblBookingConfirms.FindAsync(id);
                    if (existingBooking == null)
                    {
                        return NotFound();
                    }

                    existingBooking.CustomerId = booking.CustomerId;
                    existingBooking.GoodType = booking.GoodType;
                    existingBooking.ETD = booking.ETD;
                    existingBooking.ETA = booking.ETA;
                    existingBooking.POL = booking.POL;
                    existingBooking.POD = booking.POD;
                    existingBooking.VesselName = booking.VesselName;
                    existingBooking.ContainerType = booking.ContainerType;
                    existingBooking.ContainerQuantity = booking.ContainerQuantity;
                    existingBooking.FlightNumber = booking.FlightNumber;
                    existingBooking.Airline = booking.Airline;
                    existingBooking.PackageQuantity = booking.PackageQuantity;
                    existingBooking.GrossWeight = booking.GrossWeight;
                    existingBooking.ChargeableWeight = booking.ChargeableWeight;
                    existingBooking.Volume = booking.Volume;
                    existingBooking.CargoDescription = booking.CargoDescription;
                    existingBooking.Status = booking.Status;
                    existingBooking.Remarks = booking.Remarks;
                    existingBooking.Contact = booking.Contact;
                    existingBooking.PICcompany = booking.PICcompany;
                    existingBooking.QuotationId = booking.QuotationId;
                    existingBooking.Shipper = booking.Shipper;
                    existingBooking.CNEE = booking.CNEE;

                    existingBooking.UpdatedDate = DateTime.Now;

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
        [ClaimAuthorize("BookingComfirm", "Delete")]
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
                text = data.Code,
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
                    header_code = "Port Name",
                    header_name = "Code"
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

        public async Task<JsonResult> ShipperGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = _context.TblShippers.Where(data => data.Shipper.ToLower().Contains(q.ToLower()) || data.SpersonInCharge.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.SpersonInCharge,
                text = data.SpersonInCharge,
                code = data.Shipper,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Shipper",
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
                    header_code = "Shipper",
                    header_name = "PersonInCharge"
                }
            });
        }


        public async Task<JsonResult> CneeGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = _context.TblCnees.Where(data => data.Cnee.ToLower().Contains(q.ToLower()) || data.CpersonInCharge.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.CpersonInCharge,
                text = data.CpersonInCharge,
                code = data.Cnee,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Shipper",
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
                    header_code = "Cnee",
                    header_name = "PersonInCharge"
                }
            });
        }


        //ExportPDF
        public async Task<IActionResult> ExportPDFBooking(string id)
        {
            var booking = await _context.TblBookingConfirms
                                          .Include(q => q.Customer)
                                          .FirstOrDefaultAsync(q => q.BookingId == id);

            if (booking == null)
                return NotFound();


            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFBooking", booking);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=Booking.pdf");
            return File(file, "application/pdf");
        }
    }
}
