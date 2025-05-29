using Microsoft.AspNetCore.Mvc;
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
    public class TamUngThanhToanController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverter _converter;
        private readonly IViewRenderService _viewRenderService;
        private readonly BudgetService _budgetService;

        public TamUngThanhToanController(DataContext context, IConverter converter,
            IViewRenderService viewRenderService, BudgetService budgetService)
        {
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
            _budgetService = budgetService;
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








        // GET: TamUngThanhToan
        public async Task<IActionResult> Index()
        {
            TuttViewModel tuttViewModel = new TuttViewModel();

            tuttViewModel.tutt = await _context.TblTutts
                .Where(a => a.xacnhanduyet == null)
                .ToListAsync();

            tuttViewModel.tuttcheck = await _context.TblTutts
                .Where(a => a.xacnhanduyet != null )
                .ToListAsync();

            return View(tuttViewModel);
        }


        // GET: TamUngThanhToan/Details/5
        public async Task<IActionResult> Details(string id)
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

        public async Task<IActionResult> Create()
        {

            var tblTutt = new TblTutt
            {
                Ngay = DateTime.Now,
                Tu = true,
                SoTutt = await PredictQuotationCode(),
            };

            return View(tblTutt);
        }

        // POST: TamUngThanhToan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoTutt,Ngay,NhanvienTutt,NoiDung,xacnhanduyet,Ketoan,Ceo,GhiChu,Tu,Tt")] TblTutt tblTutt)
        {
            if (ModelState.IsValid)
            {
                tblTutt.SoTutt = await GenerateQuotationCode();

                _context.Add(tblTutt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            tblTutt.SoTutt = await PredictQuotationCode();
            return View(tblTutt);
        }

        // GET: TamUngThanhToan/Edit/5
        public async Task<IActionResult> Edit(string id)
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

            ViewBag.DuyetList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Chưa duyệt", Value = "", Selected = (tblTutt.xacnhanduyet == null) },
                new SelectListItem { Text = "Cần duyệt", Value = "true", Selected = (tblTutt.xacnhanduyet == true) }
            };
            return View(tblTutt);
        }


        // POST: TamUngThanhToan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SoTutt,Ngay,NhanvienTutt,NoiDung,xacnhanduyet,Ketoan,Ceo,GhiChu")] TblTutt tblTutt)
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

                    existingTutt.NhanvienTutt = tblTutt.NhanvienTutt;
                    existingTutt.NoiDung = tblTutt.NoiDung;
                    existingTutt.xacnhanduyet = tblTutt.xacnhanduyet;
                    existingTutt.GhiChu = tblTutt.GhiChu;

                    await _context.SaveChangesAsync();

                    if (User.IsInRole("CEO"))
                    {
                        return RedirectToAction("CheckCeo", "TamUngThanhToanCheck");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
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


        // GET: TamUngThanhToan/Delete/5
        public async Task<IActionResult> Delete(string id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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

            if (User.IsInRole("CEO"))
            {
                return RedirectToAction("CheckCeo", "TamUngThanhToanCheck");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool TblTuttExists(string id)
        {
            return _context.TblTutts.Any(e => e.SoTutt == id);
        }








        //TuttphiCreate

        [HttpGet]
        public async Task<IActionResult> TuttCreate(string id)
        {
            var today = DateTime.UtcNow.Date;
            string datePart = today.ToString("yyyyMM");
            string prefix = $"TU{datePart}";

            var totalThisMonth = await _context.TblTuttsPhi
                .Where(p => p.SoTutt.StartsWith(prefix))
                .SumAsync(p => (decimal?)(p.SoTien ?? 0)) ?? 0;

            var limit = _budgetService.GetLimit();


            ViewBag.TotalThisMonth = totalThisMonth;
            ViewBag.Limit = limit;

            //if (totalThisMonth >= limit)
            //{
            //    TempData["ErrorMessage"] = "Tổng số tiền tạm ứng trong tháng đã vượt hạn mức cho phép.";
            //    return RedirectToAction(nameof(Index));
            //}

            if (id == null)
            {
                return NotFound();
            }
            var tutt = await _context.TblTutts.FindAsync(id);
            if (tutt == null)
            {
                return NotFound();
            }
            var tuttphiActionEditModel = new TuttEditModel
            {
                id = tutt.SoTutt,
                tuttphi = new TblTuttPhi()
            };
            return View(tuttphiActionEditModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TuttCreate(TuttEditModel tuttEditModel)
        {
            if (ModelState.IsValid)
            {
                var tutt = await _context.TblTutts.FindAsync(tuttEditModel.id);
                if (tutt == null)
                {
                    return NotFound();
                }
                tuttEditModel.tuttphi.SoTutt = tutt.SoTutt;
                _context.Add(tuttEditModel.tuttphi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = tuttEditModel.id });
            }
            return View(tuttEditModel);
        }


        [HttpGet]
        public async Task<IActionResult> TuttEdit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tuttphi = await _context.TblTuttsPhi.FindAsync(id);
            if (tuttphi == null)
            {
                return NotFound();
            }
            var tuttEditModel = new TuttEditModel
            {
                tuttphi = tuttphi,
                id = tuttphi.SoTutt
            };
            return View(tuttEditModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TuttEdit(int id, TuttEditModel tuttEditModel)
        {
            if (id != tuttEditModel.tuttphi.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuttEditModel.tuttphi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTuttExists(tuttEditModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (User.IsInRole("CEO"))
                {
                    return RedirectToAction("CheckDetails", "TamUngThanhToanCheck", new { id = tuttEditModel.tuttphi.SoTutt });
                }
                else
                {
                    return RedirectToAction(nameof(Details), new { id = tuttEditModel.tuttphi.SoTutt });
                }
            }
            return View(tuttEditModel);
        }


        [HttpGet]
        public async Task<IActionResult> TuttDelete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tuttphi = await _context.TblTuttsPhi.FindAsync(id);
            if (tuttphi == null)
            {
                return NotFound();
            }
            var tuttEditModel = new TuttEditModel
            {
                tuttphi = tuttphi,
                id = tuttphi.SoTutt
            };
            return View(tuttEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TuttDelete(TuttEditModel tuttEdit)
        {
            TempData["status"] = "Đã xóa thành công";
            if (tuttEdit.tuttphi == null)
            {
                return NotFound();
            }
            var tuttAction = await _context.TblTuttsPhi.FindAsync(tuttEdit.tuttphi.Id);
            var Code = tuttAction.SoTutt;
            if (tuttAction == null)
            {
                return NotFound();
            }

            _context.TblTuttsPhi.Remove(tuttAction);
            await _context.SaveChangesAsync();

            if (User.IsInRole("CEO"))
            {
                return RedirectToAction("CheckDetails", "TamUngThanhToanCheck", new { id = Code });
            }
            else
            {
                return RedirectToAction("Details", new { id = Code });
            }
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
                text = data.Code,
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
                    header_code = "Fee",
                    header_name = "Code"
                }
            });
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
