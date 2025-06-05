using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;
using PND_WEB.ViewModels;
using System.Security.Claims;
namespace PND_WEB.Data.Seeders
{
    public class SupperAdminSeeder
    {
        

        public static async Task SeedAsync(DataContext _context,RoleManager<IdentityRole> roleManager, UserManager<AppUserModel> userManager)
        {
            
            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            {
                var role = new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                };
                await roleManager.CreateAsync(role);

                var ClaimsList = await _context.Claims.ToListAsync();

               
                foreach (var claim in ClaimsList)
                {
                    await roleManager.AddClaimAsync(role, new Claim(claim.ClaimType, claim.ClaimValue));
                }


            }
            
            var GetSuperAdminAccount = await userManager.FindByNameAsync("superadminpnd");

            if (GetSuperAdminAccount == null) {

                // create new super admin account
                var user = new AppUserModel
                {
                    UserName = "superadminpnd",
                    Status = "Active",
                    createDate = DateTime.Now,
                    Staff_Name = "Kien",
                    DOB = new DateTime(2003, 1, 1),

                };
                string password = "123456@Abc";
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "SuperAdmin");
                 
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error creating SuperAdmin: {error.Description}");
                    }
                }


            }


        }
    }
}
