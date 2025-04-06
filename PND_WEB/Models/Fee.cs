using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("FEE")]
public partial class Fee
{
    [Key,Required(ErrorMessage ="Mã phí không được để trống")]
    [MaxLength(255)]
    public string Code { get; set; } = null!;

    [Column("FEE")]
    [MaxLength(255)]
    [DisplayName("Phí")]
    public string? Fee1 { get; set; }

    [Column("UNIT")]
    [MaxLength(255)]
    public string? Unit { get; set; }

    [Column("NOTE")]
    [MaxLength(255)]
    public string? Note { get; set; }
}
