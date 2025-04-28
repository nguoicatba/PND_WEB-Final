using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;
using PND_WEB.ViewModels;

namespace WebApplication4.Controllers
{
    public class TblCneeController : Controller
    {
        private readonly DataContext _context;

        public TblCneeController(DataContext context)
        {
            _context = context;
        }

        // GET: TblCnee
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblCnees.ToListAsync());
        }

        // GET: TblCnee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCnee = await _context.TblCnees
                .FirstOrDefaultAsync(m => m.Cnee == id);
            if (tblCnee == null)
            {
                return NotFound();
            }

            CneeViewModel  cneeViewModel = new CneeViewModel();
            cneeViewModel.CneeAdds = await _context.TblCneeAdds.Where(c => c.Cnee == id).ToListAsync();
            cneeViewModel.Cnee = tblCnee;

            return View(cneeViewModel);
        }

        // GET: TblCnee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblCnee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnee,Vcnee,Caddress,Vaddress,Ccity,CpersonInCharge,TaxId,Haddress")] TblCnee tblCnee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCnee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCnee);
        }

        // GET: TblCnee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCnee = await _context.TblCnees.FindAsync(id);
            if (tblCnee == null)
            {
                return NotFound();
            }
            return View(tblCnee);
        }

        // POST: TblCnee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cnee,Vcnee,Caddress,Vaddress,Ccity,CpersonInCharge,TaxId,Haddress")] TblCnee tblCnee)
        {
            if (id != tblCnee.Cnee)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCnee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCneeExists(tblCnee.Cnee))
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
            return View(tblCnee);
        }

        // GET: TblCnee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCnee = await _context.TblCnees
                .FirstOrDefaultAsync(m => m.Cnee == id);
            if (tblCnee == null)
            {
                return NotFound();
            }

            return View(tblCnee);
        }

        // POST: TblCnee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblCnee = await _context.TblCnees.FindAsync(id);
            if (tblCnee != null)
            {
                _context.TblCnees.Remove(tblCnee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCneeExists(string id)
        {
            return _context.TblCnees.Any(e => e.Cnee == id);
        }
    }
}
