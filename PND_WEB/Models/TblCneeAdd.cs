using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_CNEE_ADD")]
public partial class TblCneeAdd
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Adds")]
    [MaxLength(500)]
    public string? Adds { get; set; }

    [Column("Place")]
    [MaxLength(255)]
    public string? Place { get; set; }

    [Column("PersonInCharge")]
    [MaxLength(255)]
    public string? PersonInCharge { get; set; }

    [Column("CNEE")]
    [MaxLength(255)]
    public string? Cnee { get; set; }

    [ForeignKey("Cnee")]
    public virtual TblCnee? CneeNavigation { get; set; }
}
