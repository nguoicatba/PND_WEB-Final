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
    public class TblSupplierController : Controller
    {
        private readonly DataContext _context;

        public TblSupplierController(DataContext context)
        {
            _context = context;
        }

        // GET: TblSupplier
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.TblSuppliers.ToListAsync());
        }

        // GET: TblSupplier/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblsupplier = await _context.TblSuppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (tblsupplier == null)
            {
                return NotFound();
            }

            SupplierActionViewModel supplierViewModel = new SupplierActionViewModel();
            supplierViewModel.supplierActions = await _context.TblSupplierActions.Where(c => c.SupplierId == id).ToListAsync();
            supplierViewModel.supplier = tblsupplier;

            return View(supplierViewModel);
        }

        // GET: TblSupplier/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new SelectList(_context.InvoiceTypes, "NameType", "NameType");
            return View();
        }

        // POST: TblSupplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,NameSup,Typer,AddressSup,LccFee,Note")] TblSupplier tblSupplier)
        {
            var supplierid = _context.TblSuppliers.Select(c => c.SupplierId).ToList();
            if (supplierid.Contains(tblSupplier.SupplierId))
            {
                ModelState.AddModelError("CustomerId", "Mã supplier đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                
                _context.Add(tblSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Type"] = new SelectList(_context.InvoiceTypes, "NameType", "NameType");
            return View(tblSupplier);
        }

        // GET: TblSupplier/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplier = await _context.TblSuppliers.FindAsync(id);
            if (tblSupplier == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.InvoiceTypes, "NameType", "NameType");
            return View(tblSupplier);
        }

        // POST: TblSupplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierId,NameSup,Typer,AddressSup,LccFee,Note")] TblSupplier tblSupplier)
        {
            if (id != tblSupplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSupplierExists(tblSupplier.SupplierId))
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
            ViewData["Type"] = new SelectList(_context.InvoiceTypes, "NameType", "NameType");
            return View(tblSupplier);
        }

        // GET: TblSupplier/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSupplier = await _context.TblSuppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (tblSupplier == null)
            {
                return NotFound();
            }

            return View(tblSupplier);
        }

        // POST: TblSupplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblSupplier = await _context.TblSuppliers.FindAsync(id);
            if (tblSupplier != null)
            {
                _context.TblSuppliers.Remove(tblSupplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSupplierExists(string id)
        {
            return _context.TblSuppliers.Any(e => e.SupplierId == id);
        }



        //supplieractions

        [HttpGet]
        [Route("TblSupplier/SupplierCreate/{id}")]
        public async Task<IActionResult> SupplierCreate(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplier = await _context.TblSuppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            SupplierActionEditModel supplierViewModel = new();
            supplierViewModel.id = id;
            supplierViewModel.supplierAction = new TblSupplierAction();
            return View(supplierViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplierCreate(SupplierActionEditModel supplierEdit)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var supplier = await _context.TblSuppliers.FindAsync(supplierEdit.id);
                if (supplier == null)
                {
                    return NotFound();
                }
                supplierEdit.supplierAction.SupplierId = supplierEdit.id;
                _context.TblSupplierActions.Add(supplierEdit.supplierAction);
                await _context.SaveChangesAsync();
                TempData["status"] = "Thêm thành công";
                return RedirectToAction("Details", new { id = supplierEdit.id });
            }
            else
            {
                TempData["status"] += "Thêm không thành công";
            }
            return View(supplierEdit);
        }

        [HttpGet]
        public async Task<IActionResult> SupplierEdit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplierAction = await _context.TblSupplierActions.FindAsync(id);
            if (supplierAction == null)
            {
                return NotFound();
            }
            var supplierEditModel = new SupplierActionEditModel
            {
                supplierAction = supplierAction,
                id = supplierAction.SupplierId,
            };

            return View(supplierEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplierEdit(SupplierActionEditModel supplierEdit)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var supplierAction = await _context.TblSupplierActions.FindAsync(supplierEdit.supplierAction.Id);
                if (supplierAction == null)
                {
                    return NotFound();
                }

                supplierAction.PersonInCharge = supplierEdit.supplierAction.PersonInCharge;
                supplierAction.PhoneNumber = supplierEdit.supplierAction.PhoneNumber;
                supplierAction.Email = supplierEdit.supplierAction.Email;
                supplierAction.Note = supplierEdit.supplierAction.Note;
                _context.Update(supplierAction);
                await _context.SaveChangesAsync();
                TempData["status"] = "Sửa thành công";
                return RedirectToAction("Details", new { id = supplierEdit.supplierAction.SupplierId });
            }
            else
            {
                TempData["status"] += "Sửa không thành công";
            }
            return View(supplierEdit);
        }


        [HttpGet]
        public async Task<IActionResult> SupplierDelete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplierAction = await _context.TblSupplierActions.FindAsync(id);
            if (supplierAction == null)
            {
                return NotFound();
            }
            var supplierEditModel = new SupplierActionEditModel
            {
                supplierAction = supplierAction,
                id = supplierAction.SupplierId,
            };
            return View(supplierEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplierDelete(SupplierActionEditModel supplierEdit)
        {
            TempData["status"] = "Error: ";
            if (supplierEdit.supplierAction == null)
            {
                return NotFound();
            }
            var supplierAction = await _context.TblSupplierActions.FindAsync(supplierEdit.supplierAction.Id);
            var Code = supplierAction.SupplierId;
            if (supplierAction == null)
            {
                return NotFound();
            }

            _context.TblSupplierActions.Remove(supplierAction);
            await _context.SaveChangesAsync();
            TempData["status"] = "Xóa thành công";
            return RedirectToAction("Details", new { id = Code });
        }
    }
}