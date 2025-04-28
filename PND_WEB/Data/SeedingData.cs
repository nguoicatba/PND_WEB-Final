using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using System.Collections.Generic;


namespace PND_WEB.Data
{
    public class SeedingData
    {
        public static void SeedData(DataContext _context)
        {
            _context.Database.Migrate();

            if (!_context.Sourses.Any())
            {
                

                _context.Sourses.AddRange(

                    new Sourse { Code = "FREEHAND", SourName = "FREEHAND", Note = "" },
                    new Sourse { Code = "NOMI", SourName = "NOMI", Note = "" }
                );
                _context.SaveChanges();

            }


            if (!_context.Currencies.Any())
            {
                _context.Currencies.AddRange(
                    new Currency { Code = "USD", CurrName = "dollar Mỹ", Note = "Dollar" },
                    new Currency { Code = "EUR", CurrName = "Euro", Note = "Euro" },
                    new Currency { Code = "JPY", CurrName = "Yên nhật", Note = "Yen" },
                    new Currency { Code = "VND", CurrName = "Việt nam đồng", Note = "VND" },
                    new Currency { Code = "CNY", CurrName = "Nhân dân tệ", Note = "CNY" },
                    new Currency { Code = "GBP", CurrName = "Bảng Anh", Note = "Pound" },
                    new Currency { Code = "AUD", CurrName = "Đô la Úc", Note = "AUD" },
                    new Currency { Code = "CAD", CurrName = "Đô la Canada", Note = "CAD" }

                );

                _context.SaveChanges();
            }

            //Port
            if (!_context.Cports.Any())
            {
                _context.Cports.AddRange(
                    new Cport { Code = "VNATH", PortName = "CANG AN THOI" },
                    new Cport { Code = "VNBAI", PortName = "CUA KHAU BAC DAI" },
                    new Cport { Code = "VNBAN", PortName = "CANG BA NGOI (K.HOA)" },
                    new Cport { Code = "VNBDA", PortName = "DONG TAU BACH DANG" },
                    new Cport { Code = "VNBDC", PortName = "CANG BINH DUC (LA)" },
                    new Cport { Code = "VNBDM", PortName = "CANG BEN DAM (VT)" },
                    new Cport { Code = "VNBDU", PortName = "CANG TONG HOP BDUONG" },
                    new Cport { Code = "VNBLG", PortName = "CANG BINH LONG" }

                );

                _context.SaveChanges();
            }

            // BLType
            if (!_context.BlTypes.Any())
            {
                _context.BlTypes.AddRange(
                    new BlType { Code = "Copy", BlName = "", Note = "" },
                    new BlType { Code = "Original", BlName = "", Note = "" },
                    new BlType { Code = "Draft", BlName = "", Note = "" },
                    new BlType { Code = "SEWAY BILL", BlName = "", Note = "" },
                    new BlType { Code = "SURRENDERED", BlName = "", Note = "" },
                    new BlType { Code = "TELEX", BlName = "", Note = "" }
                );
                _context.SaveChanges();
            }


            if (!_context.Units.Any())
            {
                _context.Units.AddRange(
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

                _context.SaveChanges();
            }

            if (!_context.GoodsTypes.Any())
            {

                _context.GoodsTypes.AddRange(

                    new GoodsType { Code = "AI", GtName = "Air Import", Note = "hàng không nhập" },
                    new GoodsType { Code = "AE", GtName = "Air Export", Note = "hàng không xuất" },
                    new GoodsType { Code = "FCLI", GtName = "Full Container Load Import", Note = "hàng nhập nguyên công" },
                    new GoodsType { Code = "FCLE", GtName = "Full Container Load Export", Note = "hàng xuất nguyên công" },
                    new GoodsType { Code = "LCLI", GtName = "Less-than Container Load Import", Note = "hàng lẻ nhập" },
                    new GoodsType { Code = "LCLE", GtName = "Less-than Container Load Export", Note = "hàng lẻ xuất" },
                    new GoodsType { Code = "LGT", GtName = "Logistics", Note = "hàng làm thủ tục hải quan" }

                );
                _context.SaveChanges();
            }

            if (!_context.Modes.Any())
            {
                _context.Modes.AddRange(
                    new Mode { Code = "AIR/AIR", Note = "" },
                    new Mode { Code = "CFS", Note = "" },
                    new Mode { Code = "CFS/CFS", Note = "" },
                    new Mode { Code = "CW", Note = "" },
                    new Mode { Code = "CY/CY", Note = "" }
                );
                _context.SaveChanges();
            }

            if (!_context.Fees.Any())
            {
                _context.Fees.AddRange(

                    new Fee { Code = "ACI", Fee1 = "Phí khai hải quan tự động", Unit = "SET", Note = "" },
                    new Fee { Code = "AFR FEE", Fee1 = "Phí khai hải quan", Unit = "SET", Note = "" },
                    new Fee { Code = "AFS FEE", Fee1 = "Phí khai sơ lược hàng hóa", Unit = "SET", Note = "" },
                    new Fee { Code = "AMENDMENT FEE", Fee1 = "Phí sửa vận đơn", Unit = "SET", Note = "" }


                );
                _context.SaveChanges();
            }

            if (!_context.TblCustomers.Any())
            {
                _context.TblCustomers.AddRange(
                    new TblCustomer
                    {
                        CustomerId = "0108111428",
                        CompanyName = "HAI AN FREIGHT FORWARDING JOINT STOCK COMPANY",
                        CompanyNamekd = "",
                        ComAddress = "Văn phòng 3B, Tầng 3, Tòa B, Tòa nhà Green Pearl số 378 Minh Khai",
                        Website = "http://www.haian.com.vn",
                        DutyPerson = "Nguyễn Văn A",
                        Contact = "Nguyễn Văn B",
                        Email = "",
                    },
                    new TblCustomer
                    {
                        CustomerId = "132132",
                        CompanyName = "DONASCO Logistics - Công Ty TNHH DONASCO",
                        CompanyNamekd = "",
                        ComAddress = "Văn phòng 3B, Tầng 3, Tòa B, Tòa nhà Green Pearl số 378 Minh Khai",
                        Website = "http://www.haian.com.vn",
                        DutyPerson = "Nguyễn Văn A",
                        Contact = "Nguyễn Văn B",
                        Email = "",
                    }


                );
                _context.SaveChanges();
            }

            // Agent
            if (!_context.Agents.Any())
            {
                _context.Agents.AddRange(
                    new Agent
                    {
                        Code = "APM",
                        AgentName = "APM - SAIGON SHIPPING CO.LTD",
                        AgentNamekd = "",
                        AgentAdd = "Lầu 7, Landmark Building, 5B Tôn Đức Thắng, Quận 1",
                        Note = "",
                    },
                    new Agent
                    {
                        Code = "Agent2",
                        AgentName = "CNC, CONTSHIP, KIEN HUNG & VIETFRACHT",
                        AgentNamekd = "",
                        AgentAdd = " Lầu 1, Saigon Port Building, 3 Nguyễn Tất Thành, Quận 4",
                        Note = "",
                    }


                );
                _context.SaveChanges();

            }
            // AgentAction

            if (!_context.AgentActions.Any())
            {


                _context.AgentActions.AddRange(
                    new AgentAction
                    {
                        Code = "Agent2",
                        PersonInCharge = "Mr. Y.S.Chung",
                        PhoneNumber = "8267446",
                        Email = "",
                        Note = "",

                    },
                    new AgentAction
                    {
                        Code = "Agent2",
                        PersonInCharge = "Mr. Tom Chung",
                        PhoneNumber = "8267446",
                        Email = "",
                        Note = "",

                    }
                   );
                _context.SaveChanges();
            }








        }
    }
}
