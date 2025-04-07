using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Repository;
using PND_WEB.ViewModels;

namespace WebApplication4.Controllers
{
    public class TblCneeAddController : Controller
    {
        private readonly DataContext _context;

        public TblCneeAddController(DataContext context)
        {
            _context = context;
        }

        // GET: TblCneeAdd
        public async Task<IActionResult> Index(string ?id)
        {

            if (id == null)
            {
                return NotFound("Trang ko thấy");
            }

            var item = await _context.TblCnees.FirstOrDefaultAsync(m => m.Cnee == id);
            if (item == null)
            {
                return NotFound("Ko thấy Id này");
            }

            CneeViewModel ViewModel = new CneeViewModel();
            ViewModel.Cnee = item;
            ViewModel.CneeAdds = await _context.TblCneeAdds.Where(m => m.Cnee == id).ToListAsync();
            return View(ViewModel);
        }

        // GET: TblCneeAdd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCneeAdd = await _context.TblCneeAdds
                .Include(t => t.CneeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCneeAdd == null)
            {
                return NotFound();
            }

            return View(tblCneeAdd);
        }

        // GET: TblCneeAdd/Create
        public IActionResult Create()
        {
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee");
            return View();
        }

        // POST: TblCneeAdd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adds,Place,PersonInCharge,Cnee")] TblCneeAdd tblCneeAdd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCneeAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",new {id=tblCneeAdd.Cnee});
            }
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee", tblCneeAdd.Cnee);
            return View(tblCneeAdd);
        }

        // GET: TblCneeAdd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCneeAdd = await _context.TblCneeAdds.FindAsync(id);
            if (tblCneeAdd == null)
            {
                return NotFound();
            }
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee", tblCneeAdd.Cnee);
            return View(tblCneeAdd);
        }

        // POST: TblCneeAdd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adds,Place,PersonInCharge,Cnee")] TblCneeAdd tblCneeAdd)
        {
            if (id != tblCneeAdd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCneeAdd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCneeAddExists(tblCneeAdd.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { id = tblCneeAdd.Cnee });
            }
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee", tblCneeAdd.Cnee);
            return View(tblCneeAdd);
        }

        // GET: TblCneeAdd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCneeAdd = await _context.TblCneeAdds
                .Include(t => t.CneeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCneeAdd == null)
            {
                return NotFound();
            }

            return View(tblCneeAdd);
        }

        // POST: TblCneeAdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCneeAdd = await _context.TblCneeAdds.FindAsync(id);
            if (tblCneeAdd != null)
            {
                _context.TblCneeAdds.Remove(tblCneeAdd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = tblCneeAdd.Cnee });
        }

        private bool TblCneeAddExists(int id)
        {
            return _context.TblCneeAdds.Any(e => e.Id == id);
        }
    }
}
