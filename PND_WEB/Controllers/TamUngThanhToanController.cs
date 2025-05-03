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

namespace PND_WEB.Controllers
{
    public class TamUngThanhToanController : Controller
    {
        private readonly DataContext _context;

        public TamUngThanhToanController(DataContext context)
        {
            _context = context;
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

        // GET: TamUngThanhToan/Create
        public IActionResult Create()
        {
            var tblTutt = new TblTutt
            {
                Ngay = DateTime.Now,
                Tu = true
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
                _context.Add(tblTutt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
                new SelectListItem { Text = "Cần duyệt", Value = "false", Selected = (tblTutt.xacnhanduyet == false) }
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

            var tblTutt = await _context.TblTutts
                .FirstOrDefaultAsync(m => m.SoTutt == id);
            if (tblTutt == null)
            {
                return NotFound();
            }

            return View(tblTutt);
        }

        // POST: TamUngThanhToan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tuttphi = _context.TblTuttsPhi.Where(p => p.SoTutt == id);
            if (tuttphi != null)
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
            TempData["status"] = "Error: ";
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
            TempData["status"] = "Xóa thành công thông tin thêm cho đại lý";
            return RedirectToAction("Details", new { id = Code });
        }
    }
}
