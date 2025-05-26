using System;
using System.Collections.Generic;

namespace PND_WEB.ViewModels
{
    public class BaoCaoThongKeViewModel
    {
        public int Nam { get; set; }
        public List<ThongKeQuotationViewModel> ThongKeTheoThang { get; set; } = new List<ThongKeQuotationViewModel>();
    }

    public class ThongKeQuotationViewModel
    {
        public string Thang { get; set; }
        public int SoLuongQuotation { get; set; }
    }
}