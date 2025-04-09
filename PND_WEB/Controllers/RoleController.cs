using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PND_WEB.Controllers
{
    public class RoleController : Controller
    {   
        RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
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
                    @TempData["status"]+= "Tên role không được để trống";
                    return View(role);

                }
                if (await _roleManager.RoleExistsAsync(role.Name) == true)
                {
                   
                    @TempData["status"]+= "Tên role đã tồn tại";

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


    }
}
