using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PND_WEB.Models;

public partial class InvoiceType
{
    [Key]
    public string Code { get; set; } = null!;

    public string? NameType { get; set; }
}
