using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;
using System.Security.Claims;

namespace PND_WEB.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<AppUserModel> _userManager;
        DataContext _dataContext;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager,DataContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dataContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]

        public async Task<IActionResult> CreateRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            @TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    @TempData["status"] = "Tạo role thành công";
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {

                    @TempData["status"] += error.Description + " ";
                }
            }
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(IdentityRole role)
        {
            @TempData["status"] = "Error: ";

            if (ModelState.IsValid)
            {
                if (role.Name == null)
                {
                    @TempData["status"] += "Tên role không được để trống";
                    return View(role);

                }
                if (await _roleManager.RoleExistsAsync(role.Name) == true)
                {

                    @TempData["status"] += "Tên role đã tồn tại";

                    return View(role);
                }
                var oldRole = await _roleManager.FindByIdAsync(role.Id);
                oldRole.Name = role.Name;

                var result = await _roleManager.UpdateAsync(oldRole);
                if (result.Succeeded)
                {
                    @TempData["status"] = "Cập nhật role thành công";
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    @TempData["status"] += error.Description + " ";
                }
            }
            return View(role);
        }


        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                @TempData["status"] = "Xóa role thành công";

            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> ListUserRole()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new List<UserRole>();
            foreach (var user in users)
            {
                
                var userRole = new UserRole()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles= (await _userManager.GetRolesAsync(user)).ToList()
                };
                userRoles.Add(userRole);
            }
            return View(userRoles);

        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userRole = new UserRole()
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = (await _userManager.GetRolesAsync(user)).ToList(),
                AllRoles = (await _roleManager.Roles.Select(X => new SelectListItem
                {
                    Value = X.Name,
                    Text = X.Name
                }).ToListAsync())

            };

            return View(userRole);




        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateUserRole(UserRole userRole)
        {
            @TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userRole.Id);
                if (user == null)
                {
                    @TempData["status"] += "Người dùng không tồn tại";
                    return View(userRole);
                }
                var roles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                if (!result.Succeeded)
                {
                    @TempData["status"] += "Xóa role không thành công";
                    return View(userRole);
                }
                result = await _userManager.AddToRolesAsync(user, userRole.Roles);
                if (result.Succeeded)
                {
                    @TempData["status"] = "Cập nhật role thành công";
                    return RedirectToAction("ListUserRole");
                }
                foreach (var error in result.Errors)
                {
                    @TempData["status"] += error.Description + " ";
                }
            }





            return View(userRole);
        }



        [HttpGet]
        public async Task<IActionResult> UpdateRoleClaims(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var ListRoleClaims = await _roleManager.GetClaimsAsync(role);
            var ListSystemClaims = await _dataContext.Claims.ToListAsync();
            var ClaimSet = ListRoleClaims.Select(c => $"{c.Type}:{c.Value}").ToHashSet();

            List<ClaimViewModel> claims = new List<ClaimViewModel>();

            foreach (var claim in ListSystemClaims)
            {
                string key = $"{claim.ClaimType}:{claim.ClaimValue}";
                claims.Add(new ClaimViewModel
                {
                    ClaimId = claim.Id,
                    ClaimType = claim.ClaimType,
                    ClaimValue = claim.ClaimValue,
                    Description = claim.Description,
                    Selected = ClaimSet.Contains(key)
                });
               

            }

            RoleClaimsViewModel roleClaims = new RoleClaimsViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,

                Claims = claims
            };

            return View(roleClaims);
        }
        [HttpPost]
        public async Task<IActionResult> SaveRoleClaims([FromBody] RoleClaimsViewModel roleClaims)
        {
            var role = await _roleManager.FindByIdAsync(roleClaims.RoleId);
            if (role == null)
            {
                return Json(new { success = false });
            }

            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role,claim);
            }

            foreach (var claim in roleClaims.Claims)
            {
                if (claim.Selected == false)
                    continue;
                await _roleManager.AddClaimAsync(role, new Claim(claim.ClaimType, claim.ClaimValue));
            }


            return Json(new { success = true });
        }



    }
}
