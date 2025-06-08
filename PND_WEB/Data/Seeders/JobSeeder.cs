using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data.Seeders
{
    public class JobSeeder
    {
        public static async Task SeedAsync(DataContext _context)
        {
            // Only seed if no jobs exist
            if (!await _context.TblJobs.AnyAsync())
            {
                await _context.TblJobs.AddRangeAsync(

                  new TblJob
                  {
                      JobId = "AIHP202506090001",
                      GoodsType = "AI",
                      JobDate = new DateTime(2025, 6, 9),
                      Mbl = "dfgfd",
                      IssueDateM = new DateTime(2025, 6, 12),
                      OnBoardDateM = new DateTime(2025, 6, 15),
                      VesselName = "kien",
                      VoyageName = "fewf",
                      Pol = "CANG BA NGOI(K.HOA)",
                      Pod = "CUA KHAU BAC DAI",
                      Podel = "CANG BA NGOI(K.HOA)",
                      Podis = "CUA KHAU BAC DAI",
                      PlaceofDelivery = "CANG BA NGOI(K.HOA)",
                      PlaceofReceipt = "CANG BA NGOI(K.HOA)",
                      PreCariageBy = "kien",
                      Etd = new DateTime(2025, 6, 9),
                      Eta = new DateTime(2025, 6, 15),
                      Mode = "AIR / AIR",
                      Agent = "APM",
                      Carrier = "AGL",
                      YunLock=15,
                      Ycompany = "2025",
                      JobOwner = "superadminpnd",
                      JobStatus = true

                  },
                  new TblJob
                  {
                      JobId = "AEHP202506090001",
                      GoodsType = "AE",
                      JobDate = new DateTime(2025, 6, 9),
                      Mbl = "dfgfd",
                      IssueDateM = new DateTime(2025, 6, 12),
                      OnBoardDateM = new DateTime(2025, 6, 15),
                      VesselName = "kien",
                      VoyageName = "fewf",
                      Pol = "CANG BA NGOI(K.HOA)",
                      Pod = "CUA KHAU BAC DAI",
                      Podel = "CANG BA NGOI(K.HOA)",
                      Podis = "CUA KHAU BAC DAI",
                      PlaceofDelivery = "CANG BA NGOI(K.HOA)",
                      PlaceofReceipt = "CANG BA NGOI(K.HOA)",
                      PreCariageBy = "kien",
                      Etd = new DateTime(2025, 6, 9),
                      Eta = new DateTime(2025, 6, 15),
                      Mode = "AIR / AIR",
                      Agent = "APM",
                      Carrier = "AGL",
                      YunLock = 15,
                      Ycompany = "2025",
                      JobOwner = "docs@pnd1",
                      JobStatus = true

                  },
                   new TblJob
                   {
                       JobId = "FCLIHP202506090001",
                       GoodsType = "FCLI",
                       JobDate = new DateTime(2025, 6, 9),
                       Mbl = "dfgfd",
                       IssueDateM = new DateTime(2025, 6, 12),
                       OnBoardDateM = new DateTime(2025, 6, 15),
                       VesselName = "kien",
                       VoyageName = "fewf",
                       Pol = "CANG BA NGOI(K.HOA)",
                       Pod = "CUA KHAU BAC DAI",
                       Podel = "CANG BA NGOI(K.HOA)",
                       Podis = "CUA KHAU BAC DAI",
                       PlaceofDelivery = "CANG BA NGOI(K.HOA)",
                       PlaceofReceipt = "CANG BA NGOI(K.HOA)",
                       PreCariageBy = "kien",
                       Etd = new DateTime(2025, 6, 9),
                       Eta = new DateTime(2025, 6, 15),
                       Mode = "AIR / AIR",
                       Agent = "APM",
                       Carrier = "AGL",
                       YunLock = 15,
                       Ycompany = "2025",
                       JobOwner = "docs@pnd1",
                       JobStatus = true

                   }


                );
               
               
                await _context.SaveChangesAsync();
            }

        }
    }
} 