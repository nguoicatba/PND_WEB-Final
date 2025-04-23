using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class QuotationsEditDeleteDetailController
    {
        public required Quotation Quotation { get; set; }
        public required List<QuotationsCharge> QuotationsCharges { get; set; }

        public Currency? Currency { get; set; }

    }
}
