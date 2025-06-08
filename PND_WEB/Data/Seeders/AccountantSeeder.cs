using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using System.Security.Claims;

namespace PND_WEB.Data.Seeders
{
    public class AccountantSeeder
    {
        public static async Task SeedAsync(DataContext _context, RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            // Check if Accountant role exists
            var accountantRole = await roleManager.FindByNameAsync("Accountant");
            if (accountantRole == null)
            {
                // Create Accountant role
                accountantRole = new IdentityRole
                {
                    Name = "Accountant",
                    NormalizedName = "ACCOUNTANT"
                };
                await roleManager.CreateAsync(accountantRole);

                // Add claims for Accountant role
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

                var invoiceClaims = new[]
                {
                    new Claim("AllInvoice", "Check")
                };

                var tamUngClaims = new[]
                {
                    new Claim("TamUngThanhToanCheck", "Check"),
                    new Claim("TamUngThanhToanCheck", "CheckDelete"),
                    new Claim("TamUngThanhToanCheck", "CheckDetails"),
                    new Claim("TamUngThanhToanCheck", "CheckEdit")
                };

                // Add all claims to role
                foreach (var claim in jobClaims
                    .Concat(hblClaims)
                    .Concat(invoiceClaims)
                    .Concat(tamUngClaims))
                {
                    await roleManager.AddClaimAsync(accountantRole, claim);
                }
            }

            // Create accountant users if they don't exist
            var accountantUsers = new[]
            {
                new { Username = "accountant@pnd1", StaffName = "Lan" },
                new { Username = "accountant@pnd2", StaffName = "Mai" },
                new { Username = "accountant@pnd3", StaffName = "Hà" }
            };

            foreach (var accountantUser in accountantUsers)
            {
                var existingUser = await userManager.FindByNameAsync(accountantUser.Username);
                if (existingUser == null)
                {
                    var user = new AppUserModel
                    {
                        UserName = accountantUser.Username,
                        Status = "Active",
                        createDate = DateTime.Now,
                        Staff_Name = accountantUser.StaffName,
                        DOB = new DateTime(2003, 1, 1)
                    };

                    string password = "123456@Abc";
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Accountant");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error creating Accountant user {accountantUser.Username}: {error.Description}");
                        }
                    }
                }
            }
        }
    }
} 