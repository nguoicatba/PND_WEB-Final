using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class BuyChargeController : Controller
    {
        private readonly DataContext _context;
        public BuyChargeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var BuyCharges = await _context.TblHblCharges
                .Where(c => c.HblId == id && c.Buy == true)
                .ToListAsync();

            BuyChargeVM buyChargeVM = new BuyChargeVM
            {
                HBL_Id = id,
                _charges = BuyCharges.Select(c => new BuyChargeEM
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
                    Buy = c.Buy,
                    HblId = c.HblId
                }).ToList()
            };

            return View(buyChargeVM);
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            var buyChargeEM = new BuyChargeEM
            {
                HblId = id,
                CreatedDate = DateTime.Now,
                Buy = true
            };
            return View(buyChargeEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuyChargeEM buyChargeEM)
        {
            if (ModelState.IsValid)
            {
                var charge = new TblHblCharges
                {
                    ChargeId = Guid.NewGuid().ToString(),
                    SupplierId = buyChargeEM.SupplierId,
                    SerName = buyChargeEM.SerName,
                    SerUnit = buyChargeEM.SerUnit,
                    SerQuantity = buyChargeEM.SerQuantity,
                    SerPrice = buyChargeEM.SerPrice,
                    Currency = buyChargeEM.Currency,
                    ExchangeRate = buyChargeEM.ExchangeRate,
                    SerVat = buyChargeEM.SerVat,
                    MVat = buyChargeEM.MVat,
                    Checked = false,
                    CreatedDate = DateTime.Now,
                    Buy = true,
                    HblId = buyChargeEM.HblId
                };

                _context.Add(charge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = buyChargeEM.HblId });
            }
            return View(buyChargeEM);
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

            var buyChargeEM = new BuyChargeEM
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
                Buy = charge.Buy,
                HblId = charge.HblId
            };

            return View(buyChargeEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, BuyChargeEM buyChargeEM)
        {
            if (id != buyChargeEM.ChargeId)
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

                    charge.SupplierId = buyChargeEM.SupplierId;
                    charge.SerName = buyChargeEM.SerName;
                    charge.SerUnit = buyChargeEM.SerUnit;
                    charge.SerQuantity = buyChargeEM.SerQuantity;
                    charge.SerPrice = buyChargeEM.SerPrice;
                    charge.Currency = buyChargeEM.Currency;
                    charge.ExchangeRate = buyChargeEM.ExchangeRate;
                    charge.SerVat = buyChargeEM.SerVat;
                    charge.MVat = buyChargeEM.MVat;
                    charge.UpdatedDate = DateTime.Now;

                    _context.Update(charge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ChargeExists(buyChargeEM.ChargeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = buyChargeEM.HblId });
            }
            return View(buyChargeEM);
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

            var buyChargeEM = new BuyChargeEM
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
                Buy = charge.Buy,
                HblId = charge.HblId
            };

            return View(buyChargeEM);
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

                // Group charges by supplier for invoice number generation
                var supplierGroups = charges.GroupBy(c => c.SupplierId);
                foreach (var group in supplierGroups)
                {
                    string invoiceNo = null;
                    var chargesToCheck = group.Where(c => 
                        request.chargegroup.First(cg => cg.chargeid == c.ChargeId).isSelected && 
                        (c.Checked == null || c.Checked == false)).ToList();

                    if (chargesToCheck.Any())
                    {
                        // Generate invoice number: SUP{SupplierID}_{Timestamp}
                        invoiceNo = $"SUP{group.Key}_{DateTime.Now:yyyyMMddHHmmss}";
                    }

                    foreach (var charge in group)
                    {
                        var chargeInfo = request.chargegroup.First(c => c.chargeid == charge.ChargeId);
                        charge.Checked = chargeInfo.isSelected;
                        charge.UpdatedDate = DateTime.Now;

                        // Only set invoice number if we're checking the charge and it doesn't already have one
                        if (chargeInfo.isSelected && string.IsNullOrEmpty(charge.InvoiceNo))
                        {
                            charge.InvoiceNo = invoiceNo;
                        }
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
