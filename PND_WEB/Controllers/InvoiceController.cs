using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PND_WEB.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly DataContext _context;

        public InvoiceController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string jobNo, string hbl, string invoiceNo, 
            string type, string dateType, DateTime? fromDate, DateTime? toDate)
        {
            // Store search parameters in ViewBag for form persistence
            ViewBag.JobNo = jobNo;
            ViewBag.Hbl = hbl;
            ViewBag.InvoiceNo = invoiceNo;
            ViewBag.Type = type;
            ViewBag.DateType = dateType ?? "debit"; // Default to debit date if not specified
            ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

            var query = _context.invoices.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(hbl))
            {
                query = query.Where(i => i.Hbl.Contains(hbl));
            }

            if (!string.IsNullOrEmpty(invoiceNo))
            {
                query = query.Where(i => i.InvoiceNo.Contains(invoiceNo));
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(i => i.Type == type);
            }

            if (fromDate.HasValue && toDate.HasValue)
            {
                var endDate = toDate.Value.Date.AddDays(1).AddSeconds(-1);
                switch (dateType?.ToLower())
                {
                    case "debit":
                        query = query.Where(i => i.DebitDate >= fromDate.Value.Date && i.DebitDate <= endDate);
                        break;
                    case "payment":
                        query = query.Where(i => i.PaymentDate >= fromDate.Value.Date && i.PaymentDate <= endDate);
                        break;
                    default: // "invoice" or null
                        query = query.Where(i => i.InvoiceDate >= fromDate.Value.Date && i.InvoiceDate <= endDate);
                        break;
                }
            }

            var invoices = await query
                .Select(i => new InvoiceVM
                {
                    Id = i.Id,
                    InvoiceNo = i.InvoiceNo,
                    Type = i.Type,
                    Partner = i.Partner,
                    Currency = i.Currency,
                    ExchangeRate = i.ExchangeRate,
                    DebitDate = i.DebitDate,
                    PaymentDate = i.PaymentDate,
                    InvoiceDate = i.InvoiceDate,
                    Hbl = i.Hbl,
                    InvoiceType = i.Type
                })
                .ToListAsync();

            return View(invoices);
        }

     

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.invoices
                .Select(i => new InvoiceVM
                {
                    Id = i.Id,
                    InvoiceNo = i.InvoiceNo,
                    Type = i.Type,
                    Partner = i.Partner,
                    Currency = i.Currency,
                    ExchangeRate = i.ExchangeRate,
                    DebitDate = i.DebitDate,
                    PaymentDate = i.PaymentDate,
                    InvoiceDate = i.InvoiceDate,
                    Hbl = i.Hbl
                })
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }

            var charges = await _context.TblHblCharges
              .Where(c => c.InvoiceNo == invoice.InvoiceNo && c.Checked == true)
              .ToListAsync();

            foreach (var charge in charges)
            {
                var existingCharge = await _context.InvoiceCharges
                    .FirstOrDefaultAsync(c => c.Id == charge.ChargeId);
                if (existingCharge != null)
                {
                    // Update existing charge
                    existingCharge.SerUnit = charge.SerUnit;
                    existingCharge.SerQuantity = charge.SerQuantity;
                    existingCharge.SerPrice = charge.SerPrice;
                    existingCharge.Currency = charge.Currency;
                    existingCharge.ExchangeRate = charge.ExchangeRate;
                    existingCharge.SerVat = charge.SerVat;
                    existingCharge.MVat = charge.MVat;

                }
                else
                {
                    // Add new charge
                    var newCharge = new InvoiceCharge
                    {
                        Id = charge.ChargeId,
                        InvoiceId = invoice.Id,
                        SerName = charge.SerName,
                        SerUnit = charge.SerUnit,
                        SerQuantity = charge.SerQuantity,
                        SerPrice = charge.SerPrice,
                        Currency = charge.Currency,
                        ExchangeRate = charge.ExchangeRate,
                        SerVat = charge.SerVat,
                        MVat = charge.MVat,
                        
                        Checked = false // Ensure it's checked
                    };
                    _context.InvoiceCharges.Add(newCharge);
                }
            }
            // Remove charges that are not in the HBL charges
            var existingCharges = await _context.InvoiceCharges
                .Where(c => c.InvoiceId == id)
                .ToListAsync();
            foreach (var existingCharge in existingCharges)
            {
                if (!charges.Any(c => c.ChargeId == existingCharge.Id))
                {
                    _context.InvoiceCharges.Remove(existingCharge);
                }
            }
            await _context.SaveChangesAsync();







            var viewModel = new InvoiceDetailsVM
            {
                Invoice = invoice,
                Charges = await _context.InvoiceCharges
                    .Where(c => c.InvoiceId == id)
                    .ToListAsync()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInvoice(InvoiceDetailsVM model)
        {
           

            try
            {
                var invoice = await _context.invoices.FindAsync(model.Invoice.Id);
                if (invoice == null)
                {
                    TempData["Error"] = "Invoice not found";
                    return RedirectToAction(nameof(Index));
                }


                invoice.Partner = model.Invoice.Partner;
                invoice.InvoiceNo = model.Invoice.InvoiceNo;
                invoice.Type = model.Invoice.Type;
                invoice.Currency = model.Invoice.Currency;
                invoice.ExchangeRate = model.Invoice.ExchangeRate;
                invoice.DebitDate = model.Invoice.DebitDate;
                invoice.PaymentDate = model.Invoice.PaymentDate;
                invoice.InvoiceDate = model.Invoice.InvoiceDate;


                await _context.SaveChangesAsync();
                TempData["Success"] = "Invoice updated successfully";
                return RedirectToAction(nameof(Details), new { id = model.Invoice.Id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error updating invoice: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id = model.Invoice.Id });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSelectedCharges([FromBody] List<ChargeStatusVM> charges)
        {
            if (charges == null || !charges.Any())
            {
                return Json(new { success = false, message = "No charges to update" });
            }

            try
            {
                foreach (var charge in charges)
                {
                    var existingCharge = await _context.InvoiceCharges.FindAsync(charge.ChargeId);
                    if (existingCharge != null)
                    {
                        existingCharge.Checked = charge.IsChecked;
                    }
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

      
    }
} 