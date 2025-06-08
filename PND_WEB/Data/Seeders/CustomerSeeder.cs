using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data.Seeders
{
    public class CustomerSeeder
    {
        public static async Task SeedAsync(DataContext _context)
        {
            if (!await _context.TblCustomers.AnyAsync())
            {
                await _context.TblCustomers.AddRangeAsync(

                   
                    new TblCustomer { CustomerId = "0108111428", CompanyName = "HAI AN FREIGHT FORWARDING JOINT STOCK COMPANY", ComAddress = "Văn phòng 3B, Tầng 3, Tòa B, Tòa nhà Green Pearl số 378 Minh Khai", Website = "http://www.haian.com.vn", DutyPerson = "Nguyễn Văn A", Contact = "0987546897", Email = "" },
                    new TblCustomer { CustomerId = "132132", CompanyName = "DONASCO Logistics - Công Ty TNHH DONASCO", ComAddress = "Văn phòng 3B, Tầng 3, Tòa B, Tòa nhà Green Pearl số 378 Minh Khai", Website = "http://www.haian.com.vn", DutyPerson = "Nguyễn Văn A", Contact = "0987541297", Email = "" },
              
                    new TblCustomer 
                    { 
                        CustomerId = "XTH2015", 
                        CompanyName = "CÔNG TY CỔ PHẦN VẬN TẢI VÀ THƯƠNG MẠI XUÂN TRƯỜNG HẢI", 
                        ComAddress = "số 783 Nguyễn Bỉnh Khiêm, phường Đông Hải 1, Quận Hải An, TP.Hải Phòng", 
                        Website = "xuantruonghai.com.vn", 
                        DutyPerson = "Nguyen Van A",
                        Contact = "02253.260.875", 
                        Email = "info@xuantruonghai.com.vn" 
                    },
                    new TblCustomer 
                    { 
                        CustomerId = "TTL2023", 
                        CompanyName = "CÔNG TY TNHH GIAO NHẬN QUỐC TẾ TRƯỜNG THÀNH", 
                        ComAddress = "Phòng 11A, tòa TTC, số 630 Đường Lê Thánh Tông, quận Hai An, TP. Hải Phòng", 
                        Website = "truongthanhlogistics.com", 
                        DutyPerson = "Nguyen Van A",
                        Contact = "0915.36.38.39", 
                        Email = "info@truongthanhlogistics.com" 
                    },
                    new TblCustomer 
                    { 
                        CustomerId = "N2WAY2024", 
                        CompanyName = "N2WAY LOGISTICS", 
                        ComAddress = "Số 275 Lạch Tray, Phường Đằng Giang, Quận Ngô Quyền, TP. Hải Phòng", 
                        Website = "www.vn2way.com", 
                        DutyPerson = "Nguyen Van A", 
                        Contact = "0986490384", 
                        Email = "info@vn2way.com" 
                    }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
} 