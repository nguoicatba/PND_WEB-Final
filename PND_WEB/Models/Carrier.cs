using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Carrier
{
    [Key]
    public string Code { get; set; } = null!;

    public string? CarrierName { get; set; }

    public string? CarrierNamekd { get; set; }

    public string? CarierAdd { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<CarrierAction> CarrierActions { get; set; } = new List<CarrierAction>();

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();
}
