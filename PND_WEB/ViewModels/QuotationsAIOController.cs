using Microsoft.AspNetCore.Mvc;
using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class QuotationsAIOController
    {
        public required Quotation Quotation { get; set; }
        public required List<QuotationsCharge> QuotationsCharges { get; set; }

        public Currency? Currency { get; set; }
    }
}
