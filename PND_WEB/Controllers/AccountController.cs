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

        
    }
}
