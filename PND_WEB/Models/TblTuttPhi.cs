using System;
using System.Collections.Generic;

namespace PND_WEB.Models;

public partial class TblTuttPhi
{
    public int Id { get; set; }

    public string? SoHoaDon { get; set; }

    public string? TenPhi { get; set; }

    public bool? Tu { get; set; }

    public bool? Tt { get; set; }

    public double? SoTien { get; set; }

    public string? NghiChu { get; set; }

    public string? SoTutt { get; set; }

    public virtual TblTutt? SoTuttNavigation { get; set; }
}
