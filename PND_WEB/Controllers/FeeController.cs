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
    public class FeeController : Controller
    {
        private readonly DataContext _context;

        public FeeController(DataContext context)
        {
            _context = context;
        }

        // GET: Fee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fees.ToListAsync());
        }

        // GET: Fee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .FirstOrDefaultAsync(m => m.Code == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // GET: Fee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Fee1,Unit,Note")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fee);
        }

        // GET: Fee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees.FindAsync(id);
            if (fee == null)
            {
                return NotFound();
            }
            return View(fee);
        }

        // POST: Fee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Fee1,Unit,Note")] Fee fee)
        {
            if (id != fee.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeExists(fee.Code))
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
            return View(fee);
        }

        // GET: Fee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .FirstOrDefaultAsync(m => m.Code == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // POST: Fee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee != null)
            {
                _context.Fees.Remove(fee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeExists(string id)
        {
            return _context.Fees.Any(e => e.Code == id);
        }
    }
}
