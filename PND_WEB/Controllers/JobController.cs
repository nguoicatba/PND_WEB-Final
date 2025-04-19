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
    public class JobController : Controller
    {
        private readonly DataContext _context;

        public JobController(DataContext context)
        {
            _context = context;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            var dataPndContext = _context.TblJobs.Include(t => t.AgentNavigation).Include(t => t.CarrierNavigation);
            return View(await dataPndContext.ToListAsync());
        }

        // GET: Job/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJob = await _context.TblJobs
                .Include(t => t.AgentNavigation)
                .Include(t => t.CarrierNavigation)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (tblJob == null)
            {
                return NotFound();
            }

            return View(tblJob);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            ViewData["GoodsType"]= new SelectList(_context.GoodsTypes,"Code","Code");
            ViewData["Agent"] = new SelectList(_context.Agents, "Code", "Code");
            ViewData["Carrier"] = new SelectList(_context.Carriers, "Code", "Code");
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,GoodsType,JobDate,Mbl,IssueDateM,OnBoardDateM,VesselName,VoyageName,Pol,Pod,Podel,Podis,PlaceofReceipt,PlaceofDelivery,PreCariageBy,Etd,Eta,Mode,Agent,Carrier,Ycompany,Link,YunLock,UseTime")] TblJob tblJob)
        {   
            tblJob.JobDate = DateTime.Now.Date;
            tblJob.JobId = tblJob.GoodsType + "HP" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            tblJob.YunLock = 15;
            if (ModelState.IsValid)
            {
                _context.Add(tblJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("ModelState is not valid!");
                Console.WriteLine(tblJob.JobId);
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var e in error.Value.Errors)
                    {
                        Console.WriteLine($"Error: {e.ErrorMessage}");
                    }
                }
            }
       
            ViewData["Agent"] = new SelectList(_context.Agents, "Code", "Code", tblJob.Agent);
            ViewData["Carrier"] = new SelectList(_context.Carriers, "Code", "Code", tblJob.Carrier);
            return View(tblJob);
        }

        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJob = await _context.TblJobs.FindAsync(id);
            if (tblJob == null)
            {
                return NotFound();
            }
            ViewData["GoodsType"] = new SelectList(_context.GoodsTypes, "Code", "Code");
            ViewData["Agent"] = new SelectList(_context.Agents, "Code", "Code", tblJob.Agent);
            ViewData["Carrier"] = new SelectList(_context.Carriers, "Code", "Code", tblJob.Carrier);
            return View(tblJob);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("JobId,GoodsType,JobDate,Mbl,IssueDateM,OnBoardDateM,VesselName,VoyageName,Pol,Pod,Podel,Podis,PlaceofReceipt,PlaceofDelivery,PreCariageBy,Etd,Eta,Mode,Agent,Carrier,Ycompany,Link,YunLock,UseTime")] TblJob tblJob)
        {
            if (id != tblJob.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblJobExists(tblJob.JobId))
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
            ViewData["Agent"] = new SelectList(_context.Agents, "Code", "Code", tblJob.Agent);
            ViewData["Carrier"] = new SelectList(_context.Carriers, "Code", "Code", tblJob.Carrier);
            return View(tblJob);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJob = await _context.TblJobs
                .Include(t => t.AgentNavigation)
                .Include(t => t.CarrierNavigation)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (tblJob == null)
            {
                return NotFound();
            }

            return View(tblJob);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblJob = await _context.TblJobs.FindAsync(id);
            if (tblJob != null)
            {
                _context.TblJobs.Remove(tblJob);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblJobExists(string id)
        {
            return _context.TblJobs.Any(e => e.JobId == id);
        }
    }
}
