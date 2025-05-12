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
using Microsoft.AspNetCore.Identity;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using System.Text;
namespace PND_WEB.Controllers
{
    public class QuotationsController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IConverter _converter;

        public QuotationsController(DataContext context, UserManager<AppUserModel> userManager, IConverter converter)
        {
            _context = context;
            _userManager = userManager;
            _converter = converter;
        }
        //test

        //public IActionResult Exporttopdf2()
        //{
        //    var doc = new HtmlToPdfDocument()
        //    {
        //        GlobalSettings = {
        //        PaperSize = PaperKind.A4,
        //        Orientation = Orientation.Portrait
        //    },
        //        Objects = {
        //        new ObjectSettings()
        //        {
        //            HtmlContent = "<h1>Hello from PDF!</h1><p>This is a PDF file.</p>"
        //        }
        //    }
        //    };

        //    var file = _converter.Convert(doc);
        //    Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
        //    return File(file, "application/pdf");
        //}

        // GET: Quotations
        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);

            var quotations = await _context.Quotations
                .Where(q => q.StaffName == user.Staff_Name)
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




        ///admin //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///

        public async Task<IActionResult> AdminView()
        {
            var quotations = await _context.Quotations
                .ToListAsync();

            return View(quotations);
        }
        public async Task<IActionResult> AdminViewDetails(string id)
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

        public async Task<IActionResult> AdminViewCreate()
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
        public async Task<IActionResult> AdminViewCreate([Bind("QuotationId,Qsatus,StaffName,Contact,Qdate,CusTo,CusContact,Valid,Term,Vol,Commodity,Pol,Adds,Pod")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                var existingQuotation = await _context.Quotations
                    .FirstOrDefaultAsync(q => q.QuotationId == quotation.QuotationId);

                quotation.QuotationId = await GenerateQuotationCode();

                _context.Add(quotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminView));
            }
            quotation.QuotationId = await PredictQuotationCode();
            return View(quotation);
        }


        [HttpGet("/Quotations/AdminViewEdit/{id}")]
        public async Task<IActionResult> AdminViewEdit(string id)
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

        [HttpPost("/Quotations/AdminViewEdit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminViewEdit(string id, [Bind("QuotationId,Qsatus,StaffName,Contact,Qdate,CusTo,CusContact,Valid,Term,Vol,Commodity,Pol,Adds,Pod")] Quotation quotation)
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
                return RedirectToAction(nameof(AdminView));
            }
            return View(quotation);
        }

        [HttpGet("/Quotations/AdminViewDelete/{id}")]
        public async Task<IActionResult> AdminViewDelete(string id)
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

        [HttpPost, ActionName("AdminViewDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminViewDeleteConfirmed(string id)
        {
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation != null)
            {
                var relatedCharges = _context.QuotationsCharges.Where(qc => qc.QuotationId == id);
                _context.QuotationsCharges.RemoveRange(relatedCharges);
                _context.Quotations.Remove(quotation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminView));
        }


        public IActionResult AdminViewCreateCharges(string id)
        {
            var quotation = _context.Quotations.FirstOrDefault(q => q.QuotationId == id);
            if (quotation == null)
                return NotFound();

            var model = new QuotationsCharge
            {
                QuotationId = id,

                Quantity = 0,
                Rate = 0,
            };

            ViewBag.CurrencyList = new SelectList(_context.Currencies, "Code", "Code");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminViewCreateCharges([Bind("ChargeId,QuotationId,ChargeName,Quantity,Unit,Rate,Currency,Notes")] QuotationsCharge quotationsCharge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quotationsCharge);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminViewDetails", new { id = quotationsCharge.QuotationId });
            }
            ViewData["QuotationId"] = new SelectList(_context.Quotations, "QuotationId", "QuotationId", quotationsCharge.QuotationId);
            return View(quotationsCharge);
        }

        public IActionResult AdminViewEditCharges(int id)
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
        public async Task<IActionResult> AdminViewEditCharges(int id, [Bind("ChargeId,QuotationId,ChargeName,Quantity,Unit,Rate,Currency,Notes")] QuotationsCharge quotationsCharge)
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
                return RedirectToAction("AdminViewDetails", new { id = quotationsCharge.QuotationId });
            }

            ViewData["QuotationId"] = new SelectList(_context.Quotations, "QuotationId", "QuotationId", quotationsCharge.QuotationId);
            ViewBag.CurrencyList = new SelectList(_context.Currencies, "Code", "Code", quotationsCharge.Currency);

            return View("Edit", quotationsCharge);
        }

        public async Task<IActionResult> AdminViewDeleteCharges(int? id)
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

        [HttpPost, ActionName("AdminViewDeleteCharges")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminViewDeleteChargesConfirmed(int id)
        {
            var quotationsCharge = await _context.QuotationsCharges.FindAsync(id);
            if (quotationsCharge != null)
            {
                _context.QuotationsCharges.Remove(quotationsCharge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("AdminViewDetails", new { id = quotationsCharge.QuotationId });
        }



        //test2
        public IActionResult Exporttopdf2()
        {
            // Dữ liệu mẫu cho Quotation
            var quotation = new
            {
                QuotationId = "Q123456",
                Qdate = DateTime.Now,
                Valid = DateTime.Now.AddMonths(1),
                CusContact = "John Doe",
                Pol = "Hai Phong",
                Pod = "Ho Chi Minh",
                Commodity = "Electronics",
                Vol = "20 CBM"
            };

            // Dữ liệu mẫu cho Charges
            var charges = new List<dynamic>
                {
                    new { ChargeName = "Shipping", Currency = "USD", Unit = "Container", Quantity = 1, Rate = 500, Notes = "Regular shipping charge" },
                    new { ChargeName = "Insurance", Currency = "USD", Unit = "Container", Quantity = 1, Rate = 100, Notes = "Insurance charge" }
                };

            // Tính tổng số tiền
            float totalAmount = 0;
            foreach (var item in charges)
            {
                totalAmount += (float)(item.Quantity * item.Rate);
            }

            // HTML content cho PDF
            var htmlContent = $@"
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8' />
        <style>
            body {{
                font-family: Arial;
                font-size: 16px;
                margin: 30px;
            }}

            .center {{
                width: 100%;
                clear: both;
                margin-top: 20px;
            }}

            table {{
                width: 100%;
                border-collapse: collapse;
            }}

            th, td {{
                border: 1px solid #000;
                padding: 6px;
                text-align: left;
            }}

            .text-right {{
                text-align: right;
            }}

            .bold {{
                font-weight: bold;
            }}
        </style>
    </head>
    <body>

        <table style='width: 100%; margin-bottom: 20px; border: #FFF'>
            <tr>
                <td style='width: 50%; vertical-align: top; border: #FFF'>
                    <img src='' alt='PND Logo' class='logo' />
                </td>
                <td style='width: 50%; vertical-align: top; border: #FFF'>
                    <p><strong>PND LOGISTICS TRANSPORT CO., LTD - HAI PHONG HEAD OFFICE</strong></p>
                    <p>ADD: No 24A, Area 15, Dang Hai Ward, Hai An District, Hai Phong City, Vietnam</p>
                    <p>TEL: __________________ EMAIL: __________________</p>
                    <p>WEBSITE: <span style='color: green;'>http://pnd-logistics.com</span></p>
                </td>
            </tr>
        </table>

        <div class='center' style='text-align:center;'>
            <h1>QUOTATION</h1>
            <div>Quotation No: {quotation.QuotationId}</div>
        </div>

        <table style='border: #FFF'>
            <tr>
                <td style='border: #FFF'>
                    FROM 
                    <br />
                    {(quotation.Qdate != DateTime.MinValue ? quotation.Qdate.ToString("dd/MM/yyyy") : "N/A")}
                </td>
                <td style='border: #FFF'>
                    TO 
                    <br />
                    {(quotation.Valid != DateTime.MinValue ? quotation.Valid.ToString("dd/MM/yyyy") : "N/A")}
                </td>
            </tr>
        </table>

        <div class='center'>
            <div>Contact: {quotation.CusContact}</div>
            <p>
                Chúng tôi chân thành cảm ơn sự quan tâm của Quý công ty đối với dịch vụ của chúng tôi.<br />
                Chúng tôi xin đưa ra bảng giá cước theo yêu cầu của Quý công ty như sau:
            </p>
            <p>
                <strong>
                    We sincerely appreciate your company’s interest in our services.<br />
                    Please refer to our best rate for your inquiry as below:
                </strong>
            </p>
        </div>

        <table style='border: #FFF'>
            <tr>
                <td style='border: #FFF'>
                    <strong>Place of receipt:</strong> {quotation.Pol}<br /><br />
                    <strong>Place of delivery:</strong> {quotation.Pod}<br /><br />
                    <strong>Commodity:</strong> {quotation.Commodity}<br />
                </td>
                <td style=' border: #FFF'>
                    <strong>POL:</strong> {quotation.Pol}<br /><br />
                    <strong>POD:</strong> {quotation.Pod}<br /><br />
                    <strong>Volume/Term:</strong> {quotation.Vol}<br />
                </td>
            </tr>
        </table>

        <div class='center'>
            <table>
                <thead>
                    <tr>
                        <th>ITEMS</th>
                        <th>CURRENCY</th>
                        <th>UNIT</th>
                        <th>QUANT</th>
                        <th>PRICE</th>
                        <th>TOTAL</th>
                        <th>NOTE</th>
                    </tr>
                </thead>
                <tbody>";

            foreach (var item in charges)
            {
                float amount = (float)item.Quantity * (float)(item.Rate ?? 0);
                htmlContent += $@"
                    <tr>
                        <td>{item.ChargeName}</td>
                        <td>{item.Currency}</td>
                        <td>{item.Unit}</td>
                        <td class='text-right'>{item.Quantity}</td>
                        <td class='text-right'>{item.Rate?.ToString("N2")}</td>
                        <td class='text-right'>{amount.ToString("N2")}</td>
                        <td>{item.Notes}</td>
                    </tr>";
            }

            htmlContent += $@"
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan='5' class='text-right bold'><center>TOTAL</center></td>
                        <td class='text-right bold'>{totalAmount.ToString("N2")}</td>
                        <td></td>
                    </tr>
                </tfoot>
            </table>
        </div>

        <div class='center'>
            <p><strong>REMARK</strong></p>
            <ul>
                <li>Báo giá chưa bao gồm 8% VAT, riêng cước biển VAT 0%</li>
                <li>Báo giá chưa bao gồm phí thu hộ bên thứ 3: kiểm hóa, soi chiếu, thuế, lưu kho bãi, đường cấm…</li>
                <li>Báo giá không áp dụng cho hàng hóa nguy hiểm, dễ cháy nổ, quá tải, quá khổ… - Tỉ giá TCB bank ngày xuất hóa đơn</li>
            </ul>
            <p><strong>Thanks & Best regards</strong></p>
            <p>We are member of</p>
        </div>

    </body>
    </html>";

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
            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(file, "application/pdf");
        }

    }
}
