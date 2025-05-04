using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class InvoiceChargeEditModel
    {
        public string? HBL_ID { get; set; }
        public string? InvoiceID { get; set; }
       
        public TblCharge? Charge { get; set; }

    }
}
