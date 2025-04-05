using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblShipper
{
    [Key]
    public string Shipper { get; set; } = null!;

    public string? Saddress { get; set; }

    public string? Scity { get; set; }

    public string? SpersonInCharge { get; set; }

    public string? TaxId { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
