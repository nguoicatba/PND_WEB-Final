using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;

namespace PND_WEB.Controllers
{
    public class ContainerController : Controller
    {
        private readonly DataContext _context;

        public ContainerController(DataContext context)
        {
            _context = context;
        }

        // GET: Container
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblConths.ToListAsync());
        }

        // GET: Container/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConth = await _context.TblConths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblConth == null)
            {
                return NotFound();
            }

            return View(tblConth);
        }

        // GET: Container/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Container/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContNo,Hbl,ContQuantity,ContType,SealNo,GrossWeight,Cmb,GoodsQuantity,GoodsDepcription")] TblConth tblConth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblConth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblConth);
        }

        // GET: Container/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConth = await _context.TblConths.FindAsync(id);
            if (tblConth == null)
            {
                return NotFound();
            }
            return View(tblConth);
        }

        // POST: Container/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContNo,Hbl,ContQuantity,ContType,SealNo,GrossWeight,Cmb,GoodsQuantity,GoodsDepcription")] TblConth tblConth)
        {
            if (id != tblConth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblConth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblConthExists(tblConth.Id))
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
            return View(tblConth);
        }

        // GET: Container/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConth = await _context.TblConths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblConth == null)
            {
                return NotFound();
            }

            return View(tblConth);
        }

        // POST: Container/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblConth = await _context.TblConths.FindAsync(id);
            if (tblConth != null)
            {
                _context.TblConths.Remove(tblConth);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblConthExists(int id)
        {
            return _context.TblConths.Any(e => e.Id == id);
        }
    }
}
