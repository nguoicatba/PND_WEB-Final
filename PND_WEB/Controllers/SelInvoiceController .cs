using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.Services;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class SelInvoiceController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        //pdf

        private readonly IViewRenderService _viewRenderService;
        private readonly IConverter _converter;

        public SelInvoiceController(ILogger<HomeController> logger, DataContext context, IConverter converter, IViewRenderService viewRenderService)
        {
            _logger = logger;
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var invoice = await _context.TblInvoices
                .Where(x => x.Hbl == id && x.Sell == true)
                .ToListAsync();
            var invoiceViewModel = new InvoiceViewModel
            {
                HBL_ID = id,
                invoices = invoice,
                GoodType = await _context.TblJobs
                    .Where(x => x.TblHbls.Any(h => h.Hbl == id))
                    .Select(x => x.GoodsType)
                    .FirstOrDefaultAsync()

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

        public async Task<string> GenerateCode(string prefix)
        {
            string Date = DateTime.Now.ToString("yyyyMMdd");
            var lastInvoice = await _context.TblInvoices
                .Where(i => i.DebitId.StartsWith(prefix) && i.DebitId.Contains(Date))
                .OrderByDescending(i => i.InvoiceDate)
                .FirstOrDefaultAsync();
            if (lastInvoice == null)
            {
                return $"{prefix}{Date}0001";
            }
            else
            {
                string lastCode = lastInvoice.DebitId.Substring(prefix.Length + Date.Length);
                int newCode = int.Parse(lastCode) + 1;
                return $"{prefix}{Date}{newCode:D4}";

            }
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
                        DebitId = await GenerateCode("SEL"),
                        Hbl = invoiceEditModel.HBL_ID,
                        InvoiceType = invoiceEditModel.invoice.InvoiceType,
                        DebitDate = invoiceEditModel.invoice.DebitDate ?? DateTime.Now,
                        PaymentDate = invoiceEditModel.invoice.PaymentDate,
                        InvoiceNo = invoiceEditModel.invoice.InvoiceNo,
                        InvoiceDate = invoiceEditModel.invoice.InvoiceDate,
                        SupplierId = invoiceEditModel.invoice.SupplierId,
                        Buy = false,
                        Sell = true,
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
        public async Task<IActionResult> Delete(string id, InvoiceEditModel invoiceEditModel)
        {
            if (id == null)
            {
                return NotFound();
            }
            var invoice = await _context.TblInvoices.FindAsync(id);
            if (invoice != null)
            {
                _context.TblCharges.RemoveRange(_context.TblCharges.Where(c => c.DebitId == invoice.DebitId));
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCharge(InvoiceChargeEditModel invoiceChargeEditModel)
        {
            if (ModelState.IsValid)
            {
                if (invoiceChargeEditModel.Charge != null) // Ensure charge is not null  
                {
                    var charge = new TblCharge
                    {
                        DebitId = invoiceChargeEditModel.Charge.DebitId,
                        SerName = invoiceChargeEditModel.Charge.SerName,
                        SerUnit = invoiceChargeEditModel.Charge.SerUnit,
                        SerQuantity = invoiceChargeEditModel.Charge.SerQuantity,
                        SerPrice = invoiceChargeEditModel.Charge.SerPrice,
                        Currency = invoiceChargeEditModel.Charge.Currency,
                        ExchangeRate = invoiceChargeEditModel.Charge.ExchangeRate,
                        SerVat = invoiceChargeEditModel.Charge.SerVat,
                        MVat = invoiceChargeEditModel.Charge.MVat
                    };
                    _context.TblCharges.Add(charge);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = charge.DebitId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Charge data is required.");
                }
            }
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

        public async Task<JsonResult> FeeGet (string q="",int page=1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Fees : _context.Fees
                .Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.Fee1.ToLower().Contains(q.ToLower())||data.Unit.ToLower().Contains(q.ToLower()));
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
                items.Insert(0, new { id = "-1", text = "Select Fee",unit="", disabled = true });
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
  
        public async Task<JsonResult> CurrencyGet (string q="",int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Currencies : _context.Currencies
                .Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.CurrName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.CurrName,
                disabled = false,
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new { id = "-1", text = "Select Currency", disabled = true });
            }
            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "Code",
                    header_name = "Name"
                }
            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveData([FromBody] List<TblCharge> data)
        {
            if (data == null)
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ." });
            }
            // get list charge in db where DebitId = data[0].DebitId
            var existingList = await _context.TblCharges
                .Where(x => x.DebitId == data[0].DebitId)
                .ToListAsync();
           
            _context.TblCharges.RemoveRange(existingList);
          
            
            foreach (var item in data)
            {
                var charge = new TblCharge
                {
                    DebitId = item.DebitId,
                    SerName = item.SerName,
                    SerUnit = item.SerUnit,
                    SerQuantity = item.SerQuantity,
                    SerPrice = item.SerPrice,
                    Currency = item.Currency,
                    ExchangeRate = item.ExchangeRate,
                    SerVat = item.SerVat,
                    MVat = item.MVat,
                    Checked = item.Checked
                };
                _context.TblCharges.Add(charge);
            }
        
            // 5. Lưu thay đổi vào CSDL
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Lưu dữ liệu thành công!" });

        }


        public async Task<IActionResult> DebitNoteExport(string id)
        {

            var invoice = await _context.TblInvoices
                .FirstOrDefaultAsync(i => i.DebitId == id);
            var Hbl = await _context.TblHbls
                
                .FirstOrDefaultAsync(h => h.Hbl == invoice.Hbl);
            var job = await _context.TblJobs
                .Include(j => j.TblHbls)
                .FirstOrDefaultAsync(j => j.JobId == Hbl.RequestId) ;

            DebitNoteExport viewModel = new DebitNoteExport
            {
                JobId = job.JobId,
                JobType = job.GoodsType,
                Cnee =Hbl.Cnee,
                HBL = Hbl.Hbl,
                MBL = job.Mbl,
           
                ETA = job.Eta,
                Quantity = Hbl.Quantity,
                GrossWeight = Hbl.GrossWeight,
                CBM = Hbl.Tonnage,
                Transport = job.VoyageName == null || job.VoyageName == null ? "" : job.VoyageName.ToString()+"/"+ job.VesselName.ToString(),
                POL = job.Pol,
                POD = job.Pod,
                PODel = job.Podel,
                Total = await _context.TblCharges
                    .Where(c => c.DebitId == id)
                    .SumAsync(c => (c.SerPrice ?? 0) * (c.SerQuantity ?? 0) * (c.ExchangeRate ?? 1) * (1 + (c.SerVat ?? 0) / 100) + (c.MVat ?? 0)),
                Charges = await _context.TblCharges.Where(c => c.DebitId == id).ToListAsync()
            };
           

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFDebitNote", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=debit.pdf");
            return File(file, "application/pdf");
        }



    }
}
