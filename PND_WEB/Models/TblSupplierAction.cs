using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_SUPPLIER_ACTION")]
public partial class TblSupplierAction
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Supplier_ID")]
    [MaxLength(50)]
    public string? SupplierId { get; set; }

    [Column("Person_in_charge")]
    [MaxLength(255)]
    public string? PersonInCharge { get; set; }

    [Column("Phone_number")]
    [MaxLength(30)]
    public string? PhoneNumber { get; set; }

    [Column("Email")]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Column("Note")]
    public string? Note { get; set; }

    [ForeignKey("SupplierId")]
    public virtual TblSupplier? Supplier { get; set; }
}
