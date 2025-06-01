using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class QuotationsCharge
{
    [Key]
    public int ChargeId { get; set; }

    public string? QuotationId { get; set; }

    [Display(Name = "Tên phí")]
    public string? ChargeName { get; set; }

    [Display(Name = "Số lượng")]
    public double? Quantity { get; set; }

    [Display(Name = "Đơn vị")]
    public string? Unit { get; set; }

    [Display(Name = "Giá")]
    public double? Rate { get; set; }

    [Display(Name = "Tiền tệ")]
    public string? Currency { get; set; }

    [Display(Name = "Ghi chú")]
    public string? Notes { get; set; }

    public virtual Quotation? Quotation { get; set; }
}
