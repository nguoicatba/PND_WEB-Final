using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class ContChargeController : Controller
    {
        private readonly DataContext _context;
        public ContChargeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var ContCharges = await _context.TblHblCharges
                .Where(c => c.HblId == id && c.Cont == true)
                .ToListAsync();

            ContChargeVM contChargeVM = new ContChargeVM
            {
                HBL_Id = id,
                JOB_Id = _context.TblHbls
                    .Where(h => h.Hbl == id)
                    .Select(h => h.RequestId)
                    .FirstOrDefault(),
                _charges = ContCharges.Select(c => new ContChargeEM
                {
                    ChargeId = c.ChargeId,
                    SupplierId = c.SupplierId,
                    SupplierName = _context.TblSuppliers
                        .Where(s => s.SupplierId == c.SupplierId)
                        .Select(s => s.NameSup)
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
                    Cont = c.Cont,
                    HblId = c.HblId
                }).ToList()
            };

            return View(contChargeVM);
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            var contChargeEM = new ContChargeEM
            {
                HblId = id,
                CreatedDate = DateTime.Now,
                Cont = true
            };
            return View(contChargeEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContChargeEM contChargeEM)
        {
            if (ModelState.IsValid)
            {
                var charge = new TblHblCharges
                {
                    ChargeId = Guid.NewGuid().ToString(),
                    SupplierId = contChargeEM.SupplierId,
                    SerName = contChargeEM.SerName,
                    SerUnit = contChargeEM.SerUnit,
                    SerQuantity = contChargeEM.SerQuantity,
                    SerPrice = contChargeEM.SerPrice,
                    Currency = contChargeEM.Currency,
                    ExchangeRate = contChargeEM.ExchangeRate,
                    SerVat = contChargeEM.SerVat,
                    MVat = contChargeEM.MVat,
                    Checked = false,
                    CreatedDate = DateTime.Now,
                    Cont = true,
                    HblId = contChargeEM.HblId
                };

                _context.Add(charge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = contChargeEM.HblId });
            }
            return View(contChargeEM);
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

            var contChargeEM = new ContChargeEM
            {
                ChargeId = charge.ChargeId,
                SupplierId = charge.SupplierId,
                SupplierName = await _context.TblSuppliers
                    .Where(s => s.SupplierId == charge.SupplierId)
                    .Select(s => s.NameSup)
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
                Cont = charge.Cont,
                HblId = charge.HblId
            };

            return View(contChargeEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ContChargeEM contChargeEM)
        {
            if (id != contChargeEM.ChargeId)
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

                    charge.SupplierId = contChargeEM.SupplierId;
                    charge.SerName = contChargeEM.SerName;
                    charge.SerUnit = contChargeEM.SerUnit;
                    charge.SerQuantity = contChargeEM.SerQuantity;
                    charge.SerPrice = contChargeEM.SerPrice;
                    charge.Currency = contChargeEM.Currency;
                    charge.ExchangeRate = contChargeEM.ExchangeRate;
                    charge.SerVat = contChargeEM.SerVat;
                    charge.MVat = contChargeEM.MVat;
                    charge.UpdatedDate = DateTime.Now;

                    _context.Update(charge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ChargeExists(contChargeEM.ChargeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = contChargeEM.HblId });
            }
            return View(contChargeEM);
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

            var contChargeEM = new ContChargeEM
            {
                ChargeId = charge.ChargeId,
                SupplierId = charge.SupplierId,
                SupplierName = await _context.TblSuppliers
                    .Where(s => s.SupplierId == charge.SupplierId)
                    .Select(s => s.NameSup)
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
                Cont = charge.Cont,
                HblId = charge.HblId
            };

            return View(contChargeEM);
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
        public async Task<JsonResult> CurrencyGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Currencies : _context.Currencies.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.CurrName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.CurrName,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Currency",
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
                    header_name = "Currency Name"
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

        [HttpGet]
        public async Task<JsonResult> SupplierGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.TblSuppliers : _context.TblSuppliers.Where(data => data.SupplierId.ToLower().Contains(q.ToLower()) || data.NameSup.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.SupplierId,
                text = data.NameSup,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Supplier",
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
                    header_name = "Supplier Name"
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCharges([FromBody] ApproveChargesEM request)
        {
            if (!User.HasClaim("AllInvoice", "Check"))
            {
                return Json(new { success = false, message = "Unauthorized access." });
            }

            try
            {
                var chargeIds = request.chargegroup.Select(c => c.chargeid).ToList();
                var charges = await _context.TblHblCharges
                    .Where(c => chargeIds.Contains(c.ChargeId) && c.HblId == request.hblId)
                    .ToListAsync();

                if (!charges.Any())
                {
                    return Json(new { success = false, message = "No charges found to update." });
                }

                foreach (var charge in charges)
                {
                    var chargeGroup = request.chargegroup.FirstOrDefault(cg => cg.chargeid == charge.ChargeId);
                    if (chargeGroup != null)
                    {
                        charge.Checked = chargeGroup.isSelected;
                    }
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Charges updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error updating charges: {ex.Message}" });
            }
        }

      
    }
} 