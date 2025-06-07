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
    public class BlTypeController : Controller
    {
        private readonly DataContext _context;

        public BlTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: BlType
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlTypes.ToListAsync());
        }

        // GET: BlType/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blType = await _context.BlTypes
                .FirstOrDefaultAsync(m => m.Code == id);
            if (blType == null)
            {
                return NotFound();
            }

            return View(blType);
        }

        // GET: BlType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,BlName,Note")] BlType blType)
        {
            if (BlTypeExists(blType.Code))
            {
                ModelState.AddModelError("Code", "Mã blType đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                
                _context.Add(blType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blType);
        }

        // GET: BlType/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blType = await _context.BlTypes.FindAsync(id);
            if (blType == null)
            {
                return NotFound();
            }
            return View(blType);
        }

        // POST: BlType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,BlName,Note")] BlType blType)
        {
            if (id != blType.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlTypeExists(blType.Code))
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
            return View(blType);
        }

        // GET: BlType/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blType = await _context.BlTypes
                .FirstOrDefaultAsync(m => m.Code == id);
            if (blType == null)
            {
                return NotFound();
            }

            return View(blType);
        }

        // POST: BlType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blType = await _context.BlTypes.FindAsync(id);
            if (blType != null)
            {
                _context.BlTypes.Remove(blType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlTypeExists(string id)
        {
            return _context.BlTypes.Any(e => e.Code == id);
        }
    }
}
