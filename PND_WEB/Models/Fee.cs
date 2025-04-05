using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Fee
{
    [Key]
    public string Code { get; set; } = null!;

    public string? Fee1 { get; set; }

    public string? Unit { get; set; }

    public string? Note { get; set; }
}
