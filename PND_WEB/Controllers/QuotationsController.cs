using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;
using PND_WEB.ViewModels;
using Rotativa.AspNetCore;

namespace PND_WEB.Controllers
{
    public class QuotationsController : Controller
    {
        private readonly DataContext _context;

        public QuotationsController(DataContext context)
        {
            _context = context;
        }

        // GET: Quotations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quotations.ToListAsync());
        }

        public async Task<string> CreateQuotationCode()
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"QTN{datePart}";

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int countThisMonth = await _context.Quotations
                        .Where(q => q.QuotationId.StartsWith(prefix))
                        .CountAsync();

                    int nextNumber = countThisMonth + 1;

                    string quotationCode = $"{prefix}{nextNumber}";

                    await transaction.CommitAsync();
                    return quotationCode;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        //Quotations

        public async Task<IActionResult> Create()
        {
            var model = new Quotation
            {
                QuotationId = await CreateQuotationCode(),
                Qsatus = "Đang đàm phán"
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuotationId,Qsatus,StaffName,Contact,Qdate,CusTo,CusContact,Valid,Term,Vol,Commodity,Pol,Adds,Pod")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quotation);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }
            ViewBag.QsatusList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Đang đàm phán", Text = "Đang đàm phán" },
                new SelectListItem { Value = "Đã chốt, chưa vận chuyển", Text = "Đã chốt, chưa vận chuyển" },
                new SelectListItem { Value = "Đang vận chuyển", Text = "Đang vận chuyển" },
                new SelectListItem { Value = "Đã hủy", Text = "Đã hủy" },
                new SelectListItem { Value = "Hoàn thành", Text = "Hoàn thành" }
            };
            return View(quotation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("QuotationId,Qsatus,StaffName,Contact,Qdate,CusTo,CusContact,Valid,Term,Vol,Commodity,Pol,Adds,Pod")] Quotation quotation)
        {
            if (id != quotation.QuotationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationExists(quotation.QuotationId))
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
            return View(quotation);
        }


        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (quotation == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = quotation,
                QuotationsCharges = quotation.QuotationsCharges.ToList()
            };

            return View(viewModel);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation != null)
            {
                var relatedCharges = _context.QuotationsCharges.Where(qc => qc.QuotationId == id);
                _context.QuotationsCharges.RemoveRange(relatedCharges);
                _context.Quotations.Remove(quotation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuotationExists(string id)
        {
            return _context.Quotations.Any(e => e.QuotationId == id);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotations
                .FirstOrDefaultAsync(m => m.QuotationId == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }




        //QuotationCharges

        public IActionResult CreateCharges(string id)
        {
            var quotation = _context.Quotations.FirstOrDefault(q => q.QuotationId == id);
            if (quotation == null)
                return NotFound();

            var model = new QuotationsCharge
            {
                QuotationId = id,

                Quantity = 0,
                Rate =0,
            };

            ViewBag.CurrencyList = new SelectList(_context.Currencies, "Code", "Code");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCharges([Bind("ChargeId,QuotationId,ChargeName,Quantity,Unit,Rate,Currency,Notes")] QuotationsCharge quotationsCharge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quotationsCharge);
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsCharges", new { id = quotationsCharge.QuotationId });
            }
            ViewData["QuotationId"] = new SelectList(_context.Quotations, "QuotationId", "QuotationId", quotationsCharge.QuotationId);
            return View(quotationsCharge);
        }

        public IActionResult EditCharges(int id)
        {
            var charge = _context.QuotationsCharges.FirstOrDefault(c => c.ChargeId == id);
            if (charge == null)
                return NotFound();

            ViewBag.QuotationId = new SelectList(_context.Quotations, "QuotationId", "QuotationId", charge.QuotationId);
            ViewBag.CurrencyList = new SelectList(_context.Currencies, "Code", "Code", charge.Currency);

            return View(charge);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCharges(int id, [Bind("ChargeId,QuotationId,ChargeName,Quantity,Unit,Rate,Currency,Notes")] QuotationsCharge quotationsCharge)
        {
            if (id != quotationsCharge.ChargeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quotationsCharge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationsChargeExists(quotationsCharge.ChargeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("DetailsCharges", new { id = quotationsCharge.QuotationId });
            }

            ViewData["QuotationId"] = new SelectList(_context.Quotations, "QuotationId", "QuotationId", quotationsCharge.QuotationId);
            ViewBag.CurrencyList = new SelectList(_context.Currencies, "Code", "Code", quotationsCharge.Currency);

            return View("Edit", quotationsCharge);
        }

        public async Task<IActionResult> DeleteCharges(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotationsCharge = await _context.QuotationsCharges
                .Include(q => q.Quotation)
                .FirstOrDefaultAsync(m => m.ChargeId == id);
            if (quotationsCharge == null)
            {
                return NotFound();
            }

            return View(quotationsCharge);
        }

        [HttpPost, ActionName("DeleteCharges")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChargesConfirmed(int id)
        {
            var quotationsCharge = await _context.QuotationsCharges.FindAsync(id);
            if (quotationsCharge != null)
            {
                _context.QuotationsCharges.Remove(quotationsCharge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("DetailsCharges", new { id = quotationsCharge.QuotationId });
        }

        private bool QuotationsChargeExists(int id)
        {
            return _context.QuotationsCharges.Any(e => e.ChargeId == id);
        }

        public async Task<IActionResult> DetailsCharges(string id)
        {
            var quotation = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (quotation == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = quotation,
                QuotationsCharges = quotation.QuotationsCharges.ToList()
            };

            return View(viewModel);
        }




        //AutoComplete 

        [HttpPost]
        public JsonResult AutoCompleteCports(string prefix)
        {
            var cports = (from cport in this._context.Cports
                             where cport.PortName.Contains(prefix)
                             select new
                             {
                                 label = cport.PortName,
                                 val = cport.Code
                             }).ToList();

            return Json(cports);
        }

        [HttpPost]
        public JsonResult AutoCompleteCustomers(string prefix)
        {
            var customer = (from customers in this._context.TblCustomers
                          where customers.DutyPerson.Contains(prefix)
                          select new
                          {
                              label = customers.DutyPerson,
                              label2 = customers.Contact
                          }).ToList();

            return Json(customer);
        }

        [HttpPost]
        public JsonResult AutoCompleteFees(string prefix)
        {
            var fees = (from fee in this._context.Fees
                            where fee.Fee1.Contains(prefix)
                            select new
                            {
                                label = fee.Fee1,
                                val = fee.Code
                            }).ToList();

            return Json(fees);
        }

        [HttpPost]
        public JsonResult AutoCompleteUnits(string prefix)
        {
            var units = (from unit in this._context.Units
                        where unit.Code.Contains(prefix)
                        select new
                        {
                            label = unit.Code,
                        }).ToList();

            return Json(units);
        }


        //ExportPDF
        public async Task<IActionResult> ExportPDFQuotations(string id)
        {
            var quotation = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (quotation == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = quotation,
                QuotationsCharges = quotation.QuotationsCharges.ToList()
            };

            return new ViewAsPdf("ExportPDFQuotations", viewModel);
        }

    }
}
