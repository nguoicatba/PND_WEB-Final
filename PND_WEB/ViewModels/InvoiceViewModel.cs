using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class InvoiceViewModel
    {
        public required string HBL_ID { get; set; }
        public List<TblInvoice> ?invoices {get; set;}

        public string ? GoodType { get; set; }




    }
}
