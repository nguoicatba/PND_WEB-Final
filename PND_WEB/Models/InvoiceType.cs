using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PND_WEB.Models;

[Table("INVOICE_TYPE")]
public partial class InvoiceType
{
    [Key]
    [Column("Code", TypeName = "nvarchar")]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    [Column("Name_type")]
    [MaxLength(255)]
    public string? NameType { get; set; }
}
