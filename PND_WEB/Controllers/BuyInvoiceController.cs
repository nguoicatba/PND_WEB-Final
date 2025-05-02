using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class BuyInvoiceController : Controller
    {

        private readonly DataContext _context;
        public BuyInvoiceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var invoice = await _context.TblInvoices
                .Where(x => x.Hbl == id && x.Buy == true)
                .ToListAsync();
            var invoiceViewModel = new InvoiceViewModel
            {
                HBL_ID = id,
                invoices = invoice
            };
            return View(invoiceViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {

            InvoiceEditModel invoiceEditModel = new InvoiceEditModel
            {
                HBL_ID = id,
                invoice = new TblInvoice()
            };
            return View(invoiceEditModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceEditModel invoiceEditModel)
        {
            if (ModelState.IsValid)
            {
                var invoice = new TblInvoice
                {
                    Hbl = invoiceEditModel.HBL_ID,
                    InvoiceType = invoiceEditModel.invoice.InvoiceType,
                    DebitDate = invoiceEditModel.invoice.DebitDate == null ? DateTime.Now : invoiceEditModel.invoice.DebitDate,
                    PaymentDate = invoiceEditModel.invoice.PaymentDate,
                    InvoiceNo = invoiceEditModel.invoice.InvoiceNo,
                    InvoiceDate = invoiceEditModel.invoice.InvoiceDate,
                    SupplierId = invoiceEditModel.invoice.SupplierId,
                    Buy = true,
                    Sell = false,
                    Cont = false
                };
                _context.TblInvoices.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = invoice.Hbl });
            }
            return View(invoiceEditModel);
        }



        public async Task<JsonResult> InvoiceTypeGet(string q, int page = 1)
        {
            int pageSize = 10;
            var query = _context.InvoiceTypes
                .Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.NameType.Contains(q.ToLower()));
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Json(new
            {
                items = paginatedData.Select(data => new
                {
                    id = data.Code,
                    text = data.NameType
                }).ToList(),
                total_count = totalCount
            });
        }

        public async Task<JsonResult> SupplierGet(string q, int page = 1)
        {
            int pageSize = 10;
            var query = _context.TblSuppliers
                .Where(data => data.SupplierId.ToLower().Contains(q.ToLower()) || data.NameSup.ToLower().Contains(q.ToLower()));
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Json(new
            {
                items = paginatedData.Select(data => new
                {
                    id = data.SupplierId,
                    text = data.NameSup
                }).ToList(),
                total_count = totalCount
            });
        }
    }
}
