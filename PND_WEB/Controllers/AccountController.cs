using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUserModel> _userManager;
        private SignInManager<AppUserModel> _signInManager;

        public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Login")]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(string url)
        {
            return View(new LoginViewModel {ReturnUrl =url });

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        

        public async Task<IActionResult> ChangePassword(string name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            var model = new ChangePasswordViewModel
            {
                UserName = user.UserName,
                OldPassword = "",
                NewPassword = "",
                ConfirmPassword = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            TempData["status"] = "Error: ";
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    return NotFound();
                }
                if (model.NewPassword != model.ConfirmPassword)
                {
                    TempData["status"] += "Mật khẩu không khớp\n";
                    return View(model);
                }

                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    TempData["status"] = "Thay đổi mật khẩu thành công";
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    TempData["status"] += error.Description;
                }
            }
            else
            {
               foreach (var error in ModelState.Values)
                {
                    foreach (var errorMessage in error.Errors)
                    {
                      TempData["status"] += errorMessage.ErrorMessage + "\n";
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAccount(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            var model = new AppUserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Staff_Name = user.Staff_Name,
                Status = user.Status,
                DOB = user.DOB,
                createDate = user.createDate
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccount(AppUserModel model)
        {
            TempData["status"] = "Error: \n";
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    TempData["status"] += "Người dùng không tồn tại\n";
                    return NotFound();
                }
                user.UserName = model.UserName;
                user.Staff_Name = model.Staff_Name;
                user.Status = model.Status;
                user.DOB = model.DOB;
                user.createDate = model.createDate;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["status"] = "Cập nhật thành công";
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    TempData["status"] += error.Description + "\n";
                }
            }
           
            return View(model);
        }





    }
}
