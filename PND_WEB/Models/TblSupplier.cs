using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PND_WEB.Models;

public partial class TblSupplier
{
    [Key]
    public string SupplierId { get; set; } = null!;

    public string? NameSup { get; set; }

    public string? Typer { get; set; }

    public string? AddressSup { get; set; }

    public string? LccFee { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblSupplierAction> TblSupplierActions { get; set; } = new List<TblSupplierAction>();
}
