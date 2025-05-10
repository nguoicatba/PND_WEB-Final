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
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Delete", Description = "Xóa job" }

                    );
               


                await context.SaveChangesAsync();
            }

        }
    }
}
