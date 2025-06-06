using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data.Seeders
{
    public class ClaimSeeder
    {
        public static async Task SeedAsync(DataContext context)
        {
            // delete all existing claims
            //if (context.Claims.Any())
            //{
            //    context.Claims.RemoveRange(context.Claims);
            //    await context.SaveChangesAsync();
            //}

            if (!context.Claims.Any())
            {

                await context.AddRangeAsync(
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Create", Description = "Tạo job mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Edit", Description = "Chỉnh sửa job" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Delete", Description = "Xóa job" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Job", ClaimValue = "Index", Description = "Xem job" },


                    // báo giá sale
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Create", Description = "Tạo báo giá mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Edit", Description = "Chỉnh sửa báo giá" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "Delete", Description = "Xóa báo giá" },

                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "DeleteCharges", Description = "Tạo phi báo giá mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "CreateCharges", Description = "Chỉnh sửa phí báo giá" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "EditCharges", Description = "Xóa phí báo giá" },

                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "IndexUser", Description = "Xem báo giá user" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "IndexAdmin", Description = "Xem báo giá admin" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Quotation", ClaimValue = "DetailsCharges", Description = "Xem chi tiết báo giá" },

                    //booking confirm
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BookingComfirm", ClaimValue = "Create", Description = "Tạo booking mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BookingComfirm", ClaimValue = "Edit", Description = "Chỉnh booking giá" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BookingComfirm", ClaimValue = "Delete", Description = "Xóa báo giá" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BookingComfirm", ClaimValue = "Details", Description = "Xem chi tiết booking" },

                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BookingComfirm", ClaimValue = "IndexUser", Description = "Xem booking user" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BookingComfirm", ClaimValue = "IndexAdmin", Description = "Xem booking admin" },


                    // tạm ứng thanh toán check
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "TamUngThanhToanCheck", ClaimValue = "Check", Description = "Thông tin tạm ứng thanh toán khi duyệt" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "TamUngThanhToanCheck", ClaimValue = "CheckDelete", Description = "Xóa thông tin tạm ứng thanh toán khi duyệt" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "TamUngThanhToanCheck", ClaimValue = "CheckDetails", Description = "Chi tiết thông tin tạm ứng thanh toán khi duyệt" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "TamUngThanhToanCheck", ClaimValue = "CheckEdit", Description = "Sửa thông tin tạm ứng thanh toán khi duyệt" },

                    // HBL
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Create", Description = "Tạo HBL mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Edit", Description = "Chỉnh sửa HBL" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Edit", Description = "Xóa sửa HBL" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "HBL", ClaimValue = "Index", Description = "Xem HBL" },

                    // Container

                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Create", Description = "Tạo Container mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Edit", Description = "Chỉnh sửa Container" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Delete", Description = "Xóa Container" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container", ClaimValue = "Index", Description = "Xem Container" },

                    //Buy Invoice
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Create", Description = "Tạo hóa đơn mua hàng mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Edit", Description = "Chỉnh sửa hóa đơn mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Delete", Description = "Xóa hóa đơn mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Index", Description = "Xem hóa đơn mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "BuyInvoice", ClaimValue = "Details", Description = "Xem hóa đơn mua hàng" },

                    // Buy Charge Manager
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Buy Charge", ClaimValue = "Index", Description = "Xem phí mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Buy Charge", ClaimValue = "Create", Description = "Tạo phí mua hàng mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Buy Charge", ClaimValue = "Edit", Description = "Chỉnh sửa phí mua hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Buy Charge", ClaimValue = "Delete", Description = "Xóa phí mua hàng" },

                    // Sell Charge Manager
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Sell Charge", ClaimValue = "Index", Description = "Xem phí bán hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Sell Charge", ClaimValue = "Create", Description = "Tạo phí bán hàng mới" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Sell Charge", ClaimValue = "Edit", Description = "Chỉnh sửa phí bán hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Sell Charge", ClaimValue = "Delete", Description = "Xóa phí bán hàng" },
                    new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Sell Charge", ClaimValue = "Get Charge", Description = "Lấy phí nhanh" },

                     // Container Charge Manager
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container Charge", ClaimValue = "Index", Description = "Xem phí cược container" },
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container Charge", ClaimValue = "Create", Description = "Tạo phí cược container mới" },
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container Charge", ClaimValue = "Edit", Description = "Chỉnh sửa phí cược container" },
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Container Charge", ClaimValue = "Delete", Description = "Xóa phí cược container" },

                     // Behalf Charge Manager
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Behalf Charge", ClaimValue = "Index", Description = "Xem phí chi hộ" },
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Behalf Charge", ClaimValue = "Create", Description = "Tạo phí chi hộ mới" },
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Behalf Charge", ClaimValue = "Edit", Description = "Chỉnh sửa phí chi hộ" },
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Behalf Charge", ClaimValue = "Delete", Description = "Xóa phí chi hộ" },

                     //Account Manager
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Account", ClaimValue = "Manager", Description = "Quản lý tài khoản" },
                     //Role Manager
                     new ApplicationClaim { Id = Guid.NewGuid().ToString(), ClaimType = "Role", ClaimValue = "Manager", Description = "Quản lý quyền" },





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
