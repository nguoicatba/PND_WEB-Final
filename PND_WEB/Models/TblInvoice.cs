using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblInvoice
{
    [Key]
    public string DebitId { get; set; } = null!;

    public string InvoiceType { get; set; } = null!;

    public DateTime? DebitDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? InvoiceNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? SupplierId { get; set; }

    public string? Hbl { get; set; }

    public virtual TblHbl? HblNavigation { get; set; }

    public virtual TblSupplier? Supplier { get; set; }

    public virtual ICollection<TblCharge> TblCharges { get; set; } = new List<TblCharge>();
}
