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

            await ClaimSeeder.SeedAsync(_context);

            await KindOfPackageSeeder.SeedAsync(_context);

            await CarrierSeeder.SeedAsync(_context);

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
                    new TblSupplier { SupplierId = "SUP001", NameSup = "Công ty TNHH ABC Logistics", Typer = "Agent", AddressSup = "123 Lê Lợi, Q1, HCM", LccFee = "", Note = "Giao hàng nội địa" },
                    new TblSupplier { SupplierId = "SUP002", NameSup = "CTCP Vận Tải Biển XYZ", Typer = "Agent", AddressSup = "789 Trần Hưng Đạo, HN", LccFee = "", Note = "Hỗ trợ thủ tục hải quan" },
                    new TblSupplier { SupplierId = "SUP003", NameSup = "DNTN Kim Ngân Forwarder", Typer = "Agent", AddressSup = "56 Nguyễn Huệ, Đà Nẵng", LccFee = "", Note = "Giao hàng quốc tế" }
                );
                await _context.SaveChangesAsync();
            }


            if (!await _context.TblShippers.AnyAsync())
            {
                await _context.TblShippers.AddRangeAsync(
                    new TblShipper
                    {
                        Shipper = "INTL001",
                        Saddress = "121 King Street, London EC2V 7AA, UK",
                        Scity = "London",
                        SpersonInCharge = "Alice Johnson",
                        TaxId = "GB123456789"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL002",
                        Saddress = "350 Mission Street, San Francisco, CA 94105, USA",
                        Scity = "San Francisco",
                        SpersonInCharge = "Michael Chen",
                        TaxId = "US94-1234567"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL003",
                        Saddress = "1-1-2 Marunouchi, Chiyoda-ku, Tokyo 100-0005, Japan",
                        Scity = "Tokyo",
                        SpersonInCharge = "Hiroshi Tanaka",
                        TaxId = "JP1234567890"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL004",
                        Saddress = "Süderstraße 288, 20537 Hamburg, Germany",
                        Scity = "Hamburg",
                        SpersonInCharge = "Klara Schmidt",
                        TaxId = "DE812345678"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL005",
                        Saddress = "Suite 1802, 18F, Tower A, Beijing Fortune Plaza, Beijing, China",
                        Scity = "Beijing",
                        SpersonInCharge = "Li Wei",
                        TaxId = "CN110108123456789"
                    }
                );
                await _context.SaveChangesAsync();
            }

            if (!await _context.TblCnees.AnyAsync())
            {
                await _context.TblCnees.AddRangeAsync(
                    new TblCnee
                    {
                        Cnee = "CNEE001",
                        Vcnee = "Công ty TNHH Nhập Khẩu Toàn Cầu",
                        Caddress = "350 Mission Street, San Francisco, CA 94105, USA",
                        Vaddress = "350 Phố Nhiệm Vụ, San Francisco, Hoa Kỳ",
                        Ccity = "San Francisco",
                        CpersonInCharge = "Emily Thompson",
                        TaxId = "US84-9988776",
                        Haddress = "789 Lake View Rd, Oakland, CA"
                    },
                    new TblCnee
                    {
                        Cnee = "CNEE002",
                        Vcnee = "CTCP Thương Mại Á Âu",
                        Caddress = "88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong",
                        Vaddress = "88 Đường Nathan, Cửu Long, Hồng Kông",
                        Ccity = "Hong Kong",
                        CpersonInCharge = "Raymond Cheng",
                        TaxId = "HK456789321",
                        Haddress = "Flat 12B, Tower 3, Harbour View Gardens, HK"
                    },
                    new TblCnee
                    {
                        Cnee = "CNEE003",
                        Vcnee = "CT TNHH Công Nghệ Đức Minh",
                        Caddress = "Hafenstraße 15, 28195 Bremen, Germany",
                        Vaddress = "15 Đường Cảng, Bremen, Đức",
                        Ccity = "Bremen",
                        CpersonInCharge = "Lars Becker",
                        TaxId = "DE908765432",
                        Haddress = "42 Bahnhofstraße, Bremen"
                    },
                    new TblCnee
                    {
                        Cnee = "CNEE004",
                        Vcnee = "Tập Đoàn Thép Việt Hàn",
                        Caddress = "6 Battery Road, Singapore 049909",
                        Vaddress = "6 Đường Battery, Singapore",
                        Ccity = "Singapore",
                        CpersonInCharge = "Tan Wei Ling",
                        TaxId = "SG123456789A",
                        Haddress = "22 Ang Mo Kio Ave 3, Singapore"
                    }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding Quotation
            if (!await _context.Quotations.AnyAsync())
            {
                await _context.Quotations.AddRangeAsync(
                    // Tháng 1
                    new Quotation
                    {
                        QuotationId = "QTN202501001",
                        Qsatus = "Hoàn thành",
                        StaffName = "Cao Trần Hưng",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 1, 10),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 1, 25),
                        Term = "EXW",
                        Vol = "2000 KG",
                        Commodity = "Gạo",
                        Pol = "CANG BINH LONG",
                        Adds = "CANG TONG HOP BDUONG",
                        Pod = "CANG BEN DAM (VT)",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202501002",
                        Qsatus = "Hoàn thành",
                        StaffName = "Cao Trần Hưng",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 1, 11),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 1, 26),
                        Term = "EXW",
                        Vol = "1000 KG",
                        Commodity = "Gạo",
                        Pol = "DONG TAU BACH DANG",
                        Adds = "CANG AN THOI",
                        Pod = "CUA KHAU BAC DAI",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202501003",
                        Qsatus = "Hoàn thành",
                        StaffName = "Cao Trần Hưng",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 1, 12),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 1, 27),
                        Term = "EXW",
                        Vol = "1000 KG",
                        Commodity = "Bắp",
                        Pol = "CANG NAM DINH VU",
                        Adds = "CANG DONG THAP",
                        Pod = "CANG D.QUAT - B.SO 1",
                    },
                    // Tháng 2
                    new Quotation
                    {
                        QuotationId = "QTN202502001",
                        Qsatus = "Hoàn thành",
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 2, 9),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 2, 14),
                        Term = "EXW",
                        Vol = "1500 KG",
                        Commodity = "Ngô",
                        Pol = "CANG NAM DINH VU",
                        Adds = "CANG DONG THAP",
                        Pod = "CANG D.QUAT - B.SO 1",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202502002",
                        Qsatus = "Hoàn thành",
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 2, 11),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 2, 25),
                        Term = "EXW",
                        Vol = "1700 KG",
                        Commodity = "Thịt bò",
                        Pol = "CANG HON LA (Q.BINH)",
                        Adds = "CANG HA LOC (V.TAU)",
                        Pod = "CANG HAI PHONG",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202502003",
                        Qsatus = "Hoàn thành",
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 2, 12),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 2, 26),
                        Term = "EXW",
                        Vol = "800 KG",
                        Commodity = "Thịt lợn",
                        Pol = "CK KHANH BINH (AG)",
                        Adds = "CANG KY HA (Q.NAM)",
                        Pod = "NM D.TAU NAM TRIEU",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202502004",
                        Qsatus = "Hoàn thành",
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 2, 14),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 2, 28),
                        Term = "EXW",
                        Vol = "950 KG",
                        Commodity = "Thịt gà",
                        Pol = "CANG NINH PHUC(NB)",
                        Adds = "CANG NHA RONG (HCM)",
                        Pod = "CANG PHU QUY (D.NAI)",
                    },
                    // Tháng 3
                    new Quotation
                    {
                        QuotationId = "QTN202503001",
                        Qsatus = "Hoàn thành",
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 3, 5),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 3, 20),
                        Term = "EXW",
                        Vol = "750 KG",
                        Commodity = "Thịt cá sấu",
                        Pol = "DONG TAU PHA RUNG",
                        Adds = "CANG PV SHIPYARDS",
                        Pod = "CANG SA DEC (DT)",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202503002",
                        Qsatus = "Hoàn thành",
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 3, 13),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 3, 28),
                        Term = "EXW",
                        Vol = "500 KG",
                        Commodity = "Thịt trâu",
                        Pol = "CANG SON DUONG",
                        Adds = "CANG Z (HO CHI MINH)",
                        Pod = "CANG SA KY (B.DINH)",
                    },
                    //Tháng 4
                    new Quotation
                    {
                        QuotationId = "QTN202504001",
                        Qsatus = "Hoàn thành",
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 4, 1),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 4, 16),
                        Term = "EXW",
                        Vol = "2000 KG",
                        Commodity = "Thịt vịt",
                        Pol = "CUA KHAU SONG DOC",
                        Adds = "CANG SP-PSA (V.TAU)",
                        Pod = "CANG QT SP-SSA(SSIT)",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202504002",
                        Qsatus = "Hoàn thành",
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 4, 7),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 4, 21),
                        Term = "EXW",
                        Vol = "1100 KG",
                        Commodity = "Cá ngừ",
                        Pol = "TAN CANG (189)",
                        Adds = "CANG THUAN AN (HUE)",
                        Pod = "CANG THUY SAN II",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202504003",
                        Qsatus = "Hoàn thành",
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 4, 10),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 4, 25),
                        Term = "EXW",
                        Vol = "1340 KG",
                        Commodity = "Cá mập",
                        Pol = "CANG VAT CACH (HP)",
                        Adds = "CANG VAN AN (V.TAU)",
                        Pod = "CANG CAN THO",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202504004",
                        Qsatus = "Hoàn thành",
                        StaffName = "Cao Trần Hưng",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 4, 15),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 4, 30),
                        Term = "EXW",
                        Vol = "200 KG",
                        Commodity = "Cá koi",
                        Pol = "CANG VEDAN(DONG NAI)",
                        Adds = "CANG VAN PHONG",
                        Pod = "CANG VUNG RO (P.YEN)",
                    },
                    //Tháng5
                    new Quotation
                    {
                        QuotationId = "QTN202505001",
                        Qsatus = "Hoàn thành",
                        StaffName = "Cao Trần Hưng",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 5, 1),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 5, 16),
                        Term = "EXW",
                        Vol = "5000 KG",
                        Commodity = "Gạo",
                        Pol = "CANG HA LUU PTSC(VT)",
                        Adds = "CANG VINH THAI(CTHO)",
                        Pod = "CANG PTSC (VUNG TAU)",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202505002",
                        Qsatus = "Hoàn thành",
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 5, 8),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 5, 23),
                        Term = "EXW",
                        Vol = "1300 KG",
                        Commodity = "Lúa mì",
                        Pol = "CANG BIEN DONG",
                        Adds = "CANG XIMANG CAM PHA",
                        Pod = "CANG VIP GREEN PORT",
                    },
                    new Quotation
                    {
                        QuotationId = "QTN202505003",
                        Qsatus = "Hoàn thành",
                        StaffName = "Cao Trần Hưng",
                        Contact = "123456789",
                        Qdate = new DateTime(2025, 5, 14),
                        CusTo = "Nguyễn Văn A",
                        CusContact = "2123131223",
                        Valid = new DateTime(2025, 5, 29),
                        Term = "EXW",
                        Vol = "6000 KG",
                        Commodity = "Caffe",
                        Pol = "CK HUNG DIEN (LA)",
                        Adds = "PHAO LIEN CHIEU",
                        Pod = "CANG TAN CANG MTRUNG",
                    }
                );
                await _context.SaveChangesAsync();
            }

        }
    }
}
