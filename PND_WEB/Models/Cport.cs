using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("CPORT")]
public partial class Cport
{
    [Key]
    [Column("CODE",TypeName ="nvarchar")]
    [MaxLength(20)]
    public string Code { get; set; } = null!;

    [Column("PORT_NAME")]
    public string? PortName { get; set; }
}
