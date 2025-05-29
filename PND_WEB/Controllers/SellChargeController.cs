using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class SellChargeController : Controller
    {
        private readonly DataContext _context;
        public SellChargeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var SellCharges = await _context.TblHblCharges
                .Where(c => c.HblId == id && c.Sell == true)
                .ToListAsync();

            var sellChargeVM = new SellChargeVM
            {
                HBL_Id = id,
                _charges = SellCharges.Select(c => new SellChargeEM
                {
                    ChargeId = c.ChargeId,

                    CustomerID = c.CustomerId,
                    CustomerName = _context.TblCustomers
                    .Where(s => s.CustomerId == c.CustomerId)
                    .Select(s => s.CompanyName)
                    .FirstOrDefault() == null
                    ? "Unknown Customer"
                    : _context.TblCustomers
                        .Where(s => s.CustomerId == c.CustomerId)
                        .Select(s => s.CompanyName)
                        .FirstOrDefault(),

                    SerName = c.SerName,
                    SerUnit = c.SerUnit,
                    SerQuantity = c.SerQuantity,
                    SerPrice = c.SerPrice,
                    Currency = c.Currency,
                    ExchangeRate = c.ExchangeRate,
                    SerVat = c.SerVat,
                    MVat = c.MVat,
                    Checked = c.Checked,
                    CreatedDate = c.CreatedDate,
                    UpdatedDate = c.UpdatedDate,
                    InvoiceNo = c.InvoiceNo,
                    Sell = c.Sell,
                    HblId = c.HblId
                }).ToList()
            };

            return View(sellChargeVM);
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            var sellChargeEM = new SellChargeEM
            {
                HblId = id,
                CreatedDate = DateTime.Now,
                Sell = true,
            };
            return View(sellChargeEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellChargeEM sellChargeEM)
        {
            if (ModelState.IsValid)
            {
                var charge = new TblHblCharges
                {
                    ChargeId = Guid.NewGuid().ToString(),
                    CustomerId = sellChargeEM.CustomerID,

                    SerName = sellChargeEM.SerName,
                    SerUnit = sellChargeEM.SerUnit,
                    SerQuantity = sellChargeEM.SerQuantity,
                    SerPrice = sellChargeEM.SerPrice,
                    Currency = sellChargeEM.Currency,
                    ExchangeRate = sellChargeEM.ExchangeRate,
                    SerVat = sellChargeEM.SerVat,
                    MVat = sellChargeEM.MVat,
                    Checked = false,
                    CreatedDate = DateTime.Now,
                    Sell = true,
                    HblId = sellChargeEM.HblId
                };

                _context.Add(charge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = sellChargeEM.HblId });
            }
            return View(sellChargeEM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charge = await _context.TblHblCharges.FindAsync(id);
            if (charge == null)
            {
                return NotFound();
            }

            var sellChargeEM = new SellChargeEM
            {
                ChargeId = charge.ChargeId,
                CustomerID = charge.CustomerId,
                CustomerName = await _context.TblCustomers
                    .Where(s => s.CustomerId == charge.CustomerId)
                    .Select(s => s.CompanyName)
                    .FirstOrDefaultAsync(),
                SerName = charge.SerName,
                SerUnit = charge.SerUnit,
                SerQuantity = charge.SerQuantity,
                SerPrice = charge.SerPrice,
                Currency = charge.Currency,
                ExchangeRate = charge.ExchangeRate,
                SerVat = charge.SerVat,
                MVat = charge.MVat,
                Checked = charge.Checked,
                CreatedDate = charge.CreatedDate,
                UpdatedDate = charge.UpdatedDate,
                InvoiceNo = charge.InvoiceNo,
                Sell = charge.Sell,
                HblId = charge.HblId
            };

            return View(sellChargeEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SellChargeEM sellChargeEM)
        {
            if (id != sellChargeEM.ChargeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var charge = await _context.TblHblCharges.FindAsync(id);
                    if (charge == null)
                    {
                        return NotFound();
                    }

                    charge.CustomerId= sellChargeEM.CustomerID;
                    charge.SerName = sellChargeEM.SerName;
                    charge.SerUnit = sellChargeEM.SerUnit;
                    charge.SerQuantity = sellChargeEM.SerQuantity;
                    charge.SerPrice = sellChargeEM.SerPrice;
                    charge.Currency = sellChargeEM.Currency;
                    charge.ExchangeRate = sellChargeEM.ExchangeRate;
                    charge.SerVat = sellChargeEM.SerVat;
                    charge.MVat = sellChargeEM.MVat;
                    charge.UpdatedDate = DateTime.Now;

                    _context.Update(charge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ChargeExists(sellChargeEM.ChargeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = sellChargeEM.HblId });
            }
            return View(sellChargeEM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charge = await _context.TblHblCharges
                .FirstOrDefaultAsync(m => m.ChargeId == id);
            if (charge == null)
            {
                return NotFound();
            }

            var sellChargeEM = new SellChargeEM
            {
                ChargeId = charge.ChargeId,

                CustomerID = charge.CustomerId,
                CustomerName = await _context.TblCustomers
                    .Where(s => s.CustomerId == charge.CustomerId)
                    .Select(s => s.CompanyName)
                    .FirstOrDefaultAsync(),
                SerName = charge.SerName,
                SerUnit = charge.SerUnit,
                SerQuantity = charge.SerQuantity,
                SerPrice = charge.SerPrice,
                Currency = charge.Currency,
                ExchangeRate = charge.ExchangeRate,
                SerVat = charge.SerVat,
                MVat = charge.MVat,
                Checked = charge.Checked,
                CreatedDate = charge.CreatedDate,
                UpdatedDate = charge.UpdatedDate,
                InvoiceNo = charge.InvoiceNo,
                Sell = charge.Sell,
                HblId = charge.HblId
            };

            return View(sellChargeEM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var charge = await _context.TblHblCharges.FindAsync(id);
            if (charge != null)
            {
                _context.TblHblCharges.Remove(charge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = charge.HblId });
        }

        private async Task<bool> ChargeExists(string id)
        {
            return await _context.TblHblCharges.AnyAsync(e => e.ChargeId == id);
        }

        [HttpGet]
        public async Task<JsonResult> CustomerGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.TblCustomers : _context.TblCustomers.Where(data => data.CustomerId.ToLower().Contains(q.ToLower()) || data.CompanyName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.CustomerId,
                text = data.CompanyName,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Customer",
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
                    header_name = "Customer Name"
                }
            });
        }

      

        [HttpGet]
        public async Task<JsonResult> FeeGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Fees : _context.Fees
                .Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.Fee1.ToLower().Contains(q.ToLower()) || data.Unit.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.Fee1,
                unit = data.Unit,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new { id = "-1", text = "Select Fee", unit = "", disabled = true });
            }
            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "Code",
                    header_name = "Name",
                    header_unit = "Unit"
                }
            });
        }

        [HttpGet]
        public async Task<JsonResult> UnitGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Units : _context.Units.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.UnitName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.UnitName,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Unit",
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
                    header_name = "Unit Name"
                }
            });
        }
    }
} 