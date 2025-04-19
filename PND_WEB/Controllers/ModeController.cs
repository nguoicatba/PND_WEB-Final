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
    public class ModeController : Controller
    {
        private readonly DataContext _context;

        public ModeController(DataContext context)
        {
            _context = context;
        }

        // GET: Mode
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modes.ToListAsync());
        }

        // GET: Mode/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mode = await _context.Modes
                .FirstOrDefaultAsync(m => m.Code == id);
            if (mode == null)
            {
                return NotFound();
            }

            return View(mode);
        }

        // GET: Mode/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Note")] Mode mode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mode);
        }

        // GET: Mode/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mode = await _context.Modes.FindAsync(id);
            if (mode == null)
            {
                return NotFound();
            }
            return View(mode);
        }

        // POST: Mode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Note")] Mode mode)
        {
            if (id != mode.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeExists(mode.Code))
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
            return View(mode);
        }

        // GET: Mode/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mode = await _context.Modes
                .FirstOrDefaultAsync(m => m.Code == id);
            if (mode == null)
            {
                return NotFound();
            }

            return View(mode);
        }

        // POST: Mode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mode = await _context.Modes.FindAsync(id);
            if (mode != null)
            {
                _context.Modes.Remove(mode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeExists(string id)
        {
            return _context.Modes.Any(e => e.Code == id);
        }
    }
}
