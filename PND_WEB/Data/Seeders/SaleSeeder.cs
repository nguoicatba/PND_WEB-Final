using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using System.Security.Claims;

namespace PND_WEB.Data.Seeders
{
    public class SaleSeeder
    {
        public static async Task SeedAsync(DataContext _context, RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            // Check if Sale role exists
            var saleRole = await roleManager.FindByNameAsync("Sale");
            if (saleRole == null)
            {
                // Create Sale role
                saleRole = new IdentityRole
                {
                    Name = "Sale",
                    NormalizedName = "SALE"
                };
                await roleManager.CreateAsync(saleRole);

                // Add claims for Sale role
                var quotationClaims = new[]
                {
                    new Claim("Quotation", "Create"),
                    new Claim("Quotation", "Edit"),
                    new Claim("Quotation", "Delete"),
                    new Claim("Quotation", "DeleteCharges"),
                    new Claim("Quotation", "CreateCharges"),
                    new Claim("Quotation", "EditCharges"),
                    new Claim("Quotation", "IndexUser"),
                    new Claim("Quotation", "DetailsCharges")
                };

                var sellChargeClaims = new[]
                {
                    new Claim("Sell Charge", "Index"),
                    new Claim("Sell Charge", "Create"),
                    new Claim("Sell Charge", "Edit"),
                    new Claim("Sell Charge", "Delete"),
                    new Claim("Sell Charge", "Get Charge")
                };

                var jobClaims = new[]
                {
                    new Claim("Job", "Index"),
                    new Claim("Job", "Details")
                };

                var hblClaims = new[]
                {
                    new Claim("HBL", "Index"),
                    new Claim("HBL", "Details")
                };

                var bookingConfirmClaims = new[]
                {
                    new Claim("BookingComfirm", "Create"),
                    new Claim("BookingComfirm", "Edit"),
                    new Claim("BookingComfirm", "Delete"),
                    new Claim("BookingComfirm", "Details"),
                    new Claim("BookingComfirm", "IndexUser")
                };

                // Add all claims to role
                foreach (var claim in quotationClaims
                    .Concat(sellChargeClaims)
                    .Concat(jobClaims)
                    .Concat(hblClaims)
                    .Concat(bookingConfirmClaims))
                {
                    await roleManager.AddClaimAsync(saleRole, claim);
                }
            }

            // Create sale users if they don't exist
            var saleUsers = new[]
            {
                new { Username = "sale@pnd1", StaffName = "Kiên" },
                new { Username = "sale@pnd2", StaffName = "Hưng" },
                new { Username = "sale@pnd3", StaffName = "Đạt" }
            };

            foreach (var saleUser in saleUsers)
            {
                var existingUser = await userManager.FindByNameAsync(saleUser.Username);
                if (existingUser == null)
                {
                    var user = new AppUserModel
                    {
                        UserName = saleUser.Username,
                        Status = "Active",
                        createDate = DateTime.Now,
                        Staff_Name = saleUser.StaffName,
                        DOB = new DateTime(2003, 1, 1)
                    };

                    string password = "123456@Abc";
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Sale");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error creating Sale user {saleUser.Username}: {error.Description}");
                        }
                    }
                }
            }
        }
    }
} 