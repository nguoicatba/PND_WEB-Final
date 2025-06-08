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
                JOB_Id = _context.TblHbls
                    .Where(h => h.Hbl == id)
                    .Select(h => h.RequestId)
                    .FirstOrDefault(),
                _charges = SellCharges.Select(c => new SellChargeEM
                {
                    ChargeId = c.ChargeId,
                    CustomerID = c.CustomerId,
                    CustomerName = _context.TblCustomers
                        .Where(s => s.CustomerId == c.CustomerId)
                        .Select(s => s.CompanyName)
                        .FirstOrDefault() ?? "Unknown Customer",
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
        [ClaimAuthorize("Sell Charge", "Create")]
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
        [ClaimAuthorize("Sell Charge", "Edit")]
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
        [ClaimAuthorize("Sell Charge", "Delete")]
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
        public async Task<IActionResult> GetBuyCharges(string hblId)
        {
            var buyCharges = await _context.TblHblCharges
                .Where(c => c.HblId == hblId && c.Buy == true)
                .Select(c => new BuyChargeEM
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
                    HblId = c.HblId
                })
                .ToListAsync();

            return PartialView("_BuyChargesPartial", buyCharges);
        }

        [HttpPost]
        public async Task<IActionResult> ImportBuyCharges([FromBody] ImportBuyCharges request)
        {
            if (request.ChargeIds == null)
            {
                return Json(new { success = false, message = "Invalid input data." });
            }   
            try
            {
                var buyCharges = await _context.TblHblCharges
                    .Where(c => request.ChargeIds.Contains(c.ChargeId))
                    .ToListAsync();

              
              
                var newSellCharges = buyCharges.Select(bc => new TblHblCharges
                {
                    ChargeId = Guid.NewGuid().ToString(),
                    CustomerId = null, // Set customer ID to null as requested
                    SerName = bc.SerName,
                    SerUnit = bc.SerUnit,
                    SerQuantity = bc.SerQuantity,
                    SerPrice = bc.SerPrice,
                    Currency = bc.Currency,
                    ExchangeRate = bc.ExchangeRate,
                    SerVat = bc.SerVat,
                    MVat = bc.MVat,
                    Checked = false,
                    CreatedDate = DateTime.Now,
                    Sell = true,
                    HblId = request.HblId
                });

                await _context.TblHblCharges.AddRangeAsync(newSellCharges);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        private async Task<string> GenerateCode(string prefix)
        {
            string Date = DateTime.Now.ToString("yyyyMMdd");
            var lastInvoice = await _context.invoices
                .Where(i => i.InvoiceNo.StartsWith(prefix) && i.InvoiceNo.Contains(Date))
                .OrderByDescending(i => i.InvoiceDate)
                .FirstOrDefaultAsync();
            if (lastInvoice == null)
            {
                return $"{prefix}{Date}0001";
            }
            else
            {
                string lastCode = lastInvoice.InvoiceNo.Substring(prefix.Length + Date.Length);
                int newCode = int.Parse(lastCode) + 1;
                return $"{prefix}{Date}{newCode:D4}";
            }
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

                // Group charges by customer for invoice number generation
                var listinvoie = await _context.invoices
                    .Where(i => i.Hbl == request.hblId && i.Type == "Debit Note").ToListAsync();

                foreach (var charge in charges)
                {
                    var chargeGroup = request.chargegroup.FirstOrDefault(cg => cg.chargeid == charge.ChargeId);
                    if (chargeGroup != null)
                    {
                        charge.Checked = chargeGroup.isSelected;
                    }
                }

                foreach (var invoice in listinvoie)
                {
                    var existingCharges = charges.Where(c => c.CustomerId == invoice.Partner && c.Checked == true).ToList();
                    if (!existingCharges.Any())
                    {
                        var charge_invoice = await _context.InvoiceCharges
                            .Where(ic => ic.InvoiceId == invoice.Id)
                            .ToListAsync();
                        _context.InvoiceCharges.RemoveRange(charge_invoice);
                        _context.invoices.Remove(invoice);
                    }
                }

                foreach (var charge in charges)
                {
                    if (charge.Checked == true)
                    {
                        var existingInvoice = await _context.invoices
                            .FirstOrDefaultAsync(i => i.Partner == charge.CustomerId && i.Hbl == charge.HblId && i.Type == "Credit Note");
                        if (existingInvoice == null)
                        {
                            var newInvoice = new Invoice
                            {
                                Id = Guid.NewGuid().ToString(),
                                Partner = charge.CustomerId,
                                InvoiceNo = await GenerateCode("DBN"),
                                Type = "Debit Note",
                                Currency = "USD",
                                ExchangeRate = 1.0f,
                                DebitDate = DateTime.Now,
                                PaymentDate = DateTime.Now,
                                InvoiceDate = DateTime.Now,
                                Hbl = charge.HblId,
                            };
                            _context.invoices.Add(newInvoice);
                            await _context.SaveChangesAsync();

                            charge.InvoiceNo = newInvoice.InvoiceNo;
                        }
                        else
                        {
                            charge.InvoiceNo = existingInvoice.InvoiceNo;
                        }
                    }
                    else
                    {
                        charge.InvoiceNo = "";
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