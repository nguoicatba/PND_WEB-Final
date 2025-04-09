using Microsoft.AspNetCore.Mvc;
using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class QuotationsAIOController : Controller
    {
        public required Quotation Quotation { get; set; }
        public required List<QuotationsCharge> QuotationsCharges { get; set; }
    }
}
