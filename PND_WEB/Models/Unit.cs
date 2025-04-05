using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Unit
{
    [Key]
    public string Code { get; set; } = null!;

    public string? UnitName { get; set; }

    public string? Note { get; set; }
}
