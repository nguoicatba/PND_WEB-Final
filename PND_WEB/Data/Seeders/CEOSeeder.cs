using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.ViewModels;
using System.Security.Claims;

namespace PND_WEB.Data.Seeders
{
    public class CEOSeeder
    {
        public static async Task SeedAsync(DataContext _context, RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            // Delete existing CEO role and account if they exist
            var existingRole = await roleManager.FindByNameAsync("CEO");
            if (existingRole != null)
            {
                // Delete all claims associated with the role
                var claims = await roleManager.GetClaimsAsync(existingRole);
                foreach (var claim in claims)
                {
                    await roleManager.RemoveClaimAsync(existingRole, claim);
                }
                // Delete the role
                await roleManager.DeleteAsync(existingRole);
                // Delete the CEO account
                var ceoAccount = await userManager.FindByNameAsync("ceopnd");
                if (ceoAccount != null)
                {
                    await userManager.DeleteAsync(ceoAccount);
                }
            }

            // Delete account if it exists
            var existingUser = await userManager.FindByNameAsync("ceopnd");
            if (existingUser != null)
            {
                await userManager.DeleteAsync(existingUser);
            }

            // Create CEO role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("CEO"))
            {
                var role = new IdentityRole
                {
                    Name = "CEO",
                    NormalizedName = "CEO"
                };
                await roleManager.CreateAsync(role);

                // Get all claims from the database
                var ClaimsList = await _context.Claims.ToListAsync();
                
                // Add all claims to CEO role
                foreach (var claim in ClaimsList)
                {
                    await roleManager.AddClaimAsync(role, new Claim(claim.ClaimType, claim.ClaimValue));
                }
            }

            // Create CEO account if it doesn't exist
            var GetCEOAccount = await userManager.FindByNameAsync("ceopnd");

            if (GetCEOAccount == null)
            {
                // Create new CEO account
                var user = new AppUserModel
                {
                    UserName = "ceopnd",
                    Status = "Active",
                    createDate = DateTime.Now,
                    Staff_Name = "CEO",
                    DOB = new DateTime(2003, 1, 1)
                };

                string password = "123456@Abc";
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "CEO");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error creating CEO: {error.Description}");
                    }
                }
            }
        }
    }
} 