using Microsoft.AspNetCore.Mvc;

namespace PND_WEB.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
