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

            InvoiceEditModel invoiceEditModel = new InvoiceEditModel();
            invoiceEditModel.HBL_ID = id;
            invoiceEditModel.invoice = new TblInvoice();
            invoiceEditModel.invoice.Hbl=id;

            return View(invoiceEditModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceEditModel invoiceEditModel)
        {
            if (ModelState.IsValid)
            {
                if (invoiceEditModel.invoice != null) // Ensure invoice is not null  
                {
                   
                    var invoice = new TblInvoice
                    {
                        DebitId = invoiceEditModel.invoice.DebitId,
                        Hbl = invoiceEditModel.HBL_ID,
                        InvoiceType = invoiceEditModel.invoice.InvoiceType,
                        DebitDate = invoiceEditModel.invoice.DebitDate ?? DateTime.Now,
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
                else
                {
                    ModelState.AddModelError(string.Empty, "Invoice data is required.");
                }
            }
            return View(invoiceEditModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var invoice = await _context.TblInvoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var invoiceEditModel = new InvoiceEditModel
            {
                HBL_ID = invoice.Hbl,
                invoice = invoice
            };
            return View(invoiceEditModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceEditModel invoiceEditModel)
        {
            if (ModelState.IsValid)
            {
                if (invoiceEditModel.invoice?.DebitId != null) 
                {
                    var invoice = await _context.TblInvoices.FindAsync(invoiceEditModel.invoice.DebitId);
                    if (invoice != null)
                    {
                        invoice.InvoiceType = invoiceEditModel.invoice.InvoiceType;
                        invoice.DebitDate = invoiceEditModel.invoice.DebitDate;
                        invoice.PaymentDate = invoiceEditModel.invoice.PaymentDate;
                        invoice.InvoiceNo = invoiceEditModel.invoice.InvoiceNo;
                        invoice.InvoiceDate = invoiceEditModel.invoice.InvoiceDate;
                        invoice.SupplierId = invoiceEditModel.invoice.SupplierId;
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", new { id = invoice.Hbl });
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invoice or DebitId is required.");
                }
            }
            return View(invoiceEditModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var invoice = await _context.TblInvoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var invoiceEditModel = new InvoiceEditModel
            {
                HBL_ID = invoice.Hbl,
                invoice = invoice
            };
            return View(invoiceEditModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var invoice = await _context.TblInvoices.FindAsync(id);
            if (invoice != null)
            {
                _context.TblInvoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = invoice.Hbl });
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var invoice = await _context.TblInvoices
                .Include(i => i.HblNavigation)
                .FirstOrDefaultAsync(i => i.DebitId == id);
            if (invoice == null)
            {
                return NotFound();
            }
            
            var invoiceChargeViewModel = new InvoiceChargeViewModel
            {
                HBL_ID = invoice.Hbl,
                Invoice = invoice,
                _Charges = await _context.TblCharges
                    .Where(c => c.DebitId == id)
                    .ToListAsync(),
                TotalAmount = await _context.TblCharges
                    .Where(c => c.DebitId == id)
                    .SumAsync(c => (c.SerPrice ?? 0) * (c.SerQuantity ?? 0) * (c.ExchangeRate ?? 1) * (1 + (c.SerVat ?? 0) / 100) + (c.MVat ?? 0))

            };
            return View(invoiceChargeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCharge(string id)
        {
            var invoice = await _context.TblInvoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var invoiceChargeEditModel = new InvoiceChargeEditModel();

            invoiceChargeEditModel.HBL_ID = invoice.Hbl;
            invoiceChargeEditModel.InvoiceID = invoice.DebitId;
            invoiceChargeEditModel.Charge = new TblCharge();
            invoiceChargeEditModel.Charge.DebitId = invoice.DebitId;
           
            return View(invoiceChargeEditModel);
        }
        
        



        public async Task<JsonResult> InvoiceTypeGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.InvoiceTypes : _context.InvoiceTypes
                .Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.NameType.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.NameType,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new { id = "-1", text = "Select Invoice Type", disabled = true });
            }
            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "Code",
                    header_name = "Invoice Type"
                }
            });



        }

        public async Task<JsonResult> SupplierGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.TblSuppliers : _context.TblSuppliers
                .Where(data => data.SupplierId.ToLower().Contains(q.ToLower()) || data.NameSup.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.SupplierId,
                text = data.NameSup,

                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new { id = "-1", text = "Select Supplier", disabled = true });
            }


            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "Supplier Code",
                    header_name = "Supplier Name"
                }

            });
        }
    }
}
