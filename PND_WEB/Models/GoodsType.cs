using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class GoodsType
{
    [Key]
    public string Code { get; set; } = null!;

    public string? GtName { get; set; }

    public string? Note { get; set; }
}
