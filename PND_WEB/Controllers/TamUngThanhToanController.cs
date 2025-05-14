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

        public TamUngThanhToanController(DataContext context, IConverter converter, IViewRenderService viewRenderService)
        {
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
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

        public async Task<IActionResult> Check()
        {
            TuttViewModel2 tuttViewModel2 = new TuttViewModel2();
            tuttViewModel2.tuttcheck = await _context.TblTutts
                .Where(a => a.xacnhanduyet == true)
                .ToListAsync();

            return View(tuttViewModel2);
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

        // GET: TamUngThanhToan/Create
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
                    return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        private bool TblTuttExists(string id)
        {
            return _context.TblTutts.Any(e => e.SoTutt == id);
        }



        //TuttCreate

        [HttpGet]
        public async Task<IActionResult> TuttCreate(string id)
        {
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
                return RedirectToAction(nameof(Details), new { id = tuttEditModel.tuttphi.SoTutt });
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
            return RedirectToAction("Details", new { id = Code });
        }



        //ceo + ketoan

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
                    existingTutt.Ketoan = tblTutt.Ketoan    ;
                    existingTutt.GhiChu = tblTutt.GhiChu;

                    await _context.SaveChangesAsync();
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
