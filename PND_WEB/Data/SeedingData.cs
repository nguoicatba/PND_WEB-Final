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
        public static async Task SeedData(DataContext _context, RoleManager<IdentityRole> roleManager,UserManager<AppUserModel> userManager)
        {
            await _context.Database.MigrateAsync();

            await ClaimSeeder.SeedAsync(_context);

            await KindOfPackageSeeder.SeedAsync(_context);

            await CarrierSeeder.SeedAsync(_context);

            await SupperAdminSeeder.SeedAsync(_context, roleManager, userManager);

            await CEOSeeder.SeedAsync(_context, roleManager, userManager);

            await SaleSeeder.SeedAsync(_context, roleManager, userManager);

            await DocsSeeder.SeedAsync(_context, roleManager, userManager);

            await AccountantSeeder.SeedAsync(_context, roleManager, userManager);

            await CustomerSeeder.SeedAsync(_context); 

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
           
            if (!await roleManager.RoleExistsAsync("Log"))
            {
                await roleManager.CreateAsync(new IdentityRole("Logistic"));
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
                        ShipperName = "International Logistics UK Ltd",
                        Saddress = "121 King Street, London EC2V 7AA, UK",
                        Scity = "London",
                        SpersonInCharge = "Alice Johnson",
                        TaxId = "GB123456789"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL002",
                        ShipperName = "Global Freight USA Inc",
                        Saddress = "350 Mission Street, San Francisco, CA 94105, USA",
                        Scity = "San Francisco",
                        SpersonInCharge = "Michael Chen",
                        TaxId = "US94-1234567"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL003",
                        ShipperName = "Tokyo Shipping Corporation",
                        Saddress = "1-1-2 Marunouchi, Chiyoda-ku, Tokyo 100-0005, Japan",
                        Scity = "Tokyo",
                        SpersonInCharge = "Hiroshi Tanaka",
                        TaxId = "JP1234567890"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL004",
                        ShipperName = "Hamburg Maritime GmbH",
                        Saddress = "Süderstraße 288, 20537 Hamburg, Germany",
                        Scity = "Hamburg",
                        SpersonInCharge = "Klara Schmidt",
                        TaxId = "DE812345678"
                    },
                    new TblShipper
                    {
                        Shipper = "INTL005",
                        ShipperName = "Beijing International Freight Co",
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
                        Vol = "2000",
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
                        Vol = "1000",
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
                        Vol = "1000",
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
                        Vol = "1500",
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
                        Vol = "1700",
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
                        Vol = "800",
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
                        Vol = "950",
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
                        Vol = "750",
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
                        Vol = "500",
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
                        Vol = "2000",
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
                        Vol = "1100",
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
                        Vol = "1340",
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
                        Vol = "200",
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
                        Vol = "5000",
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
                        Vol = "1300",
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
                        Vol = "6000",
                        Commodity = "Caffe",
                        Pol = "CK HUNG DIEN (LA)",
                        Adds = "PHAO LIEN CHIEU",
                        Pod = "CANG TAN CANG MTRUNG",
                    }
                );
                await _context.SaveChangesAsync();
            }

            // Seeding BookingConfirm
            if (!await _context.TblBookingConfirms.AnyAsync())
            {
                await _context.TblBookingConfirms.AddRangeAsync(
                    // Tháng 1 (4 bookings)
                    new TblBookingConfirm
                    {
                        BookingId = "BK202501001",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 1, 15),
                        GoodType = "FCLI",
                        ETD = new DateTime(2025, 1, 20),
                        ETA = new DateTime(2025, 1, 25),
                        POL = "CANG BINH LONG",
                        POD = "CANG BEN DAM (VT)",
                        VesselName = "MAERSK VALENCIA",
                        ContainerType = "40`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 200,
                        GrossWeight = 1500,
                        ChargeableWeight = 1500,
                        Volume = 40,
                        CargoDescription = "Electronics and Components",
                        Status = "Hoàn thành",
                        Remarks = "Handle with care",
                        CreatedDate = new DateTime(2025, 1, 15),
                        UpdatedDate = new DateTime(2025, 1, 15),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0912345678",
                        PICcompany = "Nguyễn Văn A",
                        QuotationId = "QTN202501001",
                        CNEE = "CNEE001",
                        Shipper = "INTL001"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202501002",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 1, 18),
                        GoodType = "FCLE",
                        ETD = new DateTime(2025, 1, 23),
                        ETA = new DateTime(2025, 1, 28),
                        POL = "CANG BINH DUC (LA)",
                        POD = "CANG HAI PHONG",
                        VesselName = "COSCO SHANGHAI",
                        ContainerType = "20`GP",
                        ContainerQuantity = 3,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 150,
                        GrossWeight = 2200,
                        ChargeableWeight = 2200,
                        Volume = 30,
                        CargoDescription = "Frozen Food Products",
                        Status = "Hoàn thành",
                        Remarks = "Temperature controlled",
                        CreatedDate = new DateTime(2025, 1, 18),
                        UpdatedDate = new DateTime(2025, 1, 18),
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "0912345678",
                        PICcompany = "Trần Văn B",
                        QuotationId = "QTN202501002",
                        CNEE = "CNEE002",
                        Shipper = "INTL002"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202501003",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 1, 22),
                        GoodType = "AI",
                        ETD = new DateTime(2025, 1, 24),
                        ETA = new DateTime(2025, 1, 25),
                        POL = "CANG AN THOI",
                        POD = "CANG DONG THAP",
                        VesselName = "",
                        ContainerType = "",
                        ContainerQuantity = 0,
                        FlightNumber = "VN216",
                        Airline = "Vietnam Airlines",
                        PackageQuantity = 80,
                        GrossWeight = 1800,
                        ChargeableWeight = 2000,
                        Volume = 15,
                        CargoDescription = "Furniture Parts",
                        Status = "Hoàn thành",
                        Remarks = "Express delivery",
                        CreatedDate = new DateTime(2025, 1, 22),
                        UpdatedDate = new DateTime(2025, 1, 22),
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "0912345678",
                        PICcompany = "Lê Văn C",
                        QuotationId = "QTN202501003",
                        CNEE = "CNEE003",
                        Shipper = "INTL003"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202501004",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 1, 25),
                        GoodType = "LCLI",
                        ETD = new DateTime(2025, 1, 30),
                        ETA = new DateTime(2025, 2, 5),
                        POL = "CANG BA NGOI (K.HOA)",
                        POD = "CANG CAN THO",
                        VesselName = "ONE HAMBURG",
                        ContainerType = "40`HC",
                        ContainerQuantity = 1,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 300,
                        GrossWeight = 3000,
                        ChargeableWeight = 3000,
                        Volume = 50,
                        CargoDescription = "Rice in Bags",
                        Status = "Hoàn thành",
                        Remarks = "Food grade containers",
                        CreatedDate = new DateTime(2025, 1, 25),
                        UpdatedDate = new DateTime(2025, 1, 25),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0912345678",
                        PICcompany = "Phạm Văn D",
                        QuotationId = "QTN202501004",
                        CNEE = "CNEE004",
                        Shipper = "INTL004"
                    },

                    // Tháng 2 (3 bookings)
                    new TblBookingConfirm
                    {
                        BookingId = "BK202502001",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 2, 5),
                        GoodType = "FCLE",
                        ETD = new DateTime(2025, 2, 10),
                        ETA = new DateTime(2025, 2, 20),
                        POL = "DONG TAU BACH DANG",
                        POD = "CUA KHAU BAC DAI",
                        VesselName = "MSC LONDON",
                        ContainerType = "40`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 180,
                        GrossWeight = 2000,
                        ChargeableWeight = 2000,
                        Volume = 35,
                        CargoDescription = "Textile Products",
                        Status = "Hoàn thành",
                        Remarks = "Regular shipment",
                        CreatedDate = new DateTime(2025, 2, 5),
                        UpdatedDate = new DateTime(2025, 2, 5),
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "0923456789",
                        PICcompany = "Lê Thị E",
                        QuotationId = "QTN202502001",
                        CNEE = "CNEE001",
                        Shipper = "INTL002"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202502002",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 2, 15),
                        GoodType = "AE",
                        ETD = new DateTime(2025, 2, 18),
                        ETA = new DateTime(2025, 2, 19),
                        POL = "CANG BINH LONG",
                        POD = "CANG HAI PHONG",
                        VesselName = "",
                        ContainerType = "",
                        ContainerQuantity = 0,
                        FlightNumber = "KE708",
                        Airline = "Korean Air",
                        PackageQuantity = 120,
                        GrossWeight = 2500,
                        ChargeableWeight = 2800,
                        Volume = 25,
                        CargoDescription = "Electronic Components",
                        Status = "Hoàn thành",
                        Remarks = "Urgent delivery",
                        CreatedDate = new DateTime(2025, 2, 15),
                        UpdatedDate = new DateTime(2025, 2, 15),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0923456789",
                        PICcompany = "Trần Thị F",
                        QuotationId = "QTN202502002",
                        CNEE = "CNEE002",
                        Shipper = "INTL003"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202502003",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 2, 25),
                        GoodType = "LCLI",
                        ETD = new DateTime(2025, 3, 1),
                        ETA = new DateTime(2025, 3, 10),
                        POL = "CANG HON LA (Q.BINH)",
                        POD = "CANG D.QUAT - B.SO 1",
                        VesselName = "ZIM QINGDAO",
                        ContainerType = "20`GP",
                        ContainerQuantity = 1,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 90,
                        GrossWeight = 1700,
                        ChargeableWeight = 1700,
                        Volume = 28,
                        CargoDescription = "Machine Parts",
                        Status = "Hoàn thành",
                        Remarks = "Special handling required",
                        CreatedDate = new DateTime(2025, 2, 25),
                        UpdatedDate = new DateTime(2025, 2, 25),
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "0923456789",
                        PICcompany = "Nguyễn Văn G",
                        QuotationId = "QTN202502003",
                        CNEE = "CNEE003",
                        Shipper = "INTL004"
                    },

                    // Tháng 3 (5 bookings)
                    new TblBookingConfirm
                    {
                        BookingId = "BK202503001",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 3, 2),
                        GoodType = "FCLI",
                        ETD = new DateTime(2025, 3, 7),
                        ETA = new DateTime(2025, 3, 17),
                        POL = "CANG NAM DINH VU",
                        POD = "CANG D.QUAT - B.SO 1",
                        VesselName = "CMA CGM MARCO POLO",
                        ContainerType = "40`HC",
                        ContainerQuantity = 3,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 250,
                        GrossWeight = 3000,
                        ChargeableWeight = 3000,
                        Volume = 45,
                        CargoDescription = "Industrial Equipment",
                        Status = "Hoàn thành",
                        Remarks = "Heavy lift cargo",
                        CreatedDate = new DateTime(2025, 3, 2),
                        UpdatedDate = new DateTime(2025, 3, 2),
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "0934567890",
                        PICcompany = "Phạm Thị H",
                        QuotationId = "QTN202503001",
                        CNEE = "CNEE004",
                        Shipper = "INTL001"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202503002",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 3, 8),
                        GoodType = "FCLE",
                        ETD = new DateTime(2025, 3, 13),
                        ETA = new DateTime(2025, 3, 23),
                        POL = "CANG BINH DUC (LA)",
                        POD = "CANG HAI PHONG",
                        VesselName = "EVERGREEN TITAN",
                        ContainerType = "40`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 160,
                        GrossWeight = 2800,
                        ChargeableWeight = 2800,
                        Volume = 38,
                        CargoDescription = "Steel Products",
                        Status = "Hoàn thành",
                        Remarks = "Regular customer",
                        CreatedDate = new DateTime(2025, 3, 8),
                        UpdatedDate = new DateTime(2025, 3, 8),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0934567890",
                        PICcompany = "Lê Văn I",
                        QuotationId = "QTN202503002",
                        CNEE = "CNEE001",
                        Shipper = "INTL002"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202503003",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 3, 15),
                        GoodType = "AI",
                        ETD = new DateTime(2025, 3, 17),
                        ETA = new DateTime(2025, 3, 18),
                        POL = "CANG AN THOI",
                        POD = "CANG CAN THO",
                        VesselName = "",
                        ContainerType = "",
                        ContainerQuantity = 0,
                        FlightNumber = "JL751",
                        Airline = "Japan Airlines",
                        PackageQuantity = 75,
                        GrossWeight = 1900,
                        ChargeableWeight = 2100,
                        Volume = 22,
                        CargoDescription = "Automotive Parts",
                        Status = "Hoàn thành",
                        Remarks = "Time-sensitive shipment",
                        CreatedDate = new DateTime(2025, 3, 15),
                        UpdatedDate = new DateTime(2025, 3, 15),
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "0934567890",
                        PICcompany = "Trần Văn K",
                        QuotationId = "QTN202503003",
                        CNEE = "CNEE002",
                        Shipper = "INTL003"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202503004",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 3, 22),
                        GoodType = "LCLE",
                        ETD = new DateTime(2025, 3, 27),
                        ETA = new DateTime(2025, 4, 6),
                        POL = "CANG BA NGOI (K.HOA)",
                        POD = "CANG HAI PHONG",
                        VesselName = "COSCO FORTUNE",
                        ContainerType = "20`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 110,
                        GrossWeight = 2200,
                        ChargeableWeight = 2200,
                        Volume = 32,
                        CargoDescription = "Consumer Electronics",
                        Status = "Hoàn thành",
                        Remarks = "Fragile items",
                        CreatedDate = new DateTime(2025, 3, 22),
                        UpdatedDate = new DateTime(2025, 3, 22),
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "0934567890",
                        PICcompany = "Nguyễn Thị L",
                        QuotationId = "QTN202503004",
                        CNEE = "CNEE003",
                        Shipper = "INTL004"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202503005",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 3, 28),
                        GoodType = "FCLI",
                        ETD = new DateTime(2025, 4, 2),
                        ETA = new DateTime(2025, 4, 12),
                        POL = "DONG TAU BACH DANG",
                        POD = "CANG D.QUAT - B.SO 1",
                        VesselName = "YANG MING UNITY",
                        ContainerType = "40`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 220,
                        GrossWeight = 3500,
                        ChargeableWeight = 3500,
                        Volume = 55,
                        CargoDescription = "Textile Machinery",
                        Status = "Hoàn thành",
                        Remarks = "Installation required at destination",
                        CreatedDate = new DateTime(2025, 3, 28),
                        UpdatedDate = new DateTime(2025, 3, 28),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0934567890",
                        PICcompany = "Phạm Văn M",
                        QuotationId = "QTN202503005",
                        CNEE = "CNEE004",
                        Shipper = "INTL001"
                    },

                    // Tháng 4 (4 bookings)
                    new TblBookingConfirm
                    {
                        BookingId = "BK202504001",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 4, 5),
                        GoodType = "FCLE",
                        ETD = new DateTime(2025, 4, 10),
                        ETA = new DateTime(2025, 4, 20),
                        POL = "CANG HON LA (Q.BINH)",
                        POD = "CANG HAI PHONG",
                        VesselName = "COSCO SHIPPING ALPS",
                        ContainerType = "40`HC",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 190,
                        GrossWeight = 2500,
                        ChargeableWeight = 2500,
                        Volume = 42,
                        CargoDescription = "Auto Parts and Accessories",
                        Status = "Hoàn thành",
                        Remarks = "Quality inspection required",
                        CreatedDate = new DateTime(2025, 4, 5),
                        UpdatedDate = new DateTime(2025, 4, 5),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0945678901",
                        PICcompany = "Lê Thị N",
                        QuotationId = "QTN202504001",
                        CNEE = "CNEE001",
                        Shipper = "INTL002"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202504002",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 4, 12),
                        GoodType = "AE",
                        ETD = new DateTime(2025, 4, 14),
                        ETA = new DateTime(2025, 4, 15),
                        POL = "CANG BINH DUC (LA)",
                        POD = "CANG CAN THO",
                        VesselName = "",
                        ContainerType = "",
                        ContainerQuantity = 0,
                        FlightNumber = "SQ978",
                        Airline = "Singapore Airlines",
                        PackageQuantity = 85,
                        GrossWeight = 1800,
                        ChargeableWeight = 2000,
                        Volume = 20,
                        CargoDescription = "Medical Supplies",
                        Status = "Hoàn thành",
                        Remarks = "Temperature controlled",
                        CreatedDate = new DateTime(2025, 4, 12),
                        UpdatedDate = new DateTime(2025, 4, 12),
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "0945678901",
                        PICcompany = "Trần Văn O",
                        QuotationId = "QTN202504002",
                        CNEE = "CNEE002",
                        Shipper = "INTL003"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202504003",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 4, 18),
                        GoodType = "LCLI",
                        ETD = new DateTime(2025, 4, 23),
                        ETA = new DateTime(2025, 5, 3),
                        POL = "CANG AN THOI",
                        POD = "CANG HAI PHONG",
                        VesselName = "HAPAG LLOYD ANTWERP",
                        ContainerType = "20`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 140,
                        GrossWeight = 2700,
                        ChargeableWeight = 2700,
                        Volume = 36,
                        CargoDescription = "Furniture Sets",
                        Status = "Hoàn thành",
                        Remarks = "Assembly required",
                        CreatedDate = new DateTime(2025, 4, 18),
                        UpdatedDate = new DateTime(2025, 4, 18),
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "0945678901",
                        PICcompany = "Nguyễn Văn P",
                        QuotationId = "QTN202504003",
                        CNEE = "CNEE003",
                        Shipper = "INTL004"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202504004",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 4, 25),
                        GoodType = "FCLI",
                        ETD = new DateTime(2025, 4, 30),
                        ETA = new DateTime(2025, 5, 10),
                        POL = "CANG BA NGOI (K.HOA)",
                        POD = "CANG D.QUAT - B.SO 1",
                        VesselName = "ZIM HAMBURG",
                        ContainerType = "40`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 230,
                        GrossWeight = 3200,
                        ChargeableWeight = 3200,
                        Volume = 48,
                        CargoDescription = "Industrial Machinery",
                        Status = "Hoàn thành",
                        Remarks = "Technical support needed",
                        CreatedDate = new DateTime(2025, 4, 25),
                        UpdatedDate = new DateTime(2025, 4, 25),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0945678901",
                        PICcompany = "Lê Thị Q",
                        QuotationId = "QTN202504004",
                        CNEE = "CNEE004",
                        Shipper = "INTL001"
                    },

                    // Tháng 5 (5 bookings)
                    new TblBookingConfirm
                    {
                        BookingId = "BK202505001",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 5, 3),
                        GoodType = "FCLE",
                        ETD = new DateTime(2025, 5, 8),
                        ETA = new DateTime(2025, 5, 18),
                        POL = "CK KHANH BINH (AG)",
                        POD = "NM D.TAU NAM TRIEU",
                        VesselName = "EVERGREEN EXCELLENCE",
                        ContainerType = "40`GP",
                        ContainerQuantity = 1,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 95,
                        GrossWeight = 1800,
                        ChargeableWeight = 1800,
                        Volume = 30,
                        CargoDescription = "Chemical Products",
                        Status = "Hoàn thành",
                        Remarks = "Hazardous materials",
                        CreatedDate = new DateTime(2025, 5, 3),
                        UpdatedDate = new DateTime(2025, 5, 3),
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "0956789012",
                        PICcompany = "Trần Thị R",
                        QuotationId = "QTN202505001",
                        CNEE = "CNEE001",
                        Shipper = "INTL002"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202505002",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 5, 10),
                        GoodType = "AI",
                        ETD = new DateTime(2025, 5, 12),
                        ETA = new DateTime(2025, 5, 13),
                        POL = "DONG TAU BACH DANG",
                        POD = "CANG HAI PHONG",
                        VesselName = "",
                        ContainerType = "",
                        ContainerQuantity = 0,
                        FlightNumber = "EK392",
                        Airline = "Emirates",
                        PackageQuantity = 120,
                        GrossWeight = 2400,
                        ChargeableWeight = 2600,
                        Volume = 28,
                        CargoDescription = "Electronic Devices",
                        Status = "Hoàn thành",
                        Remarks = "High value cargo",
                        CreatedDate = new DateTime(2025, 5, 10),
                        UpdatedDate = new DateTime(2025, 5, 10),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0956789012",
                        PICcompany = "Phạm Văn S",
                        QuotationId = "QTN202505002",
                        CNEE = "CNEE002",
                        Shipper = "INTL003"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202505003",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 5, 15),
                        GoodType = "FCLI",
                        ETD = new DateTime(2025, 5, 20),
                        ETA = new DateTime(2025, 5, 30),
                        POL = "CANG BINH LONG",
                        POD = "CANG CAN THO",
                        VesselName = "CMA CGM AMAZON",
                        ContainerType = "40`HC",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 280,
                        GrossWeight = 3100,
                        ChargeableWeight = 3100,
                        Volume = 52,
                        CargoDescription = "Vehicle Parts",
                        Status = "Hoàn thành",
                        Remarks = "Custom clearance assistance",
                        CreatedDate = new DateTime(2025, 5, 15),
                        UpdatedDate = new DateTime(2025, 5, 15),
                        StaffName = "Nguyễn Lê Trung Kiên",
                        Contact = "0956789012",
                        PICcompany = "Lê Văn T",
                        QuotationId = "QTN202505003",
                        CNEE = "CNEE003",
                        Shipper = "INTL004"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202505004",
                        CustomerId = "132132",
                        BookingDate = new DateTime(2025, 5, 20),
                        GoodType = "LCLE",
                        ETD = new DateTime(2025, 5, 25),
                        ETA = new DateTime(2025, 6, 4),
                        POL = "CANG AN THOI",
                        POD = "CANG D.QUAT - B.SO 1",
                        VesselName = "COSCO PACIFIC",
                        ContainerType = "20`GP",
                        ContainerQuantity = 2,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 170,
                        GrossWeight = 2800,
                        ChargeableWeight = 2800,
                        Volume = 40,
                        CargoDescription = "Construction Equipment",
                        Status = "Hoàn thành",
                        Remarks = "Heavy machinery",
                        CreatedDate = new DateTime(2025, 5, 20),
                        UpdatedDate = new DateTime(2025, 5, 20),
                        StaffName = "Phạm Tiến Đạt",
                        Contact = "0956789012",
                        PICcompany = "Nguyễn Thị U",
                        QuotationId = "QTN202505004",
                        CNEE = "CNEE004",
                        Shipper = "INTL001"
                    },
                    new TblBookingConfirm
                    {
                        BookingId = "BK202505005",
                        CustomerId = "0108111428",
                        BookingDate = new DateTime(2025, 5, 25),
                        GoodType = "FCLE",
                        ETD = new DateTime(2025, 5, 30),
                        ETA = new DateTime(2025, 6, 9),
                        POL = "CANG BA NGOI (K.HOA)",
                        POD = "CANG HAI PHONG",
                        VesselName = "YANG MING WORLD",
                        ContainerType = "40`GP",
                        ContainerQuantity = 1,
                        FlightNumber = "",
                        Airline = "",
                        PackageQuantity = 150,
                        GrossWeight = 2600,
                        ChargeableWeight = 2600,
                        Volume = 35,
                        CargoDescription = "Textile Products",
                        Status = "Hoàn thành",
                        Remarks = "Standard shipping",
                        CreatedDate = new DateTime(2025, 5, 25),
                        UpdatedDate = new DateTime(2025, 5, 25),
                        StaffName = "Cao Trần Hưng",
                        Contact = "0956789012",
                        PICcompany = "Trần Văn V",
                        QuotationId = "QTN202505005",
                        CNEE = "CNEE001",
                        Shipper = "INTL002"
                    }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
