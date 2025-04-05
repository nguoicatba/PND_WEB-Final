using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Mode
{
    [Key]
    public string Code { get; set; } = null!;

    public string? Note { get; set; }
}
