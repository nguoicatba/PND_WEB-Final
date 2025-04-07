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
    public class CarrierController : Controller
    {
        private readonly DataContext _context;

        public CarrierController(DataContext context)
        {
            _context = context;
        }

        // GET: Carrier
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carriers.ToListAsync());
        }

        // GET: Carrier/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carriers
                .FirstOrDefaultAsync(m => m.Code == id);
            if (carrier == null)
            {
                return NotFound();
            }

            return View(carrier);
        }

        // GET: Carrier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,CarrierName,CarrierNamekd,CarierAdd,Note")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrier);
        }

        // GET: Carrier/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carriers.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }
            return View(carrier);
        }

        // POST: Carrier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,CarrierName,CarrierNamekd,CarierAdd,Note")] Carrier carrier)
        {
            if (id != carrier.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierExists(carrier.Code))
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
            return View(carrier);
        }

        // GET: Carrier/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carriers
                .FirstOrDefaultAsync(m => m.Code == id);
            if (carrier == null)
            {
                return NotFound();
            }

            return View(carrier);
        }

        // POST: Carrier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var carrier = await _context.Carriers.FindAsync(id);
            if (carrier != null)
            {
                _context.Carriers.Remove(carrier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierExists(string id)
        {
            return _context.Carriers.Any(e => e.Code == id);
        }
    }
}
