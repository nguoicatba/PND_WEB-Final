using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.Data;
using System.ComponentModel;
using System.Diagnostics;
using PND_WEB.ViewModels;
using DinkToPdf;
using PND_WEB.Services;
using DinkToPdf.Contracts;


namespace PND_WEB.Controllers
{
    public class HblsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        //pdf

        private readonly IViewRenderService _viewRenderService;
        private readonly IConverter _converter;



        public HblsController(ILogger<HomeController> logger, DataContext context, IViewRenderService viewRenderService, IConverter converter)
        {
            _logger = logger;
            _context = context;
            _viewRenderService = viewRenderService;
            _converter = converter;
        }

        [ClaimAuthorize("HBL","Index")]
        public async Task<IActionResult> Index(string id)
        {
            //if (await CheckJobExists(id) == false)
            //{
            //    return NotFound();
            //}

            HblJobViewModel hblJobViewModel = new HblJobViewModel();
            hblJobViewModel.Job_Id = id;
            hblJobViewModel.Hbls = await _context.TblHbls
                .Include(t => t.CneeNavigation)
                .Include(t => t.Customer)
                .Include(t => t.Request)
                .Include(t => t.ShipperNavigation)
                .Where(h => h.RequestId == id)
                .ToListAsync();


            return View(hblJobViewModel);
        }

        // GET: Hbls/Details/5
        [ClaimAuthorize("HBL", "Details")]
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
            ViewBag.GoodType = tblHbl.Request.GoodsType;
            return View(tblHbl);
        }

        public async Task<string> GenerateCode(string prefix)
        {
            string Date = DateTime.Now.ToString("yyyyMMdd");
            var lastHbls = await _context.TblHbls
                .Where(i => i.Hbl.StartsWith(prefix) && i.Hbl.Contains(Date))
                .OrderByDescending(i => i.Hbl)
                .FirstOrDefaultAsync();
            if (lastHbls == null)
            {
                return $"{prefix}{Date}0001";
            }
            else
            {
                string lastCode = lastHbls.Hbl.Substring(prefix.Length + Date.Length);
                int nextNumber = int.Parse(lastCode) + 1;
                return $"{prefix}{Date}/{nextNumber:D4}"; // D4 ensures the number is zero-padded to 4 digits
            }
        }

        // GET: Hbls/Create
        [ClaimAuthorize("HBL", "Create")]
        public IActionResult Create(string id)
        {
         
            ViewData["Mode"]= new SelectList(_context.Sourses, "Code", "Code");
            ViewData["Bl_Type"] = new SelectList(_context.BlTypes, "Code", "Code");

            HblJobEditModel hblJobEditModel = new HblJobEditModel();
            hblJobEditModel.Job_ID = id;
            hblJobEditModel.Hbl = new TblHbl();
            hblJobEditModel.Hbl.RequestId = id;
          
            return View(hblJobEditModel);
        }

        // POST: Hbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HblJobEditModel hblJobEditModel)
        {   
            
            if (ModelState.IsValid)
            {   
                
                string prefix ="HBL";
                hblJobEditModel.Hbl.Hbl = await GenerateCode(prefix);
                
                hblJobEditModel.Hbl.Collect = hblJobEditModel.Collect;
                hblJobEditModel.Hbl.Prepaid = hblJobEditModel.Prepaid;
                hblJobEditModel.Hbl.FreightCharge = hblJobEditModel.FreightCharge;
                
                _context.Add(hblJobEditModel.Hbl);
                await _context.SaveChangesAsync();
               
                return RedirectToAction("Index","Hbls",new {id=hblJobEditModel.Hbl.RequestId});
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
    
            ViewData["Mode"] = new SelectList(_context.Sourses, "Code", "Code", hblJobEditModel.Hbl.NomFree);
            ViewData["Bl_Type"] = new SelectList(_context.BlTypes, "Code", "Code", hblJobEditModel.Hbl.BlType);
            return View(hblJobEditModel);
        }

        // GET: Hbls/Edit/5
        [HttpGet]
        [ActionName("Edit")]
        [ClaimAuthorize("HBL", "Edit")]
        public async Task<IActionResult> Edit(string id)
        {

            if (await CheckHbl(id) == false)
            {
                return NotFound();
            }
            var tblHbl = await _context.TblHbls
                .Include(t => t.CneeNavigation)
                .Include(t => t.Customer)
                .Include(t => t.Request)
                .Include(t => t.ShipperNavigation)
                .FirstOrDefaultAsync(m => m.Hbl == id);

            HblJobEditModel hblJobEditModel = new HblJobEditModel();
            hblJobEditModel.Job_ID =tblHbl.RequestId;
            hblJobEditModel.Hbl = tblHbl;
            hblJobEditModel.FreightCharge = tblHbl.FreightCharge ?? false;
            hblJobEditModel.Prepaid = tblHbl.Prepaid ?? false;
            hblJobEditModel.Collect = tblHbl.Collect ?? false;
            hblJobEditModel.Hbl.RequestId = tblHbl.RequestId;
            hblJobEditModel.Hbl.CneeNavigation =_context.TblCnees.FirstOrDefault(c => c.Cnee == tblHbl.Cnee);
            hblJobEditModel.Hbl.ShipperNavigation = _context.TblShippers.FirstOrDefault(c => c.Shipper == tblHbl.Shipper);
            hblJobEditModel.Hbl.Customer = _context.TblCustomers.FirstOrDefault(c => c.CustomerId == tblHbl.CustomerId);

            ViewData["Mode"] = new SelectList(_context.Sourses, "Code", "Code", hblJobEditModel.Hbl.NomFree);
            ViewData["Bl_Type"] = new SelectList(_context.BlTypes, "Code", "Code", hblJobEditModel.Hbl.BlType);
            return View(hblJobEditModel);
        }

        // POST: Hbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,HblJobEditModel hblJobEditModel)
        {
            if (id != hblJobEditModel.Hbl.Hbl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hblJobEditModel.Hbl.Collect = hblJobEditModel.Collect;
                    hblJobEditModel.Hbl.Prepaid = hblJobEditModel.Prepaid;
                    hblJobEditModel.Hbl.FreightCharge = hblJobEditModel.FreightCharge;
                  
                    _context.Update(hblJobEditModel.Hbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHblExists(hblJobEditModel.Hbl.Hbl))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Hbls", new { id = hblJobEditModel.Hbl.RequestId });

            }
       
            ViewData["Mode"] = new SelectList(_context.Sourses, "Code", "Code", hblJobEditModel.Hbl.NomFree);
            ViewData["Bl_Type"] = new SelectList(_context.BlTypes, "Code", "Code", hblJobEditModel.Hbl.BlType);
            return View(hblJobEditModel);
        }

        // GET: Hbls/Delete/5
        [ClaimAuthorize("HBL", "Delete")]
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
            var job_id = tblHbl.RequestId;
            if (tblHbl != null)
            {
                _context.TblHbls.Remove(tblHbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Hbls", new { id = job_id });
        }

        private bool TblHblExists(string id)
        {
            return _context.TblHbls.Any(e => e.Hbl == id);
        }


        public async Task<bool> CheckHbl(string id)
        {

            if (id == null) return false;
            var hbl = await _context.TblHbls.FindAsync(id);
            if (hbl == null) return false;
            if (hbl.RequestId == null) return false;
            var job = await _context.TblJobs.FindAsync(hbl.RequestId);
            if (job == null) return false;
            return true;

        }

        public async Task<IActionResult> ShipperGet(string q = "", int page = 1)
        {
            try
            {
                int pageSize = 10;
                var query = q == "" ? _context.TblShippers : _context.TblShippers.Where(data => 
                    data.Shipper.ToLower().Contains(q.ToLower()) || 
                    data.ShipperName.ToLower().Contains(q.ToLower()) ||
                    data.TaxId.ToLower().Contains(q.ToLower()));
                var totalCount = await query.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var items = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(data => new
                    {
                        id = data.Shipper,
                        text = data.ShipperName,
                        tax = data.TaxId,
                        disabled = false
                    })
                    .ToListAsync();
                // insert -1
                if (page == 1)
                {
                    items.Insert(0, new
                    {
                        id = "-1",
                        text = "Select Shipper",
                        tax = "",
                        disabled = true
                    });
                }

                var header = new
                {
                    header_code = "Code",
                    header_name = "Name",
                    header_tax = "Tax ID"
                };

                return Json(new { total_count = totalCount, items, header });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        public async Task<IActionResult> CneeGet(string q = "", int page = 1)
        {
            try
            {
                int pageSize = 10;
                var query = q == "" ? _context.TblCnees : _context.TblCnees.Where(data => 
                    data.Cnee.ToLower().Contains(q.ToLower()) || 
                    data.Vcnee.ToLower().Contains(q.ToLower()) ||
                    data.TaxId.ToLower().Contains(q.ToLower()));
                var totalCount = await query.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var items = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(data => new
                    {
                        id = data.Cnee,
                        text = data.Vcnee,
                        tax = data.TaxId,
                        disabled = false
                    })
                    .ToListAsync();
                // insert -1
                if (page == 1)
                {
                    items.Insert(0, new
                    {
                        id = "-1",
                        text = "Select Cnee",
                        tax = "",
                        disabled = true
                    });
                }


                var header = new
                {
                    header_code = "Code",
                    header_name = "Name", 
                    header_tax = "Tax ID"
                };

                return Json(new { total_count = totalCount, items, header });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        public async Task<JsonResult> CustomerGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.TblCustomers : _context.TblCustomers.Where(data => data.CustomerId.ToLower().Contains(q.ToLower()) || data.CompanyName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.CustomerId,
                text = data.CompanyName,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Customer",
                    disabled = true
                });
            }
            return Json(new
            {
                items = items,
                total_count = totalCount,
                header = new
                {
                    header_code = "Customer Code",
                    header_name = "Customer Name"
                }

            });
        }

        //HBL ID
        public async Task<IActionResult> ExportPDFDO(string id)
        {

            //sửa dữ liệu
           var Hbl = await _context.TblHbls
                .Include(t => t.CneeNavigation)
                .Include(t => t.Customer)
                .Include(t => t.Request)
                .Include(t => t.ShipperNavigation)
                .FirstOrDefaultAsync(m => m.Hbl == id);

            if (Hbl == null)
                return NotFound();

            var viewModel = new ExportPDFDeliveryOrderVM
            {
                HBL = Hbl.Hbl,

                JobId = Hbl.RequestId,
                POL = Hbl.Request?.Pol,
                POD = Hbl.Request?.Pod,
                CNEE = Hbl.CneeNavigation?.Cnee,
                MBL = Hbl.Request?.Mbl,
                ArriveOn =Hbl.Request.Eta,
                Vessel = Hbl.Request?.VesselName,
                Voyage = Hbl.Request?.VoyageName,
                Podel = Hbl.Request?.Podel,
                conths = await _context.TblConths
                    .Where(c => c.Hbl == Hbl.Hbl)
                    .ToListAsync()

            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFDeliveryOrder", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,


                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=DO.pdf");
            return File(file, "application/pdf");
        }

        // HBL ID
        public async Task<IActionResult> ExportPDFAN(string id)
        {

            var Hbl = await _context.TblHbls
               .Include(t => t.CneeNavigation)
               .Include(t => t.Customer)
               .Include(t => t.Request)
               .Include(t => t.ShipperNavigation)
               .FirstOrDefaultAsync(m => m.Hbl == id);

            if (Hbl == null)
                return NotFound();
            var viewModel = new ArrivalNoticeVM
            {
                HBL_ID = Hbl.Hbl,
                Job_ID = Hbl.RequestId,
                Goods_Type = Hbl.Request?.GoodsType,
                POL = Hbl.Request?.Pol,
                POD = Hbl.Request?.Pod,
                PODel = Hbl.Request?.Podel,
                Shipper = Hbl.ShipperNavigation?.Shipper,
                CNEE = Hbl.CneeNavigation?.Cnee,
                MBL = Hbl.Request?.Mbl,
                HBL = Hbl.Hbl,
                Transport = Hbl.Request?.GoodsType == "AI" || Hbl.Request?.GoodsType == "AE" ? Hbl.Request.VesselName: Hbl.Request?.VesselName + "/" + Hbl.Request?.VoyageName,
                ETA = Hbl.Request.Eta,
                BL_Type = Hbl.BlType,
                tblConths = await _context.TblConths
                    .Where(c => c.Hbl == Hbl.Hbl)
                    .ToListAsync()

            };


            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFArrivalNote", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=AN.pdf");
            return File(file, "application/pdf");
        }


        public async Task<IActionResult> ExportPDFHBL(string id)
        {

            var Hbl = await _context.TblHbls
               .Include(t => t.CneeNavigation)
               .Include(t => t.Customer)
               .Include(t => t.Request)
               .Include(t => t.ShipperNavigation)
               .FirstOrDefaultAsync(m => m.Hbl == id);

            if (Hbl == null)
                return NotFound();
            var viewModel = new ExportHblVM
            {
                Hbl = Hbl.Hbl,
                RequestId = Hbl.RequestId,
                GoodType = Hbl.Request?.GoodsType,
                Shipper = Hbl.ShipperNavigation,
                Cnee = Hbl.CneeNavigation,
                NotifyParty = Hbl.NotifyParty,
                NotifyPartyCnee = _context.TblCnees.FirstOrDefault(c => c.Cnee == Hbl.NotifyParty),
                PlaceOfReceipt = Hbl.Request?.PlaceofReceipt,
                PlaceOfDelivery = Hbl.Request?.PlaceofDelivery,
                Pod = Hbl.Request?.Pod,
                Pol = Hbl.Request?.Pol,
                BILL_TYPE = Hbl.BlType,
                NumberOfOriginal = Hbl.NumberofOrigins,
                Transport = Hbl.Request?.GoodsType == "AI" || Hbl.Request?.GoodsType == "AE" ? Hbl.Request.VesselName : Hbl.Request?.VesselName + "/" + Hbl.Request?.VoyageName,
                FreightPayable = Hbl.FreightPayable,
                MarkNo = Hbl.MarkNos,
                Quantity = Hbl.Quantity,
                PreCariageBy = Hbl.Request?.PreCariageBy,
                DescriptionOfGoods = Hbl.GoodsDesciption,
                GrossWeight = Hbl.GrossWeight ?? 0.0,
                Tonnage = (Hbl.GrossWeight ?? 0.0) / 1000.0,
                FreightCharge = Hbl.FreightCharge,
                Prepaid = Hbl.Prepaid,
                Collect = Hbl.Collect,


            };


            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFHBL", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=BILL.pdf");
            return File(file, "application/pdf");
        }

        public async Task<IActionResult> NotifyPartyGet(string q = "", int page = 1)
        {
            try
            {
                int pageSize = 10;
                var query = q == "" ? _context.TblCnees : _context.TblCnees.Where(data => 
                    data.Cnee.ToLower().Contains(q.ToLower()) || 
                    data.Vcnee.ToLower().Contains(q.ToLower()) ||
                    data.TaxId.ToLower().Contains(q.ToLower()));
                var totalCount = await query.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var items = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(data => new
                    {
                        id = data.Cnee,
                        text = data.Vcnee,
                        tax = data.TaxId,
                        disabled = false
                    })
                    .ToListAsync();

                // insert special options at page 1
                if (page == 1)
                {
                    items.Insert(0, new
                    {
                        id = "-1",
                        text = "Select Notify Party",
                        tax = "",
                        disabled = true
                    });
                    
                    items.Insert(1, new
                    {
                        id = "Same as Consignee",
                        text = "Same as Consignee",
                        tax = "",
                        disabled = false
                    });
                }

                var header = new
                {
                    header_code = "Code",
                    header_name = "Name", 
                    header_tax = "Tax ID"
                };

                return Json(new { total_count = totalCount, items, header });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
