using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data.Seeders;
using PND_WEB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PND_WEB.Data
{
    public class SeedingData
    {
        public static async Task SeedData(DataContext _context, RoleManager<IdentityRole> roleManager)
        {
            await _context.Database.MigrateAsync();
            // Claims
            await ClaimSeeder.SeedAsync(_context);

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("CEO"))
            {
                await roleManager.CreateAsync(new IdentityRole("CEO"));
            }
            if (!await roleManager.RoleExistsAsync("Docs"))
            {
                await roleManager.CreateAsync(new IdentityRole("Docs"));
            }
            if (!await roleManager.RoleExistsAsync("Sale"))
            {
                await roleManager.CreateAsync(new IdentityRole("Sale"));
            }
            if (!await roleManager.RoleExistsAsync("Log"))
            {
                await roleManager.CreateAsync(new IdentityRole("Logistic"));
            }
            if (!await roleManager.RoleExistsAsync("Accountant"))
            {
                await roleManager.CreateAsync(new IdentityRole("Accountant"));
            }

            // Seeding Sourses
            if (!await _context.Sourses.AnyAsync())
            {
                await _context.Sourses.AddRangeAsync(
                    new Sourse { Code = "FREEHAND", SourName = "FREEHAND", Note = "" },
                    new Sourse { Code = "NOMI", SourName = "NOMI", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Currencies
            if (!await _context.Currencies.AnyAsync())
            {
                await _context.Currencies.AddRangeAsync(
                    new Currency { Code = "USD", CurrName = "dollar Mỹ", Note = "Dollar" },
                    new Currency { Code = "EUR", CurrName = "Euro", Note = "Euro" },
                    new Currency { Code = "JPY", CurrName = "Yên nhật", Note = "Yen" },
                    new Currency { Code = "VND", CurrName = "Việt nam đồng", Note = "VND" },
                    new Currency { Code = "CNY", CurrName = "Nhân dân tệ", Note = "CNY" },
                    new Currency { Code = "GBP", CurrName = "Bảng Anh", Note = "Pound" },
                    new Currency { Code = "AUD", CurrName = "Đô la Úc", Note = "AUD" },
                    new Currency { Code = "CAD", CurrName = "Đô la Canada", Note = "CAD" }
                );
                await _context.SaveChangesAsync();
            }
          
            // Seeding Ports
            if (!await _context.Cports.AnyAsync())
            {
                await _context.Cports.AddRangeAsync(
                    new Cport { Code = "VNATH", PortName = "CANG AN THOI" },
                    new Cport { Code = "VNBAI", PortName = "CUA KHAU BAC DAI" },
                    new Cport { Code = "VNBAN", PortName = "CANG BA NGOI (K.HOA)" },
                    new Cport { Code = "VNBDA", PortName = "DONG TAU BACH DANG" },
                    new Cport { Code = "VNBDC", PortName = "CANG BINH DUC (LA)" },
                    new Cport { Code = "VNBDM", PortName = "CANG BEN DAM (VT)" },
                    new Cport { Code = "VNBDU", PortName = "CANG TONG HOP BDUONG" },
                    new Cport { Code = "VNBLG", PortName = "CANG BINH LONG" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding BLTypes
            if (!await _context.BlTypes.AnyAsync())
            {
                await _context.BlTypes.AddRangeAsync(
                    new BlType { Code = "Copy", BlName = "", Note = "" },
                    new BlType { Code = "Original", BlName = "", Note = "" },
                    new BlType { Code = "Draft", BlName = "", Note = "" },
                    new BlType { Code = "SEWAY BILL", BlName = "", Note = "" },
                    new BlType { Code = "SURRENDERED", BlName = "", Note = "" },
                    new BlType { Code = "TELEX", BlName = "", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Units
            if (!await _context.Units.AnyAsync())
            {
                await _context.Units.AddRangeAsync(
                    new Unit { Code = "20`DC", UnitName = "", Note = "" },
                    new Unit { Code = "20`GP", UnitName = "", Note = "" },
                    new Unit { Code = "20`OT", UnitName = "", Note = "" },
                    new Unit { Code = "20`RF", UnitName = "", Note = "" },
                    new Unit { Code = "40`GP", UnitName = "", Note = "" },
                    new Unit { Code = "40`DC", UnitName = "", Note = "" },
                    new Unit { Code = "40`HC", UnitName = "", Note = "" },
                    new Unit { Code = "40`OT", UnitName = "", Note = "" },
                    new Unit { Code = "40`FR", UnitName = "", Note = "" },
                    new Unit { Code = "CBM", UnitName = "", Note = "" },
                    new Unit { Code = "OT", UnitName = "", Note = "" },
                    new Unit { Code = "SHIPMENT", UnitName = "", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding GoodsTypes
            if (!await _context.GoodsTypes.AnyAsync())
            {
                await _context.GoodsTypes.AddRangeAsync(
                    new GoodsType { Code = "AI", GtName = "Air Import", Note = "hàng không nhập" },
                    new GoodsType { Code = "AE", GtName = "Air Export", Note = "hàng không xuất" },
                    new GoodsType { Code = "FCLI", GtName = "Full Container Load Import", Note = "hàng nhập nguyên công" },
                    new GoodsType { Code = "FCLE", GtName = "Full Container Load Export", Note = "hàng xuất nguyên công" },
                    new GoodsType { Code = "LCLI", GtName = "Less-than Container Load Import", Note = "hàng lẻ nhập" },
                    new GoodsType { Code = "LCLE", GtName = "Less-than Container Load Export", Note = "hàng lẻ xuất" },
                    new GoodsType { Code = "LGT", GtName = "Logistics", Note = "hàng làm thủ tục hải quan" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Modes
            if (!await _context.Modes.AnyAsync())
            {
                await _context.Modes.AddRangeAsync(
                    new Mode { Code = "AIR/AIR", Note = "" },
                    new Mode { Code = "CFS", Note = "" },
                    new Mode { Code = "CFS/CFS", Note = "" },
                    new Mode { Code = "CW", Note = "" },
                    new Mode { Code = "CY/CY", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Fees
            if (!await _context.Fees.AnyAsync())
            {
                await _context.Fees.AddRangeAsync(
                    new Fee { Code = "ACI", Fee1 = "Phí khai hải quan tự động", Unit = "SET", Note = "" },
                    new Fee { Code = "AFR FEE", Fee1 = "Phí khai hải quan", Unit = "SET", Note = "" },
                    new Fee { Code = "AFS FEE", Fee1 = "Phí khai sơ lược hàng hóa", Unit = "SET", Note = "" },
                    new Fee { Code = "AMENDMENT FEE", Fee1 = "Phí sửa vận đơn", Unit = "SET", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Customers
            if (!await _context.TblCustomers.AnyAsync())
            {
                await _context.TblCustomers.AddRangeAsync(
                    new TblCustomer { CustomerId = "0108111428", CompanyName = "HAI AN FREIGHT FORWARDING JOINT STOCK COMPANY", ComAddress = "Văn phòng 3B, Tầng 3, Tòa B, Tòa nhà Green Pearl số 378 Minh Khai", Website = "http://www.haian.com.vn", DutyPerson = "Nguyễn Văn A", Contact = "Nguyễn Văn B", Email = "" },
                    new TblCustomer { CustomerId = "132132", CompanyName = "DONASCO Logistics - Công Ty TNHH DONASCO", ComAddress = "Văn phòng 3B, Tầng 3, Tòa B, Tòa nhà Green Pearl số 378 Minh Khai", Website = "http://www.haian.com.vn", DutyPerson = "Nguyễn Văn A", Contact = "Nguyễn Văn B", Email = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Agents
            if (!await _context.Agents.AnyAsync())
            {
                await _context.Agents.AddRangeAsync(
                    new Agent { Code = "APM", AgentName = "APM - SAIGON SHIPPING CO.LTD", AgentAdd = "Lầu 7, Landmark Building, 5B Tôn Đức Thắng, Quận 1", Note = "" },
                    new Agent { Code = "Agent2", AgentName = "CNC, CONTSHIP, KIEN HUNG & VIETFRACHT", AgentAdd = "Lầu 1, Saigon Port Building, 3 Nguyễn Tất Thành, Quận 4", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding AgentActions
            if (!await _context.AgentActions.AnyAsync())
            {
                await _context.AgentActions.AddRangeAsync(
                    new AgentAction { Code = "Agent2", PersonInCharge = "Mr. Y.S.Chung", PhoneNumber = "8267446", Email = "", Note = "" },
                    new AgentAction { Code = "Agent2", PersonInCharge = "Mr. Tom Chung", PhoneNumber = "8267446", Email = "", Note = "" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Invoice Types
            if (!await _context.InvoiceTypes.AnyAsync())
            {
                await _context.InvoiceTypes.AddRangeAsync(
                    new InvoiceType { Code = "A", NameType = "Agent" },
                    new InvoiceType { Code = "C", NameType = "CNEE" },
                    new InvoiceType { Code = "S", NameType = "Shipper" },
                    new InvoiceType { Code = "O", NameType = "Others" },
                    new InvoiceType { Code = "V", NameType = "Vendor" }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Suppliers
            if (!await _context.TblSuppliers.AnyAsync())
            {
                await _context.TblSuppliers.AddRangeAsync(
                    new TblSupplier { SupplierId = "SUP001", NameSup = "Công ty TNHH ABC Logistics", Typer = "Local Charges", AddressSup = "123 Lê Lợi, Q1, HCM", LccFee = "Giao hàng nội địa", Note = "" },
                    new TblSupplier { SupplierId = "SUP002", NameSup = "CTCP Vận Tải Biển XYZ", Typer = "Shipping Line", AddressSup = "789 Trần Hưng Đạo, HN", LccFee = "Hỗ trợ thủ tục hải quan", Note = "" },
                    new TblSupplier { SupplierId = "SUP003", NameSup = "DNTN Kim Ngân Forwarder", Typer = "Handling Fee", AddressSup = "56 Nguyễn Huệ, Đà Nẵng", LccFee = "Giao hàng quốc tế", Note = "" }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
