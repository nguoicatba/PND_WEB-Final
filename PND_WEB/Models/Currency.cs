using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("CURRENCY")]
public partial class Currency
{
    [Key]
    [Column("CODE", TypeName = "nvarchar")]
    [MaxLength(20, ErrorMessage = "Độ dài không được quá 20")]
    public string Code { get; set; } = null!;

    [Column("Curr_name")]
    [MaxLength(255)]
    public string? CurrName { get; set; }

    [Column("Note")]
    [MaxLength(255)]
    public string? Note { get; set; }
}
