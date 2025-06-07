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

            CneeViewModel cneeViewModel = new CneeViewModel();
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
                var cneeid = _context.TblCnees.Select(c => c.Cnee).ToList();
                if (cneeid.Contains(tblCnee.Cnee))
                {
                    ModelState.AddModelError("CustomerId", "Mã cnee đã tồn tại");
                }
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





        //
        [HttpGet]
        [Route("TblCnee/CneeAddCreate/{id}")]
        public async Task<IActionResult> CneeAddCreate(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cnee = await _context.TblCnees.FindAsync(id);
            if (cnee == null)
            {
                return NotFound();
            }
            CneeEditModel cneeViewModel = new();
            cneeViewModel.id = id;
            cneeViewModel.CneeAdd = new TblCneeAdd();
            return View(cneeViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CneeAddCreate(CneeEditModel cneeEdit)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var cnee = await _context.TblCnees.FindAsync(cneeEdit.id);
                if (cnee == null)
                {
                    return NotFound();
                }
                cneeEdit.CneeAdd.Cnee = cneeEdit.id;
                _context.TblCneeAdds.Add(cneeEdit.CneeAdd);
                await _context.SaveChangesAsync();
                TempData["status"] = "Thêm thành công";
                return RedirectToAction("Details", new { id = cneeEdit.id });
            }
            else
            {
                TempData["status"] += "Thêm không thành công";
            }
            return View(cneeEdit);

        }

        [HttpGet]
        public async Task<IActionResult> CneeAddEdit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cneeadd = await _context.TblCneeAdds.FindAsync(id);
            if (cneeadd == null)
            {
                return NotFound();
            }
            var cneeEditModel = new CneeEditModel
            {
                id = cneeadd.Cnee,
                CneeAdd = cneeadd,
            };

            return View(cneeEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CneeAddEdit(CneeEditModel cneeEdit)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var CneeAddAction = await _context.TblCneeAdds.FindAsync(cneeEdit.CneeAdd.Id);
                if (CneeAddAction == null)
                {
                    return NotFound();
                }

                CneeAddAction.Adds = cneeEdit.CneeAdd.Adds;
                CneeAddAction.PersonInCharge = cneeEdit.CneeAdd.PersonInCharge;
                CneeAddAction.Place = cneeEdit.CneeAdd.Place;
                CneeAddAction.Id = cneeEdit.CneeAdd.Id;
                _context.Update(CneeAddAction);
                await _context.SaveChangesAsync();
                TempData["status"] = "Sửa thành công";
                return RedirectToAction("Details", new { id = cneeEdit.CneeAdd.Cnee });
            }
            else
            {
                TempData["status"] += "Sửa không thành công";
            }
            return View(cneeEdit);
        }


        [HttpGet]
        public async Task<IActionResult> CneeAddDelete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cneeaddAction = await _context.TblCneeAdds.FindAsync(id);
            if (cneeaddAction == null)
            {
                return NotFound();
            }
            var cneeadddEditModel = new CneeEditModel
            {
                CneeAdd = cneeaddAction,
                id = cneeaddAction.Cnee
            };
            return View(cneeadddEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CneeAddDelete(CneeEditModel cneeEdit)
        {
            TempData["status"] = "Error: ";
            if (cneeEdit.CneeAdd == null)
            {
                return NotFound();
            }
            var cneeaddAction = await _context.TblCneeAdds.FindAsync(cneeEdit.CneeAdd.Id);
            var Code = cneeaddAction.Cnee;
            if (cneeaddAction == null)
            {
                return NotFound();
            }

            _context.TblCneeAdds.Remove(cneeaddAction);
            await _context.SaveChangesAsync();
            TempData["status"] = "Xóa thành công";
            return RedirectToAction("Details", new { id = Code });
        }
    }
}