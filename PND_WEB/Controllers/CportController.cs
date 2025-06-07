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
    public class CportController : Controller
    {
        private readonly DataContext _context;

        public CportController(DataContext context)
        {
            _context = context;
        }

        // GET: Cport
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cports.ToListAsync());
        }

        // GET: Cport/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cport = await _context.Cports
                .FirstOrDefaultAsync(m => m.Code == id);
            if (cport == null)
            {
                return NotFound();
            }

            return View(cport);
        }

        // GET: Cport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,PortName")] Cport cport)
        {
            var cportCodes = _context.Cports
            .Select(c => c.Code.Trim().ToUpper())
            .ToList();

            var newCportCode = cport.Code.Trim().ToUpper();

            if (cportCodes.Contains(newCportCode))
            {
                ModelState.AddModelError("Code", "Mã cport đã tồn tại");
            }

            if (ModelState.IsValid)
            {
                
                _context.Add(cport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cport);
        }

        // GET: Cport/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cport = await _context.Cports.FindAsync(id);
            if (cport == null)
            {
                return NotFound();
            }
            return View(cport);
        }

        // POST: Cport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,PortName")] Cport cport)
        {
            if (id != cport.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CportExists(cport.Code))
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
            return View(cport);
        }

        // GET: Cport/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cport = await _context.Cports
                .FirstOrDefaultAsync(m => m.Code == id);
            if (cport == null)
            {
                return NotFound();
            }

            return View(cport);
        }

        // POST: Cport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cport = await _context.Cports.FindAsync(id);
            if (cport != null)
            {
                _context.Cports.Remove(cport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CportExists(string id)
        {
            return _context.Cports.Any(e => e.Code == id);
        }
    }
}
