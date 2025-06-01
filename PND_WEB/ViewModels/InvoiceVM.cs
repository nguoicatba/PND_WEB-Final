using System;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class InvoiceVM
    {
        public string Id { get; set; }

        [Display(Name = "Partner")]
        public string Partner { get; set; }

        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "Exchange Rate")]
        public float? ExchangeRate { get; set; }

        [Display(Name = "Debit Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DebitDate { get; set; }

        [Display(Name = "Payment Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PaymentDate { get; set; }

        [Display(Name = "Invoice Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InvoiceDate { get; set; }

        [Display(Name = "HBL")]
        public string Hbl { get; set; }

        [Display(Name = "Invoice Type")]
        public string InvoiceType { get; set; }

        [Display(Name = "Partner Type")]
        public string PartnerType { get; set; }
    }
} 