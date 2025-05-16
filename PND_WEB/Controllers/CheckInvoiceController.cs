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

        [HttpGet]
        public async Task<IActionResult> InvoiceDetail(string id)
        {
            var invoice = await _context.TblInvoices
                .Where(invoice => invoice.DebitId == id)
                .Select(invoice => new InvoiceChargeViewModel
                {
                    HBL_ID = invoice.Hbl,
                    Invoice = invoice,
                    _Charges = _context.TblCharges.Where(charge => charge.DebitId == invoice.DebitId).ToList(),
                    TotalAmount = _context.TblCharges
                        .Where(charge => charge.DebitId == invoice.DebitId)
                        .Sum(charge => (charge.SerPrice ?? 0) * (charge.SerQuantity ?? 0) * (charge.ExchangeRate ?? 1) * (1 + (charge.SerVat ?? 0) / 100) + (charge.MVat ?? 0))

                }).FirstOrDefaultAsync();
            return View(invoice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveData([FromBody] List<TblCharge> charges)
        {
            if (charges == null || charges.Count == 0)
            {
                return Json(new { success = false, message = "No data to save." });
            }
            foreach (var charge in charges)
            {
                var existingCharge = await _context.TblCharges.FindAsync(charge.Id);
                if (existingCharge != null)
                {
                    existingCharge.SerName = charge.SerName;
                    existingCharge.SerUnit = charge.SerUnit;
                    existingCharge.SerQuantity = charge.SerQuantity;
                    existingCharge.SerPrice = charge.SerPrice;
                    existingCharge.Currency = charge.Currency;
                    existingCharge.ExchangeRate = charge.ExchangeRate;
                    existingCharge.SerVat = charge.SerVat;
                    existingCharge.MVat = charge.MVat;
                    existingCharge.Checked = charge.Checked;
                    _context.TblCharges.Update(existingCharge);
                }
            }
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Data saved successfully." });
        }



    }
}
