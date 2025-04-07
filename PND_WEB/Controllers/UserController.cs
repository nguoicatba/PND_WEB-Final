using Microsoft.AspNetCore.Mvc;
using PND_WEB.Repository;
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

                if (userModel.Role_Id != null)
                {
                    var role = await _roleManager.FindByIdAsync(userModel.Role_Id);
                    var IdentityResult = await _userManager.AddToRoleAsync(user, role.Name);
                }

                IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
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
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            Console.WriteLine(user.PasswordHash);
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
                if (userModel.Role_Id != null)
                {
                    var role = await _roleManager.FindByIdAsync(userModel.Role_Id);
                    var IdentityResult = await _userManager.AddToRoleAsync(user, role.Name);
                }
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

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            var userModel = new UserModel()
            {
                UserName = user.UserName,
                Staff_Name = user.Staff_Name,
                DOB = user.DOB,
                Role_Id = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                IdentityResult result = await _userManager.DeleteAsync(user);
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
    }
}
