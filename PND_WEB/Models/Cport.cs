using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Cport
{
    [Key]
    public string Code { get; set; } = null!;

    public string? PortName { get; set; }
}
