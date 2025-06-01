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
            string type, DateTime? fromDate, DateTime? toDate)
        {
            // Store search parameters in ViewBag for form persistence
            ViewBag.JobNo = jobNo;
            ViewBag.Hbl = hbl;
            ViewBag.InvoiceNo = invoiceNo;
            ViewBag.Type = type;
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

            if (fromDate.HasValue)
            {
                query = query.Where(i => i.InvoiceDate >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                query = query.Where(i => i.InvoiceDate <= toDate.Value.Date.AddDays(1).AddSeconds(-1));
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
                    InvoiceType = (i.Type == "sellcharge" || i.Type == "debit") ? "Debit" : "Credit",
                    PartnerType = (i.Type == "sellcharge" || i.Type == "debit") ? "Customer" : "Supplier"
                })
                .ToListAsync();

            return View(invoices);
        }
    }
} 