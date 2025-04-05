using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Sourse
{
    [Key]
    public string Code { get; set; } = null!;

    public string? SourName { get; set; }

    public string? Note { get; set; }
}
