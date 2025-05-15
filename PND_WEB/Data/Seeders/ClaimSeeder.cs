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
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Index", Description = "Xem báo giá" },


                    // HBL
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Create", Description = "Tạo HBL mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Edit", Description = "Chỉnh sửa HBL" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Edit", Description = "Xóa sửa HBL" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Index", Description = "Xem HBL" },

                    // Container

                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Create", Description = "Tạo Container mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Edit", Description = "Chỉnh sửa Container" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Edit", Description = "Xóa sửa Container" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Index", Description = "Xem Container" },

                    //Buy Invoice
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Create", Description = "Tạo hóa đơn mua hàng mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Edit", Description = "Chỉnh sửa hóa đơn mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Delete", Description = "Xóa hóa đơn mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Index", Description = "Xem hóa đơn mua hàng" },

                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Details", Description = "Xem hóa đơn mua hàng" },


                   //Charge Invoice Manager
                   new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "AllInvoice", ClaimValue = "Manager Charge", Description = "Cập nhật phí hóa đơn" },
                      // Check Invoice
                   new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "AllInvoice", ClaimValue = "Check", Description = "Duyệt thông tin đơn" }





                    );
               


                await context.SaveChangesAsync();
            }

        }
    }
}
