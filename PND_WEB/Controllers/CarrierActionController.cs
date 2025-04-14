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
    public class CarrierActionController : Controller
    {
        private readonly DataContext _context;

        public CarrierActionController(DataContext context)
        {
            _context = context;
        }

        // GET: CarrierAction
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.CarrierActions.Include(c => c.CodeNavigation);
            return View(await dataContext.ToListAsync());
        }

        // GET: CarrierAction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierAction = await _context.CarrierActions
                .Include(c => c.CodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrierAction == null)
            {
                return NotFound();
            }

            return View(carrierAction);
        }

        // GET: CarrierAction/Create
        public IActionResult Create()
        {
            ViewData["Code"] = new SelectList(_context.Carriers, "Code", "Code");
            return View();
        }

        // POST: CarrierAction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,PersonInCharge,PhoneNumber,Email,LccFee,Note")] CarrierAction carrierAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrierAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Code"] = new SelectList(_context.Carriers, "Code", "Code", carrierAction.Code);
            return View(carrierAction);
        }

        // GET: CarrierAction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierAction = await _context.CarrierActions.FindAsync(id);
            if (carrierAction == null)
            {
                return NotFound();
            }
            ViewData["Code"] = new SelectList(_context.Carriers, "Code", "Code", carrierAction.Code);
            return View(carrierAction);
        }

        // POST: CarrierAction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,PersonInCharge,PhoneNumber,Email,LccFee,Note")] CarrierAction carrierAction)
        {
            if (id != carrierAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrierAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierActionExists(carrierAction.Id))
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
            ViewData["Code"] = new SelectList(_context.Carriers, "Code", "Code", carrierAction.Code);
            return View(carrierAction);
        }

        // GET: CarrierAction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierAction = await _context.CarrierActions
                .Include(c => c.CodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrierAction == null)
            {
                return NotFound();
            }

            return View(carrierAction);
        }

        // POST: CarrierAction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierAction = await _context.CarrierActions.FindAsync(id);
            if (carrierAction != null)
            {
                _context.CarrierActions.Remove(carrierAction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierActionExists(int id)
        {
            return _context.CarrierActions.Any(e => e.Id == id);
        }
    }
}
