using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class JobUserController : Controller
    {
        private readonly DataContext _context;
        UserManager<AppUserModel> _userManager;
        public JobUserController(DataContext context, UserManager<AppUserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<string> RoleFormat(List<string> Role)
        {
            string result = "";
            foreach (var item in Role)
            {
                result += await _context.Roles
                    .Where(c => c.Id == item)
                    .Select(c => c.Name)
                    .FirstOrDefaultAsync() + ", ";
            }
            return result;
        }


        // id is job id
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.JobId = id;
            var GetListUser = await _context.JobUser
                .Where(c => c.Job_ID == id).Select(c => new
                {
                    c.Id,
                    c.User_ID,
                    c.Description,
                    c.CreateDate,

                })
                .ToListAsync();

            List<JobUserViewModel> jobUserViewModels = new List<JobUserViewModel>();

            foreach (var item in GetListUser)
            {
                JobUserViewModel jobUserViewModel = new JobUserViewModel();
                jobUserViewModel.Id = item.Id;
                jobUserViewModel.UserName = await _context.Users
                    .Where(c => c.Id == item.User_ID)
                    .Select(c => c.UserName)
                    .FirstOrDefaultAsync();
                jobUserViewModel.Staff_Name = await _context.Users
                    .Where(c => c.Id == item.User_ID)
                    .Select(c => c.Staff_Name)
                    .FirstOrDefaultAsync();
                jobUserViewModel.Description = item.Description;
                jobUserViewModel.CreateDate = item.CreateDate;
                jobUserViewModel.RoleName = await RoleFormat(await _context.UserRoles
                    .Where(c => c.UserId == item.User_ID)
                    .Select(c => c.RoleId)
                    .ToListAsync());
                jobUserViewModels.Add(jobUserViewModel);
            }
            return View(jobUserViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            JobUserEditModel jobUserEditModel = new JobUserEditModel();
            jobUserEditModel.Job_ID = id;

            return View(jobUserEditModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobUserEditModel jobUserEditModel)
        {
            if (ModelState.IsValid)
            {
                var check = await _context.JobUser
                    .Where(c => c.User_ID == jobUserEditModel.UserName && c.Job_ID == jobUserEditModel.Job_ID)
                    .FirstOrDefaultAsync();
                if (check != null)
                {
                    return RedirectToAction("Index", new { id = jobUserEditModel.Job_ID });
                }

                if (jobUserEditModel.Job_ID == null || jobUserEditModel.UserName == null)
                {
                    ModelState.AddModelError(string.Empty, "Job ID and User Name cannot be null.");
                    return View(jobUserEditModel);
                }

                JobUser jobUser = new JobUser
                {
                    User_ID = await _context.Users
                        .Where(c => c.UserName == jobUserEditModel.UserName)
                        .Select(c => c.Id)
                        .FirstOrDefaultAsync(),
                    Job_ID = jobUserEditModel.Job_ID,
                    Description = jobUserEditModel.Description,
                    CreateDate = DateTime.Now
                };

                await _context.JobUser.AddAsync(jobUser);
                await _context.SaveChangesAsync();
                @TempData["status"] = "Thêm nhân viên thành công";
                return RedirectToAction("Index", new { id = jobUserEditModel.Job_ID });
            }
            return View(jobUserEditModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jobUser = await _context.JobUser.FindAsync(id);
            if (jobUser == null)
            {
                return NotFound();
            }
            JobUserEditModel jobUserEditModel = new JobUserEditModel
            {
                Id = jobUser.Id,
                Job_ID = jobUser.Job_ID,
                UserName = await _context.Users
                    .Where(c => c.Id == jobUser.User_ID)
                    .Select(c => c.UserName)
                    .FirstOrDefaultAsync(),
                Staff_Name = await _context.Users
                    .Where(c => c.Id == jobUser.User_ID)
                    .Select(c => c.Staff_Name)
                    .FirstOrDefaultAsync(),
                Description = jobUser.Description
            };
            return View(jobUserEditModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobUserEditModel jobUserEditModel)
        {
            if (ModelState.IsValid)
            {
                var jobUser = await _context.JobUser.FindAsync(jobUserEditModel.Id);
                if (jobUser == null)
                {
                    return NotFound();
                }
                jobUser.Description = jobUserEditModel.Description;
                await _context.SaveChangesAsync();
                @TempData["status"] = "Cập nhật nhân viên thành công";
                return RedirectToAction("Index", new { id = jobUser.Job_ID });
            }
            return View(jobUserEditModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var jobUser = await _context.JobUser.FindAsync(id);
            if (jobUser == null)
            {
                return NotFound();
            }
            JobUserEditModel jobUserEditModel = new JobUserEditModel
            {
                Id = jobUser.Id,
                Job_ID = jobUser.Job_ID,
                UserName = await _context.Users
                    .Where(c => c.Id == jobUser.User_ID)
                    .Select(c => c.UserName)
                    .FirstOrDefaultAsync(),
                Staff_Name =  await _context.Users
                    .Where(c => c.Id == jobUser.User_ID)
                    .Select(c => c.Staff_Name)
                    .FirstOrDefaultAsync(),
                Description = jobUser.Description
            };
            return View(jobUserEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(JobUserEditModel jobUserEditModel)
        {


            var jobUser = await _context.JobUser.FindAsync(jobUserEditModel.Id);
            _context.JobUser.Remove(jobUser);
            await _context.SaveChangesAsync();
            @TempData["status"] = "Xóa nhân viên thành công";
            return RedirectToAction("Index", new { id = jobUserEditModel.Job_ID });
        }



        // select2 get user
        public async Task<JsonResult> GetUser(string q = "", int page = 1)
        {
            int pageSize = 10;
            // get user by key q
            var query = q == "" ?
                _userManager.Users.Select(c => new
                {
                    c.UserName,
                    c.Staff_Name
                }) :
                _userManager.Users.Where(c => c.UserName.Contains(q) || c.Staff_Name.Contains(q))
                .Select(c => new
                {
                    c.UserName,
                    c.Staff_Name
                });



            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var items = paginatedData.Select(data => new
            {
                id = data.UserName,
                text = data.Staff_Name,
                disabled = false
            }).ToList();

            if (page == 1)
            {
                items.Insert(0, new
                {
                    id = "-1",
                    text = "Select User",
                    disabled = true
                });
            }

            return Json(new
            {
                items = items,
                total_count = totalCount,

                header = new
                {
                    header_code = "User Name",
                    header_name = "Full Name"
                }
            });


        }



    }
    
}
