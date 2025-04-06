using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("UNIT")]
public partial class Unit
{
    [Key]
    [Column("CODE", TypeName = "nvarchar")]
    [DisplayName("Unit Code")]
    [MaxLength(20)]
    public string Code { get; set; } = null!;

    [DisplayName("Unit Name")]
    [MaxLength(255)]
    [Column("Unit_name")]
    public string? UnitName { get; set; }

    [DisplayName("Note")]
    [MaxLength(255)]
    [Column("Note")]
    public string? Note { get; set; }
}
