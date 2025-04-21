using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;
[Table("tbl_INVOICE")]
public partial class TblInvoice
{
   
    [Key]
    [Column("Debit_ID")]
    [MaxLength(50, ErrorMessage = "Loi")]
    public string DebitId { get; set; } = null!;

    [Column("Invoice_type")]
    [MaxLength(10)]
    public string InvoiceType { get; set; } = null!;

    [Column("Debit_date")]
    [Display(Name = "Debit Date")]
 
    public DateTime? DebitDate { get; set; } = DateTime.Now;

    [Column("Payment_date")]
    [Display(Name = "Payment Date")]


    public DateTime? PaymentDate { get; set; }

    [Column("Invoice_No")]
    [MaxLength(20)]
    [Display(Name = "Invoice No")]


    public string? InvoiceNo { get; set; }

    [Column("Invoice_date")]
    [Display(Name = "Invoice Date")]

    public DateTime? InvoiceDate { get; set; }

    [Column("Supplier_ID")]
    [MaxLength(50)]
    [Display(Name = "Supplier ID")]
    public string? SupplierId { get; set; }

    [Column("HBL")]
    [MaxLength(50)]
    [Display(Name = "HBL")]
    public string? Hbl { get; set; }

    [ForeignKey("HBL")]
    public virtual TblHbl? HblNavigation { get; set; }

    [ForeignKey("SupplierId")]
    public virtual TblSupplier? Supplier { get; set; }


    public virtual ICollection<TblCharge> TblCharges { get; set; } = new List<TblCharge>();
}
