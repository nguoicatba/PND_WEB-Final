using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Currency
{
    [Key]
    public string Code { get; set; } = null!;

    public string? CurrName { get; set; }

    public string? Note { get; set; }
}
