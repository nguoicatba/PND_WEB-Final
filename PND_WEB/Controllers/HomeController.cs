using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;


namespace PND_WEB.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger,DataContext context )
        {
            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View(await _context.Modes.ToListAsync());
        }
        [HttpPost]
     
        public async Task<IActionResult> SaveData([FromBody] List<Mode> data)
        {
            if (data == null)
            {
                return BadRequest("D? li?u kh?ng h?p l?.");
            }

            // 1. L?y danh s?ch Mode hi?n c? trong DB
            var existingList = await _context.Modes.ToListAsync();

            // 2. T?o danh s?ch Code t? client g?i l?n
            var codesFromClient = data.Select(d => d.Code).ToList();

            // 3. C?p nh?t ho?c th?m m?i
            foreach (var item in data)
            {
                var existing = existingList.FirstOrDefault(x => x.Code == item.Code);
                if (existing != null)
                {
                    // C?p nh?t
                    existing.Note = item.Note;
                    // C?p nh?t th?m c?c tr??ng kh?c n?u c?
                }
                else
                {
                    // Th?m m?i
                    await _context.Modes.AddAsync(item);
                }
            }

            // 4. X?a c?c b?n ghi kh?ng c?n trong d? li?u client g?i l?n
            var toDelete = existingList.Where(x => !codesFromClient.Contains(x.Code)).ToList();
            if (toDelete.Any())
            {
                _context.Modes.RemoveRange(toDelete);
            }

            // 5. L?u thay ??i v?o CSDL
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "L?u d? li?u th?nh c?ng!" });

        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if (statuscode == 404)
            {
                return View("NotFound");
            }
           
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
