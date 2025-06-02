using System.Collections.Generic;

namespace PND_WEB.ViewModels
{
    public class BaoCaoThongKeViewModel
    {
        public int Nam { get; set; }
        public string Thang { get; set; }
        public List<ThongKeBookingViewModel> ThongKeTheoThang { get; set; } = new();
        public List<ThongKeNguoiDungTheoThangViewModel> ThongKeNguoiDungTheoThang { get; set; } = new();
    }

    public class ThongKeBookingViewModel
    {
        public string Thang { get; set; }
        public int SoLuongBooking { get; set; }
    }

    public class ThongKeNguoiDungTheoThangViewModel
    {
        public string StaffName { get; set; }
        public string Thang { get; set; }
        public int SoLuongBooking { get; set; }
    }
}