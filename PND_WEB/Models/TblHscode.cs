using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblHscode
{
    [Key]
    public int Id { get; set; }

    [MaxLength(20,ErrorMessage ="Độ dài HS code tối đa 20")]
    public string? HsCode { get; set; }
    
    public string? MoTaHangHoaV { get; set; }

    public string? MoTaHangHoaE { get; set; }

    public string? DonViTinh { get; set; }

    public double? ThueNkTt { get; set; }

    public double? ThueNkUd { get; set; }

    public string? ThueVat { get; set; }

    public double? Acfta { get; set; }

    public double? Atiga { get; set; }

    public double? Ajcep { get; set; }

    public double? Vjepa { get; set; }

    public double? Akfta { get; set; }

    public double? Aanzfta { get; set; }

    public double? Aifta { get; set; }

    public double? Vkfta { get; set; }

    public double? Vcfta { get; set; }

    public double? VnEaeu { get; set; }

    public double? Cptpp { get; set; }

    public double? Ahkfta { get; set; }

    public double? Vncu { get; set; }

    public double? Evfta { get; set; }

    public double? Ukvfta { get; set; }

    public double? VnLao { get; set; }

    public double? RceptA { get; set; }

    public double? RceptB { get; set; }

    public double? RceptC { get; set; }

    public double? RceptD { get; set; }

    public double? RceptE { get; set; }

    public double? RceptF { get; set; }

    public double? Ttdb { get; set; }

    public double? Xk { get; set; }

    public double? Xkcptpp { get; set; }

    public double? Xkev { get; set; }

    public double? Xkukv { get; set; }

    public string? ThueBvmt { get; set; }

    public string? ChinhSachHangHoa { get; set; }

    public string? GiamVat { get; set; }

    public string? ChiTietGiamVat { get; set; }

    public string? MoTaKhongDau { get; set; }

    public string? GhiChu { get; set; }

    public string? GhiChuKhongDau { get; set; }
}
