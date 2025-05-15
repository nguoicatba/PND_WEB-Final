using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class CheckInvoiceController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUserModel> _userManager;
        public CheckInvoiceController(DataContext context, UserManager<AppUserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
      
            var JobListID = _context.JobUser.Where(user => user.User_ID == userId).Select(user => user.Job_ID).ToList();
       
            var jobList = _context.TblJobs.Where(job => JobListID.Contains(job.JobId)).ToList();

            return View(jobList);
        }
        // job id
        [HttpGet]
        public async Task<IActionResult> InvoiceIndex(string id)
        {

            var HblListId = await _context.TblHbls
                .Where(hbl => hbl.RequestId == id)
                .Select(hbl => hbl.Hbl)
                .ToListAsync();

            var invoiceList = await _context.TblInvoices
                .Where(invoice => HblListId.Contains(invoice.Hbl)).Select(invoice=> invoice.DebitId)
                .ToListAsync();
            List<CheckDebitVM> checkDebitVMs = new List<CheckDebitVM>();
            foreach (var item in invoiceList)
            {
                var invoice = await _context.TblInvoices
                    .Where(invoice => invoice.DebitId == item)
                    .Select(invoice => new CheckDebitVM
                    {
                        DebitId = invoice.DebitId,
                        InvoiceType = invoice.InvoiceType,
                        DebitDate = invoice.DebitDate,
                        PaymentDate = invoice.PaymentDate,
                        InvoiceNo = invoice.InvoiceNo,
                        InvoiceDate = invoice.InvoiceDate,
                        SupplierName = "",
                        Hbl = invoice.Hbl
                    }).FirstOrDefaultAsync();
                checkDebitVMs.Add(invoice);
            }
            return View(checkDebitVMs);
        }

        //public async Task<bool> CheckSupplier(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        return false;

        //    return await _context.TblSuppliers.AnyAsync(s => s.SupplierId == id);
        //}

    }
}
