using Microsoft.AspNetCore.Mvc;
using PND_WEB.Data;
using PND_WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using PND_WEB.ViewModels;


namespace PND_WEB.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public UserController(UserManager<AppUserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }

        
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.OrderByDescending(p => p.Id).ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            @TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var user = new AppUserModel()
                {
                    UserName = userModel.UserName,
                    Status = "Active",
                    createDate = DateTime.Now,
                    Staff_Name = userModel.Staff_Name,
                    DOB = userModel.DOB,
                };

              

                IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    @TempData["status"] = "Tạo tài khoản thành công";
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    @TempData["status"] += error.Description + " ";

                }
            }
            else
            {
                foreach (var error in ModelState.Values)
                {
                    foreach (var subError in error.Errors)
                    {
                        @TempData["status"] += subError.ErrorMessage + " ";
                    }
                }

            }
            return View(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
        
            var userModel = new UserModel()
            {
                UserName = user.UserName,
                Staff_Name = user.Staff_Name,
                DOB = user.DOB,
                Password = user.PasswordHash
            };
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                user.UserName = userModel.UserName;
                user.Staff_Name = userModel.Staff_Name;
                user.DOB = userModel.DOB;
              
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(userModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AppUserModel user)
        {
            var userInDb = await _userManager.FindByIdAsync(user.Id);
            if (userInDb == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(userInDb);
            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(user);
        }


        [HttpGet]
        public async Task<IActionResult> ResetPW(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userModel = new UserModel()
            {
                UserName = user.UserName,
                Staff_Name = user.Staff_Name,
                DOB = user.DOB,
            };
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPW(string id, UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (!removePasswordResult.Succeeded)
                {
                    foreach (var error in removePasswordResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(userModel);
                }

                var addPasswordResult = await _userManager.AddPasswordAsync(user, userModel.Password);
                if (addPasswordResult.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }

                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(userModel);
        }

    }
}
