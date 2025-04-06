using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Unit
{
    [Key]
    [DisplayName("Unit Code")]
    [MaxLength(20)]
    public string Code { get; set; } = null!;

    [DisplayName("Unit Name")]
    [MaxLength(255)]
    public string? UnitName { get; set; }

    [DisplayName("Note")]
    [MaxLength(255)]
    public string? Note { get; set; }
}
