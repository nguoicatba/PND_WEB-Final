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
    public class HblsController : Controller
    {
        private readonly DataContext _context;

        public HblsController(DataContext context)
        {
            _context = context;
        }

        // GET: Hbls
        public async Task<IActionResult> Index(string id)
        {
            TblJob tblJob = _context.TblJobs.Find(id);
            tblJob.TblHbls = _context.TblHbls.Where(h => h.RequestId == id).ToList();   
            return View(tblJob);
        }

        // GET: Hbls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHbl = await _context.TblHbls
                .Include(t => t.CneeNavigation)
                .Include(t => t.Customer)
                .Include(t => t.Request)
                .Include(t => t.ShipperNavigation)
                .FirstOrDefaultAsync(m => m.Hbl == id);
            if (tblHbl == null)
            {
                return NotFound();
            }

            return View(tblHbl);
        }

        // GET: Hbls/Create
        public IActionResult Create()
        {
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee");
            ViewData["CustomerId"] = new SelectList(_context.TblCustomers, "CustomerId", "CustomerId");
            ViewData["RequestId"] = new SelectList(_context.TblJobs, "JobId", "JobId");
            ViewData["Shipper"] = new SelectList(_context.TblShippers, "Shipper", "Shipper");
            return View();
        }

        // POST: Hbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblHbl tblHbl)
        {   
            
            if (ModelState.IsValid)
            {
                _context.Add(tblHbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new { id = tblHbl.RequestId });
            }
            else
            {
                foreach (var modelStateKey in ViewData.ModelState.Keys)
                {
                    var modelStateVal = ViewData.ModelState[modelStateKey];
                    if (modelStateVal != null) // Check for null
                    {
                        foreach (var error in modelStateVal.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                }
                

            }
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee", tblHbl.Cnee);
            ViewData["CustomerId"] = new SelectList(_context.TblCustomers, "CustomerId", "CustomerId", tblHbl.CustomerId);
            ViewData["RequestId"] = new SelectList(_context.TblJobs, "JobId", "JobId", tblHbl.RequestId);
            ViewData["Shipper"] = new SelectList(_context.TblShippers, "Shipper", "Shipper", tblHbl.Shipper);
            return View(tblHbl);
        }

        // GET: Hbls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHbl = await _context.TblHbls.FindAsync(id);
            if (tblHbl == null)
            {
                return NotFound();
            }
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee", tblHbl.Cnee);
            ViewData["CustomerId"] = new SelectList(_context.TblCustomers, "CustomerId", "CustomerId", tblHbl.CustomerId);
            ViewData["RequestId"] = new SelectList(_context.TblJobs, "JobId", "JobId", tblHbl.RequestId);
            ViewData["Shipper"] = new SelectList(_context.TblShippers, "Shipper", "Shipper", tblHbl.Shipper);
            return View(tblHbl);
        }

        // POST: Hbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Hbl,RequestId,IssuePlaceH,IssueDateH,OnBoardDateH,CustomerId,Shipper,Cnee,NotifyParty,BlType,NomFree,ContSealNo,Volume,Quantity,GoodsDesciption,GrossWeight,Tonnage,CustomsDeclarationNo,InvoiceNo,NumberofOrigins,FreightPayable,MarkNos,FreightCharge,Prepaid,Collect,SiNo,Pic,DoDate,PicPhone")] TblHbl tblHbl)
        {
            if (id != tblHbl.Hbl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHblExists(tblHbl.Hbl))
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
            ViewData["Cnee"] = new SelectList(_context.TblCnees, "Cnee", "Cnee", tblHbl.Cnee);
            ViewData["CustomerId"] = new SelectList(_context.TblCustomers, "CustomerId", "CustomerId", tblHbl.CustomerId);
            ViewData["RequestId"] = new SelectList(_context.TblJobs, "JobId", "JobId", tblHbl.RequestId);
            ViewData["Shipper"] = new SelectList(_context.TblShippers, "Shipper", "Shipper", tblHbl.Shipper);
            return View(tblHbl);
        }

        // GET: Hbls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHbl = await _context.TblHbls
                .Include(t => t.CneeNavigation)
                .Include(t => t.Customer)
                .Include(t => t.Request)
                .Include(t => t.ShipperNavigation)
                .FirstOrDefaultAsync(m => m.Hbl == id);
            if (tblHbl == null)
            {
                return NotFound();
            }

            return View(tblHbl);
        }

        // POST: Hbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblHbl = await _context.TblHbls.FindAsync(id);
            if (tblHbl != null)
            {
                _context.TblHbls.Remove(tblHbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHblExists(string id)
        {
            return _context.TblHbls.Any(e => e.Hbl == id);
        }
    }
}
