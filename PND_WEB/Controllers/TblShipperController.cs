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
    public class TblShipperController : Controller
    {
        private readonly DataContext _context;

        public TblShipperController(DataContext context)
        {
            _context = context;
        }

        // GET: TblShipper
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblShippers.ToListAsync());
        }

        // GET: TblShipper/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblShipper = await _context.TblShippers
                .FirstOrDefaultAsync(m => m.Shipper == id);
            if (tblShipper == null)
            {
                return NotFound();
            }

            return View(tblShipper);
        }

        // GET: TblShipper/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblShipper/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Shipper,Saddress,Scity,SpersonInCharge,TaxId")] TblShipper tblShipper)
        {
            if (ModelState.IsValid)
            {
                var shipperid = _context.TblShippers.Select(c => c.Shipper).ToList();
                if (shipperid.Contains(tblShipper.Shipper))
                {
                    ModelState.AddModelError("CustomerId", "Mã shipper đã tồn tại");
                }
                _context.Add(tblShipper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblShipper);
        }

        // GET: TblShipper/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblShipper = await _context.TblShippers.FindAsync(id);
            if (tblShipper == null)
            {
                return NotFound();
            }
            return View(tblShipper);
        }

        // POST: TblShipper/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Shipper,Saddress,Scity,SpersonInCharge,TaxId")] TblShipper tblShipper)
        {
            if (id != tblShipper.Shipper)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblShipper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblShipperExists(tblShipper.Shipper))
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
            return View(tblShipper);
        }

        // GET: TblShipper/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblShipper = await _context.TblShippers
                .FirstOrDefaultAsync(m => m.Shipper == id);
            if (tblShipper == null)
            {
                return NotFound();
            }

            return View(tblShipper);
        }

        // POST: TblShipper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblShipper = await _context.TblShippers.FindAsync(id);
            if (tblShipper != null)
            {
                _context.TblShippers.Remove(tblShipper);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblShipperExists(string id)
        {
            return _context.TblShippers.Any(e => e.Shipper == id);
        }
    }
}
