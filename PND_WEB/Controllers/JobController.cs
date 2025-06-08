using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PND_WEB.Controllers
{
    public class JobController : Controller
    {
        private readonly DataContext _context;
        UserManager<AppUserModel> _userManager;
        private readonly ILogger<JobController> _logger;

        public JobController(DataContext context, UserManager<AppUserModel> userManager, ILogger<JobController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Job'
        [ClaimAuthorize("Job", "Index")]
        public async Task<IActionResult> Index()
        {
            var jobs = await _context.TblJobs
                .Include(j => j.AgentNavigation)
                .Include(j => j.CarrierNavigation)
                .OrderByDescending(j => j.JobDate)
                .ToListAsync();

            // Cập nhật DateLock cho mỗi job
            foreach (var job in jobs)
            {
                var daysSinceCreation = (DateTime.Now - job.JobDate).Days;
                var newDateLock = Math.Max(-1, 15 - daysSinceCreation);
                
                if (job.YunLock != newDateLock)
                {
                    job.YunLock = newDateLock;
                    _context.Update(job);
                }
                if (job.JobStatus == false || job.YunLock < 0)
                {
                    job.YunLock = -1;
                    job.JobStatus = false; // Set JobStatus to false if YunLock is less than 0

                    _context.Update(job);
                }
            }

            // Lưu các thay đổi vào database
            if (_context.ChangeTracker.HasChanges())
            {
                await _context.SaveChangesAsync();
            }

            return View(jobs);
        }

        public async Task<bool> UserRequired(string jobId, string JobCreater)
        {
            var UserName = User.Identity.Name;
            if (User.IsInRole("SuperAdmin") || User.IsInRole("CEO"))
            {
                return true; // SuperAdmin or Admin can view any job
            }

            var UserId = await _userManager.FindByNameAsync(UserName);


            var UserJobExits = await _context.JobUser
                .Where(c => c.User_ID == UserId.Id && c.Job_ID == jobId)
                .FirstOrDefaultAsync();

            if (UserJobExits != null || UserName == JobCreater)
            {
                return true; // User is already assigned to the job
            }
            else return false;

        }

        [ClaimAuthorize("Job", "Details")]
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

          
            var userRequired = await UserRequired(id, tblJob.JobOwner);
            if (!userRequired)
            {
                _logger.LogWarning($"User {User.Identity.Name} is not authorized to view job details for Job ID: {id}");
                return Unauthorized("You do not have permission to view this job.");
            }




            return View(tblJob);
        }

        // GET: Job/Create
        [ClaimAuthorize("Job","Create")]
        public IActionResult Create()
        {
            ViewData["Mode"] = new SelectList(_context.Modes, "Code", "Code");
            return View();
        }

        public async Task<string> GenerateCode(string prefix)
        {
            string Date = DateTime.Now.ToString("yyyyMMdd");
            var lastJobs = await _context.TblJobs
                .Where(i => i.JobId.StartsWith(prefix) && i.JobId.Contains(Date))
                .OrderByDescending(i => i.JobId)
                .FirstOrDefaultAsync();
            if (lastJobs == null)
            {
                return $"{prefix}{Date}0001";
            }
            else
            {

                string lastCode = lastJobs.JobId.Substring(prefix.Length + Date.Length);
                int nextNumber = int.Parse(lastCode) + 1;
                return $"{prefix}{Date}/{nextNumber:D4}"; // D4 ensures the number is zero-padded to 4 digits

            }
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,GoodsType,JobDate,Mbl,IssueDateM,OnBoardDateM,VesselName,VoyageName,Pol,Pod,Podel,Podis,PlaceofReceipt,PlaceofDelivery,PreCariageBy,Etd,Eta,Mode,Agent,Carrier,Ycompany,Link,YunLock,UseTime")] TblJob tblJob)
        {
            tblJob.JobDate = DateTime.Now.Date;
            tblJob.JobId = await GenerateCode(tblJob.GoodsType+"HP");
            tblJob.YunLock = 15;
            tblJob.JobStatus = true;
            tblJob.JobOwner = User.Identity.Name ?? "UnknownUser"; 
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

            ViewData["Mode"] = new SelectList(_context.Modes, "Code", "Code", tblJob.Mode);

            return View(tblJob);
        }

        // GET: Job/Edit/5
        [ClaimAuthorize("Job", "Edit")]
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
            tblJob.AgentNavigation = await _context.Agents.FirstOrDefaultAsync(m => m.Code == tblJob.Agent);
            tblJob.CarrierNavigation = await _context.Carriers.FirstOrDefaultAsync(m => m.Code == tblJob.Carrier);

            ViewData["Mode"] = new SelectList(_context.Modes, "Code", "Code", tblJob.Mode);
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

            ViewData["Mode"] = new SelectList(_context.Modes, "Code", "Code", tblJob.Mode);
            return View(tblJob);
        }

        // GET: Job/Delete/5
        [ClaimAuthorize("Job", "Delete")]
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

        
        public async Task<IActionResult> CloseJob(string id)
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
            tblJob.JobStatus = false; // Set JobStatus to false to close the job
            tblJob.YunLock = -1; // Set YunLock to -1 to indicate the job is closed
            _context.Update(tblJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = id });
        }

        public async Task<IActionResult> UnLockJob (string id)
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
            tblJob.YunLock = 3; 
            tblJob.JobStatus = true; // Set JobStatus to true to unlock the job
            _context.Update(tblJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details),new {id=id});
        }

        public async Task<JsonResult> GoodsTypeGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = q== "" ? _context.GoodsTypes : _context.GoodsTypes.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.GtName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items =  paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.GtName,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Goods Type",
                    disabled = true
                });
            }
           
            return Json(new
            {
                items = items,
                total_count = totalCount,
                
                header= new
                {
                    header_code = "Code",
                    header_name = "Goods Type"
                }
            });


        }

        public async Task<JsonResult> AgentGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Agents : _context.Agents.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.AgentName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.AgentName,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Agent",
                    disabled = true
                });
            }


            return Json(new
            {
                items = items,
                total_count = totalCount,
                
                header = new
                {
                    header_code = "Code",
                    header_name = "Agent Name"
                }

            });
        }

        public async Task<JsonResult> CarrierGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = q == "" ? _context.Carriers : _context.Carriers.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.CarrierName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.Code,
                text = data.CarrierName,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Carrier",
                    disabled = true
                });
            }
            return Json(new
            {
                items = items,
                total_count = totalCount,
            
                header = new
                {
                    header_code = "Code",
                    header_name = "Carrier Name"
                }
            });


        }

        // GET: Job/PortGet
        //search port template by NguyenKien to save PortName not Code
        public async Task<JsonResult> PortGet(string q="", int page = 1)
        {
            int pageSize = 10;
            var query = _context.Cports.Where(data => data.Code.ToLower().Contains(q.ToLower()) || data.PortName.ToLower().Contains(q.ToLower()));
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.PortName,
                text = data.PortName,
                code = data.Code,
                disabled = false
            }).ToList();
            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select Port",
                    code = "-1",
                    disabled = true
                });
            }

            return Json(new
            {
                items = items,
                total_count = totalCount,
             
                header = new
                {
                    header_code = "Code",
                    header_name = "Port Name"
                }
            });
        }
    }
}
