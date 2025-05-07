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
    [Display(Name = "Supplier ID")]
    public string SupplierId { get; set; } = null!;

    [Column("Name_sup")]
    [MaxLength(255)]
    [Display(Name = "Supplier Name")]
    public string? NameSup { get; set; }

    [Column("Typer")]
    [MaxLength(20)]
    [Display(Name = "Supplier Type")]
    public string? Typer { get; set; }

    [Column("Address_sup")]
    [MaxLength(255)]
    [Display(Name = "Address")]
    public string? AddressSup { get; set; }

    [Column("LCC_Fee")]
    [MaxLength(255)]
    [Display(Name = "LCC Fee")]
    public string? LccFee { get; set; }

    [Column("Note")]
    [MaxLength(255)]
    [Display(Name = "Note")]
    public string? Note { get; set; }
    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblSupplierAction> TblSupplierActions { get; set; } = new List<TblSupplierAction>();
}
