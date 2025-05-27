using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;
using PND_WEB.ViewModels;
using Microsoft.AspNetCore.Identity;
using DinkToPdf;
using DinkToPdf.Contracts;
using PND_WEB.Services;
namespace PND_WEB.Controllers
{
    public class QuotationsController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IConverter _converter;
        private readonly IViewRenderService _viewRenderService;

        public QuotationsController(DataContext context, UserManager<AppUserModel> userManager, IConverter converter, IViewRenderService viewRenderService)
        {
            _context = context;
            _userManager = userManager;
            _converter = converter;
            _viewRenderService = viewRenderService;
        }
        // GET: Quotations
        public IActionResult Index()
        {
            if (User.IsInRole("Sale"))
            {
                return RedirectToAction(nameof(IndexUser));
            }
            else if (User.IsInRole("DOC") || User.IsInRole("Accountant") || User.IsInRole("CEO") || User.HasClaim("QuotationsAdmin", "AdminView") || User.HasClaim("QuotationsAdmin", "AdminViewDetails"))
            {
                return RedirectToAction(nameof(IndexAdmin));
            }
            return NotFound();
        }

        public async Task<IActionResult> IndexUser()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            var quotations = await _context.Quotations
                .Where(q => q.StaffName == user.Staff_Name)
                .ToListAsync();

            return View(quotations);
        }

        public async Task<IActionResult> IndexAdmin()
        {
            var quotations = await _context.Quotations
                .ToListAsync();

            return View(quotations);
        }

        // FUNCTIONS
        public async Task<string> PredictQuotationCode()
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"QTN{datePart}";

            var quotationsWithPrefix = await _context.Quotations
                .Where(q => q.QuotationId.StartsWith(prefix))
                .Select(q => q.QuotationId)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var quotationId in quotationsWithPrefix)
            {
                if (quotationId.Length >= prefix.Length + 3 &&
                    int.TryParse(quotationId.Substring(prefix.Length, 3), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            int nextNumber = maxNumber + 1;

            return $"{prefix}{nextNumber:D3}";
        }



        public async Task<string> GenerateQuotationCode()
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"QTN{datePart}";

            var quotationsWithPrefix = await _context.Quotations
                .Where(q => q.QuotationId.StartsWith(prefix))
                .Select(q => q.QuotationId)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var quotationId in quotationsWithPrefix)
            {
                if (quotationId.Length >= prefix.Length + 3 &&
                    int.TryParse(quotationId.Substring(prefix.Length, 3), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            int nextNumber = maxNumber + 1;

            return $"{prefix}{nextNumber:D3}";
        }



        //Quotations
        [ClaimAuthorize("Quotation", "Create")]
        public async Task<IActionResult> Create()
        {
            var username = User.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);
            var model = new Quotation
            {
                QuotationId = await PredictQuotationCode(),
                Qsatus = "Đang đàm phán",
                StaffName = user.Staff_Name,
                Qdate = DateTime.Now,
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuotationId,Qsatus,StaffName,Contact,Qdate,CusTo,CusContact,Valid,Term,Vol,Commodity,Pol,Adds,Pod")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                quotation.QuotationId = await GenerateQuotationCode();

                _context.Add(quotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            quotation.QuotationId = await PredictQuotationCode();
            return View(quotation);
        }
        

        [ClaimAuthorize("Quotation", "Edit")]
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

        [ClaimAuthorize("Quotation", "Delete")]
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





        //QuotationCharges
        [ClaimAuthorize("Quotation", "CreateCharges")]
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

        [ClaimAuthorize("Quotation", "EditCharges")]
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

        [ClaimAuthorize("Quotation", "DeleteCharges")]
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
        public JsonResult AutoCompleteCustomers(string prefix)
        {
            prefix = prefix?.ToLower(); // chuẩn hóa từ khóa

            var customers = _context.TblCustomers
                .Where(c =>
                    (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.ToLower().Contains(prefix)) ||
                    (string.IsNullOrEmpty(c.CompanyName) && c.DutyPerson.ToLower().Contains(prefix)))
                .Select(c => new
                {
                    label = !string.IsNullOrEmpty(c.CompanyName) ? c.CompanyName : c.DutyPerson,
                    label2 = c.Contact
                })
                .ToList();

            return Json(customers);
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


        // GET: Quotation/PortGet
        public async Task<JsonResult> PortGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = _context.Cports.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.PortName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.PortName,
                text = data.PortName,
                code = data.Code,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Port",
                    code = "-1",
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
                    header_name = "Port Name"
                }
            });
        }

        public async Task<JsonResult> FeeGet(string q = "", int page = 1)
        {
            int pageSize = 10;
            var query = _context.Fees.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.Fee1.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Fee1,
                text = data.Fee1,
                code = data.Code,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Fee",
                    code = "-1",
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
                    header_name = "Fee"
                }
            });
        }



        //fff
        //ExportPDF
        public async Task<IActionResult> ExportPDFQuotation(string id)
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

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFQuotations", viewModel);

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
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }
    }
}
