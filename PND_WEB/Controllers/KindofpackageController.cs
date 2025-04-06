using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Repository;

namespace PND_WEB.Controllers
{
    public class KindofpackageController : Controller
    {
        private readonly DataContext _context;

        public KindofpackageController(DataContext context)
        {
            _context = context;
        }

        // GET: Kindofpackage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kindofpackages.ToListAsync());
        }

        // GET: Kindofpackage/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindofpackage = await _context.Kindofpackages
                .FirstOrDefaultAsync(m => m.Code == id);
            if (kindofpackage == null)
            {
                return NotFound();
            }

            return View(kindofpackage);
        }

        // GET: Kindofpackage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kindofpackage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,PackageName,PackagesDescription")] Kindofpackage kindofpackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kindofpackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kindofpackage);
        }

        // GET: Kindofpackage/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindofpackage = await _context.Kindofpackages.FindAsync(id);
            if (kindofpackage == null)
            {
                return NotFound();
            }
            return View(kindofpackage);
        }

        // POST: Kindofpackage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,PackageName,PackagesDescription")] Kindofpackage kindofpackage)
        {
            if (id != kindofpackage.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kindofpackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindofpackageExists(kindofpackage.Code))
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
            return View(kindofpackage);
        }

        // GET: Kindofpackage/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindofpackage = await _context.Kindofpackages
                .FirstOrDefaultAsync(m => m.Code == id);
            if (kindofpackage == null)
            {
                return NotFound();
            }

            return View(kindofpackage);
        }

        // POST: Kindofpackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kindofpackage = await _context.Kindofpackages.FindAsync(id);
            if (kindofpackage != null)
            {
                _context.Kindofpackages.Remove(kindofpackage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindofpackageExists(string id)
        {
            return _context.Kindofpackages.Any(e => e.Code == id);
        }
    }
}
