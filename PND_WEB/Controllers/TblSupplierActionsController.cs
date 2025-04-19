using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;

namespace PND_WEB.Controllers
{
    public class TblSupplierActionsController : Controller
    {
        private readonly DataContext _context;

        public TblSupplierActionsController(DataContext context)
        {
            _context = context;
        }

        // GET: TblSupplierActions
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblSupplierActions.Include(t => t.Supplier);
            return View(await dataContext.ToListAsync());
        }

        // GET: TblSupplierActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplierAction = await _context.TblSupplierActions
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSupplierAction == null)
            {
                return NotFound();
            }

            return View(tblSupplierAction);
        }

        // GET: TblSupplierActions/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.TblSuppliers, "SupplierId", "SupplierId");
            return View();
        }

        // POST: TblSupplierActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupplierId,PersonInCharge,PhoneNumber,Email,Note")] TblSupplierAction tblSupplierAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSupplierAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.TblSuppliers, "SupplierId", "SupplierId", tblSupplierAction.SupplierId);
            return View(tblSupplierAction);
        }

        // GET: TblSupplierActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplierAction = await _context.TblSupplierActions.FindAsync(id);
            if (tblSupplierAction == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.TblSuppliers, "SupplierId", "SupplierId", tblSupplierAction.SupplierId);
            return View(tblSupplierAction);
        }

        // POST: TblSupplierActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SupplierId,PersonInCharge,PhoneNumber,Email,Note")] TblSupplierAction tblSupplierAction)
        {
            if (id != tblSupplierAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSupplierAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSupplierActionExists(tblSupplierAction.Id))
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
            ViewData["SupplierId"] = new SelectList(_context.TblSuppliers, "SupplierId", "SupplierId", tblSupplierAction.SupplierId);
            return View(tblSupplierAction);
        }

        // GET: TblSupplierActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplierAction = await _context.TblSupplierActions
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSupplierAction == null)
            {
                return NotFound();
            }

            return View(tblSupplierAction);
        }

        // POST: TblSupplierActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSupplierAction = await _context.TblSupplierActions.FindAsync(id);
            if (tblSupplierAction != null)
            {
                _context.TblSupplierActions.Remove(tblSupplierAction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSupplierActionExists(int id)
        {
            return _context.TblSupplierActions.Any(e => e.Id == id);
        }
    }
}
