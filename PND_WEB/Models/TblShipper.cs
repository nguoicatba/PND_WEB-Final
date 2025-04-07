using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_SHIPPER")]
public partial class TblShipper
{
    [Key]
    [Column("Shipper")]
    [MaxLength(255)]
    public string Shipper { get; set; } = null!;

    [Column("SAddress")]
    [MaxLength(1000)]
    public string? Saddress { get; set; }

    [Column("SCity")]
    [MaxLength(100)]
    public string? Scity { get; set; }

    [Column("SPerson_in_charge")]
    [MaxLength(255)]
    public string? SpersonInCharge { get; set; }

    [Column("TaxID")]
    [MaxLength(20)]
    public string? TaxId { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
