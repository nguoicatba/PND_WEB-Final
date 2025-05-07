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
    public class InvoiceChargeController : Controller
    {
        private readonly DataContext _context;

        public InvoiceChargeController(DataContext context)
        {
            _context = context;
        }

        // GET: InvoiceCharge
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.TblCharges.Include(t => t.Debit);
            return View(await dataContext.ToListAsync());
        }

        // GET: InvoiceCharge/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCharge = await _context.TblCharges
                .Include(t => t.Debit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCharge == null)
            {
                return NotFound();
            }

            return View(tblCharge);
        }

        // GET: InvoiceCharge/Create
        public IActionResult Create()
        {
            ViewData["DebitId"] = new SelectList(_context.TblInvoices, "DebitId", "DebitId");
            return View();
        }

        // POST: InvoiceCharge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DebitId,SerName,SerUnit,SerQuantity,SerPrice,Currency,ExchangeRate,SerVat,MVat,Checked")] TblCharge tblCharge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCharge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DebitId"] = new SelectList(_context.TblInvoices, "DebitId", "DebitId", tblCharge.DebitId);
            return View(tblCharge);
        }

        // GET: InvoiceCharge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCharge = await _context.TblCharges.FindAsync(id);
            if (tblCharge == null)
            {
                return NotFound();
            }
            ViewData["DebitId"] = new SelectList(_context.TblInvoices, "DebitId", "DebitId", tblCharge.DebitId);
            return View(tblCharge);
        }

        // POST: InvoiceCharge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DebitId,SerName,SerUnit,SerQuantity,SerPrice,Currency,ExchangeRate,SerVat,MVat,Checked")] TblCharge tblCharge)
        {
            if (id != tblCharge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCharge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblChargeExists(tblCharge.Id))
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
            ViewData["DebitId"] = new SelectList(_context.TblInvoices, "DebitId", "DebitId", tblCharge.DebitId);
            return View(tblCharge);
        }

        // GET: InvoiceCharge/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCharge = await _context.TblCharges
                .Include(t => t.Debit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCharge == null)
            {
                return NotFound();
            }

            return View(tblCharge);
        }

        // POST: InvoiceCharge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCharge = await _context.TblCharges.FindAsync(id);
            if (tblCharge != null)
            {
                _context.TblCharges.Remove(tblCharge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblChargeExists(int id)
        {
            return _context.TblCharges.Any(e => e.Id == id);
        }
    }
}
