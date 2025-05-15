using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class CheckDebitVM
    {
        [Display(Name = "Debit ID")]
        public string DebitId { get; set; } = null!;

        [Display(Name = "Invoice Type")]
        public string? InvoiceType { get; set; }
        [Display(Name = "Debit Date")]
        public DateTime? DebitDate { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime? PaymentDate { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }

        [Display(Name = "Supplier")]
        public string? SupplierName { get; set; }

        [Display(Name = "HBL")]
        public string? Hbl { get; set; }

    }
}
