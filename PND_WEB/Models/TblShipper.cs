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

    public string ShipperName { get; set; }

    [Column("SAddress")]
    [MaxLength(1000)]
    [Display(Name = "Shipper Address")]
    public string? Saddress { get; set; }

    [Column("SCity")]
    [MaxLength(100)]
    [Display(Name = "Shipper City")]
    public string? Scity { get; set; }

    [Column("SPerson_in_charge")]
    [MaxLength(255)]
    [Display(Name = "Shipper PIC")]
    public string? SpersonInCharge { get; set; }

    [Column("TaxID")]
    [MaxLength(20)]
    [Display(Name = "Tax ID")]
    public string? TaxId { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
