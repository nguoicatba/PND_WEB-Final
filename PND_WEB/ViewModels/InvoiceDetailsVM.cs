using PND_WEB.Models;
using System.Collections.Generic;

namespace PND_WEB.ViewModels
{
    public class InvoiceDetailsVM
    {
        public InvoiceVM ?Invoice { get; set; }
        public List<InvoiceCharge> ?Charges { get; set; }
    }

   
    
} 