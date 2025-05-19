using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_CNEE")]
public partial class TblCnee
{
    [Key]
    [Column("CNEE")]
    [MaxLength(255)]
    public string Cnee { get; set; } = null!;

    [Column("VCNEE")]
    [MaxLength(255)]
    public string? Vcnee { get; set; }

    [Column("CAddress")]
    [MaxLength(1000)]
    [Display(Name = "Address")]
    public string? Caddress { get; set; }

    [Column("VAddress")]
    [MaxLength(1000)]
    public string? Vaddress { get; set; }

    [Column("CCity")]
    [MaxLength(100)]
    [Display(Name = "City")]
    public string? Ccity { get; set; }

    [Column("CPerson_in_charge")]
    [MaxLength(255)]
    [Display(Name = "PIC")]
    public string? CpersonInCharge { get; set; }

    [Column("TaxID")]
    [MaxLength(20)]
    [Display(Name = "Tax ID")]
    public string? TaxId { get; set; }

    [Column("HAddress")]
    [MaxLength(1000)]
    [Display(Name = "Home Address")]
    public string? Haddress { get; set; }

    public virtual ICollection<TblCneeAdd> TblCneeAdds { get; set; } = new List<TblCneeAdd>();

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
