using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public class QuotationSequence
{
    public int Id { get; set; } // Id tự động tăng
    public string Prefix { get; set; } // Tiền tố mã (Ví dụ: "QTN202504")
    public int LastNumber { get; set; } // Số thứ tự cuối cùng đã sử dụng
    public DateTime LastUpdated { get; set; } // Thời gian cập nhật cuối cùng
}