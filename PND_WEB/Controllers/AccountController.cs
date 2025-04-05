using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
