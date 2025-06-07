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
            var carrierViewModel = new CarrierActionViewModel
            {
                carrier = carrier,
                carrierActions = await _context.CarrierActions
                    .Where(a => a.Code == id)
                    .ToListAsync()
            };

            return View(carrierViewModel);
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
            var carrierid = _context.Carriers.Select(c => c.Code).ToList();
            if (carrierid.Contains(carrier.Code))
            {
                ModelState.AddModelError("CustomerId", "Mã carrier đã tồn tại");
            }
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
            if (id == null)
            {
                return NotFound();
            }
            var carrerAction = await _context.CarrierActions
           .Where(a => a.Code == id)
           .ToListAsync();
            if (carrerAction != null)
            {
                foreach (var item in carrerAction)
                {
                    _context.CarrierActions.Remove(item);
                }
            }
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

        [HttpGet]
        public async Task<IActionResult> CarrierCreate(string id)
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
            var carrierActionEditModel = new CarrierActionEditModel
            {
                id = carrier.Code,
                carrierAction = new CarrierAction()
            };
            return View(carrierActionEditModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarrierCreate(CarrierActionEditModel carrierActionEditModel)
        {
            if (ModelState.IsValid)
            {
                var carrier = await _context.Carriers.FindAsync(carrierActionEditModel.id);
                if (carrier == null)
                {
                    return NotFound();
                }
                carrierActionEditModel.carrierAction.Code = carrier.Code;
                _context.Add(carrierActionEditModel.carrierAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = carrierActionEditModel.id });
            }
            return View(carrierActionEditModel);
        }

        [HttpGet]
        public async Task<IActionResult> CarrierEdit(int id)
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
            var carrierActionEditModel = new CarrierActionEditModel
            {
                carrierAction = carrierAction,
                id = carrierAction.Code
            };
            return View(carrierActionEditModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarrierEdit(int id, CarrierActionEditModel carrierActionEditModel)
        {
            if (id != carrierActionEditModel.carrierAction.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrierActionEditModel.carrierAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierExists(carrierActionEditModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = carrierActionEditModel.carrierAction.Code });
            }
            return View(carrierActionEditModel);
        }


        [HttpGet]
        public async Task<IActionResult> CarrierDelete(int? id)
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
            var carrierEditModel = new CarrierActionEditModel
            {
                carrierAction = carrierAction,
                id = carrierAction.Code
            };
            return View(carrierEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarrierDelete(CarrierActionEditModel carrierEdit)
        {
            TempData["status"] = "Error: ";
            if (carrierEdit.carrierAction == null)
            {
                return NotFound();
            }
            var carrierAction = await _context.CarrierActions.FindAsync(carrierEdit.carrierAction.Id);
            var Code = carrierAction.Code;
            if (carrierAction == null)
            {
                return NotFound();
            }

            _context.CarrierActions.Remove(carrierAction);
            await _context.SaveChangesAsync();
            TempData["status"] = "Xóa thành công";
            return RedirectToAction("Details", new { id = Code });
        }

    }

}