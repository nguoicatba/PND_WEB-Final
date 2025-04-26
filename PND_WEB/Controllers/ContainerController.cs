using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class ContainerController : Controller
    {
        private readonly DataContext _context;

        public ContainerController(DataContext context)
        {
            _context = context;
        }

        public async Task<double> GetTotalGrossWeight(List<TblConth> conths)
        {

            double totalGrossWeight = 0;
            foreach (var conth in conths)
            {
                totalGrossWeight += (double)conth.GrossWeight;
            }

            return totalGrossWeight;

        }
        public async Task<double> GetTotalCbm(List<TblConth> conths)
        {
            double totalCbm = 0;
            foreach (var conth in conths)
            {
                totalCbm += (double)conth.Cmb;
            }
            return totalCbm;
        }

        // GET: Container
        public async Task<IActionResult> Index(string id)
        {
            ContainerViewModel containerViewModel = new ContainerViewModel();
            containerViewModel.HBL_ID = id;
            containerViewModel.containers = await _context.TblConths
                .Where(c => c.Hbl == id)
                .ToListAsync();

            containerViewModel.totalGrossWeight = GetTotalGrossWeight(containerViewModel.containers).Result;
            containerViewModel.totalCbm = GetTotalGrossWeight(containerViewModel.containers).Result;
            return View(containerViewModel);

        }

        // GET: Container/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConth = await _context.TblConths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblConth == null)
            {
                return NotFound();
            }

            return View(tblConth);
        }

        // GET: Container/Create
        [HttpGet]
        public IActionResult Create(string id)
        {
            ContainerEditModel containerEditModel = new ContainerEditModel();
            containerEditModel.HBL_ID = id;
            containerEditModel.container = new TblConth();
            containerEditModel.container.Hbl = id;
            return View(containerEditModel);
        }
      

        // POST: Container/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContainerEditModel containerEditModel)
        {
            if (containerEditModel.container.Hbl ==null)
            {

                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var tblConth = containerEditModel.container;
               
                _context.Add(tblConth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = containerEditModel.container.Hbl });
            }
            return View(containerEditModel);


        }


        // GET: Container/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tblConth = await _context.TblConths.FindAsync(id);
            if (tblConth == null)
            {
                return NotFound();
            }
            ContainerEditModel containerEditModel = new ContainerEditModel();
            containerEditModel.HBL_ID = tblConth.Hbl;
            containerEditModel.container = tblConth;
            return View(containerEditModel);
        }

        // POST: Container/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, ContainerEditModel containerEditModel)
        {
            if (id != containerEditModel.container.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var tblConth = containerEditModel.container;
                    tblConth.Hbl = containerEditModel.HBL_ID;
                    _context.Update(tblConth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblConthExists(containerEditModel.container.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = containerEditModel.HBL_ID });
            }
            return View(containerEditModel);
        }

        // GET: Container/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConth = await _context.TblConths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblConth == null)
            {
                return NotFound();
            }

            return View(tblConth);
        }

        // POST: Container/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblConth = await _context.TblConths.FindAsync(id);
            if (tblConth != null)
            {
                _context.TblConths.Remove(tblConth);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = tblConth.Hbl });
        }

        private bool TblConthExists(int id)
        {
            return _context.TblConths.Any(e => e.Id == id);
        }
    }
}
