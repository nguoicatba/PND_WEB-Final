using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblTutt
{
    [Key]
    [DisplayName("Số Đơn")]   
    public string SoTutt { get; set; } = null!;
    [DisplayName("Ngày tạo")]
    public DateTime? Ngay { get; set; }
    [DisplayName("Nhân viên thực hiện")]
    public string? NhanvienTutt { get; set; }
    [DisplayName("Nội dung")]
    public string? NoiDung { get; set; }

    public bool? xacnhanduyet { get; set; }
    [DisplayName("Kế toán xác nhận")]
    public bool? Ketoan { get; set; }
    [DisplayName("Ceo xác nhận")]
    public bool? Ceo { get; set; }
    [DisplayName("Ghi chú")]
    public string? GhiChu { get; set; }

    public virtual ICollection<TblTuttPhi> TblTuttPhis { get; set; } = new List<TblTuttPhi>();
}
