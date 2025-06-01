using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;
[Table("INVOICE")]
public partial class Invoice
{

    [Key]
    [Column("ID")]

    public string Id { get; set; } = null!;

    [Column("Partner")]
    [Display(Name = "Partner")]
    public string? Partner { get; set; } = null!;


    [Column("Invoice_No")]
    [MaxLength(20)]
    [Display(Name = "Invoice No")]
    public string? InvoiceNo { get; set; }

    [Column("Type")]
    [Display(Name = "Type")]
    [MaxLength(20)]
    public string Type { get; set; } = null!;

    [Column("Currency")]
    [MaxLength(20)]
    [Display(Name = "Currency")]
    [Required(ErrorMessage = "Currency is required.")]
    public string? Currency { get; set; } = null!;

    [Column("Exchange_rate")]
    [Display(Name = "Exchange Rate")]
    public float? ExchangeRate { get; set; }

    [Column("Debit_date")]
    [Display(Name = "Debit Date")]

    public DateTime? DebitDate { get; set; } = DateTime.Now;

    [Column("Payment_date")]
    [Display(Name = "Payment Date")]


    public DateTime? PaymentDate { get; set; }

    [Column("Invoice_date")]
    [Display(Name = "Invoice Date")]

    public DateTime? InvoiceDate { get; set; }

    [Column("HBL")]
    [MaxLength(50)]
    [Display(Name = "HBL")]
    public string? Hbl { get; set; }

    public virtual ICollection<InvoiceCharge> InvoiceCharges { get; set; } = new List<InvoiceCharge>();
}
