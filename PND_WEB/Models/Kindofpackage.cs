using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Kindofpackage
{
    [Key]
    public string Code { get; set; } = null!;

    public string? PackageName { get; set; }

    public string? PackagesDescription { get; set; }
}
