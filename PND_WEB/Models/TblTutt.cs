using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_TUTT")] // Bảng Tạm Ứng Thanh Toán
public partial class TblTutt
{
    [Key]
    [Column("SoTUTT")]
    [MaxLength(50)]
    [DisplayName("Số Đơn")]
    public string SoTutt { get; set; } = null!;

    [Column("Ngay")]
    [DisplayName("Ngày tạo")]
    public DateTime? Ngay { get; set; }

    [Column("NhanvienTUTT")]
    [MaxLength(100)]
    [DisplayName("Nhân viên thực hiện")]
    public string? NhanvienTutt { get; set; }

    [Column("Noi_dung")]
    [MaxLength(255)]
    [DisplayName("Nội dung")]
    public string? NoiDung { get; set; }

    [Column("xacnhanduyet")]
    [DisplayName("Xác nhận duyệt")]
    public bool? xacnhanduyet { get; set; }

    [Column("ketoan")]
    [DisplayName("Kế toán")]
    public bool? Ketoan { get; set; }

    [Column("ceo")]
    [DisplayName("CEO")]
    public bool? Ceo { get; set; }

    [Column("TU")]
    [DisplayName("Tạm ứng")]
    public bool? Tu { get; set; } = false;

    [Column("TT")]
    [DisplayName("Thanh toán")]
    public bool? Tt { get; set; } = false;


    [Column("Ghi_chu")]
    [MaxLength(255)]
    [DisplayName("Ghi chú")]
    public string? GhiChu { get; set; }

  
    public virtual ICollection<TblTuttPhi> TblTuttPhis { get; set; } = new List<TblTuttPhi>();
}
