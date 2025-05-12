using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data.Seeders
{
    public class ClaimSeeder
    {
        public static async Task SeedAsync(DataContext context)
        {
            if (!context.Claims.Any())
            {
                await context.AddRangeAsync(
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Create", Description = "Tạo job mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Edit", Description = "Chỉnh sửa job" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Delete", Description = "Xóa job" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Index", Description = "Xem job" },


                    // báo giá
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Create", Description = "Tạo báo giá mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Edit", Description = "Chỉnh sửa báo giá" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Delete", Description = "Xóa báo giá" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Index", Description = "Xem báo giá" }



                    );
               


                await context.SaveChangesAsync();
            }

        }
    }
}
