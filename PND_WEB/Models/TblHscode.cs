using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_HSCODE")]
public partial class TblHscode
{
    [Key]
    [Column("ID")]
    [DisplayName("ID")]
    public int Id { get; set; }

    [MaxLength(20, ErrorMessage = "Độ dài HS code tối đa 20")]
    [Column("HS_CODE")]
    [DisplayName("Mã HS Code")]
    public string? HsCode { get; set; }

    [Column("Mo_ta_hang_hoaV")]
    [DisplayName("Mô tả hàng hóa (VI)")]
    public string? MoTaHangHoaV { get; set; }

    [Column("Mo_ta_hang_hoaE")]
    [DisplayName("Mô tả hàng hóa (EN)")]
    public string? MoTaHangHoaE { get; set; }

    [MaxLength(50)]
    [Column("Don_vi_tinh")]
    [DisplayName("Đơn vị tính")]
    public string? DonViTinh { get; set; }

    [Column("Thue_NK_TT")]
    [DisplayName("Thuế NK TT")]
    public double? ThueNkTt { get; set; } = 0;

    [Column("Thue_NK_UD")]
    [DisplayName("Thuế NK UD")]
    public double? ThueNkUd { get; set; } = 0;

    [Column("Thue_VAT")]
    [MaxLength(100)]
    [DisplayName("Thuế VAT")]
    public string? ThueVat { get; set; }

    public double? Acfta { get; set; } = 0;
    public double? Atiga { get; set; } = 0;
    public double? Ajcep { get; set; } = 0;
    public double? Vjepa { get; set; } = 0;
    public double? Akfta { get; set; } = 0;
    public double? Aanzfta { get; set; } = 0;
    public double? Aifta { get; set; } = 0;
    public double? Vkfta { get; set; } = 0;
    public double? Vcfta { get; set; } = 0;
    [Column("VN_EAEU")]
    [DisplayName("VN EAEU")]
    public double? VnEaeu { get; set; } = 0;
    public double? Cptpp { get; set; } = 0;
    public double? Ahkfta { get; set; } = 0;
    public double? Vncu { get; set; } = 0;
    public double? Evfta { get; set; } = 0;
    public double? Ukvfta { get; set; } = 0;
    [Column("VN_LAO")]
    [DisplayName("VN LAO")]
    public double? VnLao { get; set; } = 0;
    [Column("RCEPT_A")]
    public double? RceptA { get; set; } = 0;
    [Column("RCEPT_B")]
    public double? RceptB { get; set; } = 0;
    [Column("RCEPT_C")]
    public double? RceptC { get; set; } = 0;
    [Column("RCEPT_D")]
    public double? RceptD { get; set; } = 0;
    [Column("RCEPT_E")]
    public double? RceptE { get; set; } = 0;
    [Column("RCEPT_F")]
    public double? RceptF { get; set; } = 0;

    public double? Ttdb { get; set; } = 0;
    public double? Xk { get; set; } = 0;
    public double? Xkcptpp { get; set; } = 0;
    public double? Xkev { get; set; } = 0;
    public double? Xkukv { get; set; } = 0;

    [MaxLength(100)]
    [Column("Thue_BVMT")]
    [DisplayName("Thuế BVMT")]
    public string? ThueBvmt { get; set; }

    [MaxLength(1000)]
    [Column("Chinh_sach_hang_hoa")]
    [DisplayName("Chính sách hàng hóa")]
    public string? ChinhSachHangHoa { get; set; }

    [MaxLength(50)]
    [Column("Giam_VAT")]
    [DisplayName("Giảm VAT")]
    public string? GiamVat { get; set; }

    [MaxLength(500)]
    [Column("Chi_tiet_giam_VAT")]
    [DisplayName("Chi tiết giảm VAT")]
    public string? ChiTietGiamVat { get; set; }

    [Column("Mo_ta_khong_dau")]
    public string? MoTaKhongDau { get; set; }

    [Column("Ghi_chu")]
    [DisplayName("Ghi chú")]
    public string? GhiChu { get; set; }

    [Column("Ghi_chu_khong_dau")]
    public string? GhiChuKhongDau { get; set; }
}
