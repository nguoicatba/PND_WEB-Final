﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;
using PND_WEB.ViewModels;
using DinkToPdf;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using DinkToPdf.Contracts;
using PND_WEB.Services;

namespace PND_WEB.Controllers
{
    public class TamUngThanhToanCheckController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverter _converter;
        private readonly IViewRenderService _viewRenderService;
        private readonly BudgetService _budgetService;
        private readonly BudgetServiceStaff _budgetServiceStaff;

        public TamUngThanhToanCheckController(DataContext context, IConverter converter,
            IViewRenderService viewRenderService, BudgetService budgetService, BudgetServiceStaff budgetServicestaff)
        {
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
            _budgetService = budgetService;
            _budgetServiceStaff = budgetServicestaff;
        }

        public async Task<string> PredictQuotationCode()
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"TU{datePart}";

            var sotuttWithPrefix = await _context.TblTutts
                .Where(q => q.SoTutt.StartsWith(prefix))
                .Select(q => q.SoTutt)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var sotutt in sotuttWithPrefix)
            {
                if (sotutt.Length >= prefix.Length + 3 &&
                    int.TryParse(sotutt.Substring(prefix.Length, 3), out int number))
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
            string prefix = $"TU{datePart}";

            var sotuttWithPrefix = await _context.TblTutts
                .Where(q => q.SoTutt.StartsWith(prefix))
                .Select(q => q.SoTutt)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var sotutt in sotuttWithPrefix)
            {
                if (sotutt.Length >= prefix.Length + 3 &&
                    int.TryParse(sotutt.Substring(prefix.Length, 3), out int number))
                {
                    if (number > maxNumber)
                        maxNumber = number;
                }
            }

            int nextNumber = maxNumber + 1;

            return $"{prefix}{nextNumber:D3}";
        }


        public IActionResult EditBudget()
        {
            var viewModel = new BudgetLimitViewModel
            {
                Limit = _budgetService.GetLimit()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBudget(BudgetLimitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _budgetService.SetLimit(model.Limit);
            }

            return RedirectToAction(nameof(CheckCeo));
        }


        public IActionResult EditBudgetStaff()
        {
            var viewModel = new BudgetLimitViewModelStaff
            {
                LimitStaff = _budgetServiceStaff.GetLimit()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBudgetStaff(BudgetLimitViewModelStaff model)
        {
            if (ModelState.IsValid)
            {
                _budgetServiceStaff.SetLimit(model.LimitStaff);
            }

            return RedirectToAction(nameof(CheckCeo));
        }



        //[ClaimAuthorize("TamUngThanhToanCheck", "Check")]

        public IActionResult Check()
        {
            if (User.IsInRole("CEO") || User.IsInRole("SuperAdmin"))
            {
                return RedirectToAction(nameof(CheckCeo));
            }
            else if (User.IsInRole("Accountant"))
            {
                return RedirectToAction(nameof(CheckAccountant));
            }
            return NotFound();
        }

        public async Task<IActionResult> CheckCeo()
        {
            var tutts = await _context.TblTutts
                .Include(t => t.TblTuttPhis)
                .Where(t => t.xacnhanduyet == true)
                .Where(t => t.TblTuttPhis.Sum(p => p.SoTien ?? 0) >= (double)_budgetServiceStaff.GetLimit())
                .ToListAsync();

            TuttViewCheckModel model = new TuttViewCheckModel
            {
                tutt = tutts,
                tuttphi = tutts.SelectMany(t => t.TblTuttPhis).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> CheckAccountant()
        {
            var tutts = await _context.TblTutts
               .Include(t => t.TblTuttPhis)
               .Where(t => t.xacnhanduyet == true)
               .Where(t => t.TblTuttPhis.Sum(p => p.SoTien ?? 0) < (double)_budgetServiceStaff.GetLimit())
               .ToListAsync();

            TuttViewCheckModel model = new TuttViewCheckModel
            {
                tutt = tutts,
                tuttphi = tutts.SelectMany(t => t.TblTuttPhis).ToList()
            };

            return View(model);
        }



        private bool TblTuttExists(string id)
        {
            return _context.TblTutts.Any(e => e.SoTutt == id);
        }

        //ceo + ketoan


        //[ClaimAuthorize("TamUngThanhToanCheck", "CheckDetails")]
        public async Task<IActionResult> CheckDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutt = await _context.TblTutts
                .FirstOrDefaultAsync(m => m.SoTutt == id);
            if (tutt == null)
            {
                return NotFound();
            }
            var tuttViewModel = new TuttPhiViewModel
            {
                tutt = tutt,
                tuttphi = await _context.TblTuttsPhi
                    .Where(a => a.SoTutt == id)
                    .ToListAsync()
            };

            return View(tuttViewModel);
        }

        [ClaimAuthorize("TamUngThanhToanCheck", "CheckEdit")]
        public async Task<IActionResult> CheckEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTutt = await _context.TblTutts.FindAsync(id);
            if (tblTutt == null)
            {
                return NotFound();
            }
            ViewBag.CeoOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Chưa duyệt", Value = "" },
                new SelectListItem { Text = "Đã duyệt", Value = "true" },
                new SelectListItem { Text = "Huỷ", Value = "false" }
            };
            ViewBag.KetoanOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Chưa duyệt", Value = "" },
                new SelectListItem { Text = "Đã duyệt", Value = "true" },
                new SelectListItem { Text = "Huỷ", Value = "false" }
            };
            return View(tblTutt);
        }


        string GenerateNewSoTutt(string oldSoTutt)
        {
            if (oldSoTutt.StartsWith("TU"))
            {
                return "TT" + oldSoTutt.Substring(2);
            }
            else
            {
                throw new Exception("Định dạng SoTutt không đúng");
            }
        }

        // POST: TamUngThanhToan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckEdit(string id, [Bind("SoTutt,Ngay,NhanvienTutt,NoiDung,xacnhanduyet,Ketoan,Ceo,GhiChu")] TblTutt tblTutt)
        {
            

            if (id != tblTutt.SoTutt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingTutt = await _context.TblTutts.FindAsync(id);
                    if (existingTutt == null)
                    {
                        return NotFound();
                    }

                    existingTutt.Ceo = tblTutt.Ceo;
                    existingTutt.Ketoan = tblTutt.Ketoan;
                    existingTutt.GhiChu = tblTutt.GhiChu;

                    await _context.SaveChangesAsync();

                    var checktutt = await _context.TblTutts.FirstOrDefaultAsync(t => t.SoTutt == tblTutt.SoTutt);
                          
                    if(checktutt.Tu == true)
                    {
                        if (tblTutt.Ketoan == true || tblTutt.Ceo == true)
                        {
                            var sotuttcu = tblTutt.SoTutt;

                            var tuttcu = await _context.TblTutts.FirstOrDefaultAsync(t => t.SoTutt == sotuttcu);
                            if (tuttcu == null)
                            {
                                return NotFound();
                            }

                            var tuttphioList = await _context.TblTuttsPhi
                                .Where(p => p.SoTutt == sotuttcu)
                                .ToListAsync();

                            string sotuttmoi = GenerateNewSoTutt(sotuttcu);

                            var newTutt = new TblTutt
                            {
                                SoTutt = sotuttmoi,
                                Ngay = tuttcu.Ngay,
                                NhanvienTutt = tuttcu.NhanvienTutt,
                                NoiDung = tuttcu.NoiDung,
                                xacnhanduyet = tuttcu.xacnhanduyet,
                                Tu = true,
                                Tt = true,
                                Ketoan = null,
                                Ceo = null,
                                GhiChu = tuttcu.GhiChu
                            };

                            _context.TblTutts.Add(newTutt);

                            foreach (var item in tuttphioList)
                            {
                                var newItem = new TblTuttPhi
                                {
                                    SoTutt = sotuttmoi,
                                    SoHoaDon = item.SoHoaDon,
                                    TenPhi = item.TenPhi,
                                    SoTien = item.SoTien,
                                    GhiChu = item.GhiChu,
                                };

                                _context.TblTuttsPhi.Add(newItem);
                            }

                            await _context.SaveChangesAsync();
                        }
                    }


                    


                    return RedirectToAction(nameof(Check));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTuttExists(tblTutt.SoTutt))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(tblTutt);
        }

        [ClaimAuthorize("TamUngThanhToanCheck", "CheckDelete")]
        public async Task<IActionResult> CheckDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutt = await _context.TblTutts
                .FirstOrDefaultAsync(m => m.SoTutt == id);
            if (tutt == null)
            {
                return NotFound();
            }
            var tuttViewModel = new TuttPhiViewModel
            {
                tutt = tutt,
                tuttphi = await _context.TblTuttsPhi
                    .Where(a => a.SoTutt == id)
                    .ToListAsync()
            };

            return View(tuttViewModel);
        }

        [HttpPost, ActionName("CheckDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckDeleteConfirmed(string id)
        {
            var tuttphi = await _context.TblTuttsPhi
                .Where(p => p.SoTutt == id)
                .ToListAsync();
            if (tuttphi.Any())
            {
                _context.TblTuttsPhi.RemoveRange(tuttphi);
            }

            var tblTutt = await _context.TblTutts.FindAsync(id);
            if (tblTutt != null)
            {
                _context.TblTutts.Remove(tblTutt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Check));
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


        //ExportPDF
        public async Task<IActionResult> ExportPDFTutt(string id)
        {
            var tutt = await _context.TblTutts
                                          .Include(q => q.TblTuttPhis)
                                          .FirstOrDefaultAsync(q => q.SoTutt == id);

            if (tutt == null)
                return NotFound();

            var viewModel = new TuttPhiViewModel
            {
                tutt = tutt,
                tuttphi = tutt.TblTuttPhis.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFTutt", viewModel);

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
            Response.Headers.Add("Content-Disposition", "inline; filename=Tutt.pdf");
            return File(file, "application/pdf");
        }
    }
}
