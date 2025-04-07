using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("CARRIER")]
public partial class Carrier
{
    [Key]
    [Column("CODE")]
    [MaxLength(20)]
    public string Code { get; set; } = null!;

    [Column("Carrier_name"),DisplayName("Carrier Name")]
    [MaxLength(255)]
    public string? CarrierName { get; set; }

    [Column("Carrier_namekd")]
    [MaxLength(255)]
    public string? CarrierNamekd { get; set; }

    [Column("Carier_add"),DisplayName("Carrier Address")] 
    [MaxLength(255)]
    public string? CarierAdd { get; set; }

    [Column("Note")]
    public string? Note { get; set; }

    public virtual ICollection<CarrierAction> CarrierActions { get; set; } = new List<CarrierAction>();

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();
}
