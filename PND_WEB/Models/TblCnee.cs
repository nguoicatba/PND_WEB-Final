using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblCnee
{
    [Key]
    public string Cnee { get; set; } = null!;

    public string? Vcnee { get; set; }

    public string? Caddress { get; set; }

    public string? Vaddress { get; set; }

    public string? Ccity { get; set; }

    public string? CpersonInCharge { get; set; }

    public string? TaxId { get; set; }

    public string? Haddress { get; set; }

    public virtual ICollection<TblCneeAdd> TblCneeAdds { get; set; } = new List<TblCneeAdd>();

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
