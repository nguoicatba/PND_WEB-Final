using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data.Seeders
{
    public class CarrierSeeder
    {
        public static async Task SeedAsync(DataContext _context)
        {
            if (!await _context.Carriers.AnyAsync())
            {
              await   _context.Carriers.AddRangeAsync(
                 new Carrier { Code = "ACL", CarrierName = "ADVANCE CONTAINER LINES (PTE) LTD", CarrierNamekd = "advance container lines", CarierAdd = "", Note = "" },
                 new Carrier { Code = "ACS", CarrierName = "ANCHORAGE SHIPPING PTE LTD", CarrierNamekd = "anchorage shipping", CarierAdd = "", Note = "" },
                 new Carrier { Code = "AEL", CarrierName = "Công ty Cổ phần A.E.L Việt Nam", CarrierNamekd = "ael viet nam", CarierAdd = "P415 TD Business Center - Lê 20 Lê Hồng Phong, Ngô Quyền, Hải Phòng", Note = "" },
                 new Carrier { Code = "AGL", CarrierName = "ATLAS GLOBAL CO.,LTD", CarrierNamekd = "atlas global", CarierAdd = "10th Floor, PDD Building, 162 Pasteur Street", Note = "" },
                 new Carrier { Code = "AMS", CarrierName = "Công ty Container AMASIS SHIPPING SGN BHD, MALAYSIA", CarrierNamekd = "amasis shipping", CarierAdd = "", Note = "" },
                 new Carrier { Code = "ANL", CarrierName = "ANL Singapore Pte Ltd", CarrierNamekd = "anl singapore", CarierAdd = "", Note = "" },
                 new Carrier { Code = "ANU", CarrierName = "ANL UNISON", CarrierNamekd = "anl unison", CarierAdd = "", Note = "" },
                 new Carrier { Code = "APH", CarrierName = "Công ty TNHH An Phong Logistics", CarrierNamekd = "an phong logistics", CarierAdd = "Số 4B/6 P1 Đà Nẵng, Máy Tơ, Ngô Quyền, Hải Phòng", Note = "" },
                 new Carrier { Code = "APL", CarrierName = "Chi nhánh Công ty APL Việt Nam tại Hải Phòng", CarrierNamekd = "apl viet nam hai phong", CarierAdd = "27C Điện Biên Phủ, Hải Phòng", Note = "" },
                 new Carrier { Code = "APN", CarrierName = "Công ty TNHH APL - NOL Việt Nam", CarrierNamekd = "apl nol viet nam", CarierAdd = "17 Bà Huyện Thanh Quan, P6, Q3, TP Hồ Chí Minh", Note = "" },
                 new Carrier { Code = "BHL", CarrierName = "Bulkhaul", CarrierNamekd = "bulkhaul", CarierAdd = "", Note = "" },
                 new Carrier { Code = "BIS", CarrierName = "Công ty TNHH Một thành viên Vận tải Biển Đông", CarrierNamekd = "van tai bien dong", CarierAdd = "Số 1 Thuy Khuê, Phường Thụy Khuê, Quận Tây Hồ, Hà Nội", Note = "" },
                 new Carrier { Code = "BLP", CarrierName = "BLPL Logistics Singapore Pte Ltd", CarrierNamekd = "blpl logistics", CarierAdd = "", Note = "" },
                 new Carrier { Code = "BSL", CarrierName = "Balaji Shipping Lines FZCO", CarrierNamekd = "balaji shipping", CarierAdd = "", Note = "" },
                 new Carrier { Code = "CANONVNCTHN", CarrierName = "Công ty TNHH CANON Việt Nam", CarrierNamekd = "canon viet nam", CarierAdd = "Lô A1, KCN Thăng Long, Đông Anh, Hà Nội", Note = "" }
             );
                await _context.SaveChangesAsync();
            }




        }
    }
}
