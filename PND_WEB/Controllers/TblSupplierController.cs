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
    public class TblSupplierController : Controller
    {
        private readonly DataContext _context;

        public TblSupplierController(DataContext context)
        {
            _context = context;
        }

        // GET: TblSupplier
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblSuppliers.ToListAsync());
        }

        // GET: TblSupplier/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplier = await _context.TblSuppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (tblSupplier == null)
            {
                return NotFound();
            }

            return View(tblSupplier);
        }

        // GET: TblSupplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblSupplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,NameSup,Typer,AddressSup,LccFee,Note")] TblSupplier tblSupplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSupplier);
        }

        // GET: TblSupplier/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplier = await _context.TblSuppliers.FindAsync(id);
            if (tblSupplier == null)
            {
                return NotFound();
            }
            return View(tblSupplier);
        }

        // POST: TblSupplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierId,NameSup,Typer,AddressSup,LccFee,Note")] TblSupplier tblSupplier)
        {
            if (id != tblSupplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSupplierExists(tblSupplier.SupplierId))
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
            return View(tblSupplier);
        }

        // GET: TblSupplier/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplier = await _context.TblSuppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (tblSupplier == null)
            {
                return NotFound();
            }

            return View(tblSupplier);
        }

        // POST: TblSupplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblSupplier = await _context.TblSuppliers.FindAsync(id);
            if (tblSupplier != null)
            {
                _context.TblSuppliers.Remove(tblSupplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSupplierExists(string id)
        {
            return _context.TblSuppliers.Any(e => e.SupplierId == id);
        }
    }
}
