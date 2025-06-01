using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Quotation
{
    [Key]
    [Display(Name = "Mã báo giá")]
    public string QuotationId { get; set; } = null!;

    [Display(Name = "Trạng thái")]
    public string? Qsatus { get; set; }

    [Display(Name = "Nhân viên")]
    public string? StaffName { get; set; }

    [Display(Name = "Liên lạc nhân viên")]
    public string? Contact { get; set; }

    [Display(Name = "Ngày tạo")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Qdate { get; set; }

    [Display(Name = "Khách hàng")]
    public string? CusTo { get; set; }

    [Display(Name = "Liên hệ khách hàng")]
    public string? CusContact { get; set; }

    [Display(Name = "Hiệu lực")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Valid { get; set; }

    [Display(Name = "Điều khoản")]
    public string? Term { get; set; }

    [Display(Name = "Khối lượng")]
    public string? Vol { get; set; }

    [Display(Name = "Hàng hóa")]
    public string? Commodity { get; set; }

    [Display(Name = "Điểm đi (POL)")]
    public string? Pol { get; set; }

    [Display(Name = "Địa chỉ")]
    public string? Adds { get; set; }

    [Display(Name = "Điểm đến (POD)")]
    public string? Pod { get; set; }

    public virtual ICollection<QuotationsCharge> QuotationsCharges { get; set; } = new List<QuotationsCharge>();
}
