using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_SUPPLIER")]
public partial class TblSupplier
{
    [Key]
    [Column("Supplier_ID")]
    [MaxLength(50)]
    public string SupplierId { get; set; } = null!;

    [Column("Name_sup")]
    [MaxLength(255)]
    public string? NameSup { get; set; }

    [Column("Typer")]
    [MaxLength(20)]
    public string? Typer { get; set; }

    [Column("Address_sup")]
    [MaxLength(255)]
    public string? AddressSup { get; set; }

    [Column("LCC_Fee")]
    [MaxLength(255)]
    public string? LccFee { get; set; }

    [Column("Note")]
    [MaxLength(255)]
    public string? Note { get; set; }

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblSupplierAction> TblSupplierActions { get; set; } = new List<TblSupplierAction>();
}
