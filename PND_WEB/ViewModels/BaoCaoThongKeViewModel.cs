using System.Collections.Generic;

namespace PND_WEB.ViewModels
{
    public class BaoCaoThongKeViewModel
    {
        public int Nam { get; set; }
        public List<ThongKeQuotationViewModel> ThongKeTheoThang { get; set; } = new();
        public List<ThongKeNguoiDungViewModel> ThongKeTheoNguoiDung { get; set; } = new();
    }

    public class ThongKeQuotationViewModel
    {
        public string Thang { get; set; }
        public int SoLuongQuotation { get; set; }
    }

    public class ThongKeNguoiDungViewModel
    {
        public string StaffName { get; set; }
        public int SoLuongQuotation { get; set; }
    }
}