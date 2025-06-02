using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

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

            // Get charges from InvoiceCharge
            var charges = await _context.InvoiceCharges
                .Where(c => c.InvoiceId == invoice.InvoiceNo)
              
                .ToListAsync();

            var viewModel = new InvoiceDetailsVM
            {
                Invoice = invoice,
                Charges = charges
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInvoice(InvoiceVM model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid model state" });
            }

            try
            {
                var invoice = await _context.invoices.FindAsync(model.Id);
                if (invoice == null)
                {
                    return Json(new { success = false, message = "Invoice not found" });
                }

                invoice.Partner = model.Partner;
                invoice.Currency = model.Currency;
                invoice.ExchangeRate = model.ExchangeRate;
                invoice.DebitDate = model.DebitDate;
                invoice.PaymentDate = model.PaymentDate;

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Invoice updated successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error updating invoice: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChargeStatus([FromBody] UpdateChargeStatusVM model)
        {
            try
            {
                var charge = await _context.InvoiceCharges.FindAsync(model.ChargeId);
                if (charge == null)
                {
                    return Json(new { success = false, message = "Charge not found" });
                }

                charge.Checked = model.IsChecked;
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