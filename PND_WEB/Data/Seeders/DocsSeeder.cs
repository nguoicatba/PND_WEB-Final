using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using System.Security.Claims;

namespace PND_WEB.Data.Seeders
{
    public class DocsSeeder
    {
        public static async Task SeedAsync(DataContext _context, RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            // Check if Docs role exists
            var docsRole = await roleManager.FindByNameAsync("Docs");
            if (docsRole == null)
            {
                // Create Docs role
                docsRole = new IdentityRole
                {
                    Name = "Docs",
                    NormalizedName = "DOCS"
                };
                await roleManager.CreateAsync(docsRole);

                // Add claims for Docs role
                var jobClaims = new[]
                {
                    new Claim("Job", "Create"),
                    new Claim("Job", "Edit"),
                    new Claim("Job", "Delete"),
                    new Claim("Job", "Index"),
                    new Claim("Job", "Details")
                };

                var hblClaims = new[]
                {
                    new Claim("HBL", "Create"),
                    new Claim("HBL", "Edit"),
                    new Claim("HBL", "Delete"),
                    new Claim("HBL", "Index"),
                    new Claim("HBL", "Details")
                };

                var buyChargeClaims = new[]
                {
                    new Claim("Buy Charge", "Index"),
                    new Claim("Buy Charge", "Create"),
                    new Claim("Buy Charge", "Edit"),
                    new Claim("Buy Charge", "Delete")
                };

                var behalfChargeClaims = new[]
                {
                    new Claim("Behalf Charge", "Index"),
                    new Claim("Behalf Charge", "Create"),
                    new Claim("Behalf Charge", "Edit"),
                    new Claim("Behalf Charge", "Delete")
                };

                var containerChargeClaims = new[]
                {
                    new Claim("Container Charge", "Index"),
                    new Claim("Container Charge", "Create"),
                    new Claim("Container Charge", "Edit"),
                    new Claim("Container Charge", "Delete")
                };

                var containerClaims = new[]
                {
                    new Claim("Container", "Create"),
                    new Claim("Container", "Edit"),
                    new Claim("Container", "Delete"),
                    new Claim("Container", "Index")
                };

                // Add all claims to role
                foreach (var claim in jobClaims
                    .Concat(hblClaims)
                    .Concat(buyChargeClaims)
                    .Concat(behalfChargeClaims)
                    .Concat(containerChargeClaims)
                    .Concat(containerClaims))
                {
                    await roleManager.AddClaimAsync(docsRole, claim);
                }
            }

            // Create docs users if they don't exist
            var docsUsers = new[]
            {
                new { Username = "docs@pnd1", StaffName = "Hương" },
                new { Username = "docs@pnd2", StaffName = "Linh" },
                new { Username = "docs@pnd3", StaffName = "Thảo" }
            };

            foreach (var docsUser in docsUsers)
            {
                var existingUser = await userManager.FindByNameAsync(docsUser.Username);
                if (existingUser == null)
                {
                    var user = new AppUserModel
                    {
                        UserName = docsUser.Username,
                        Status = "Active",
                        createDate = DateTime.Now,
                        Staff_Name = docsUser.StaffName,
                        DOB = new DateTime(2003, 1, 1)
                    };

                    string password = "123456@Abc";
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Docs");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($"Error creating Docs user {docsUser.Username}: {error.Description}");
                        }
                    }
                }
            }
        }
    }
} 