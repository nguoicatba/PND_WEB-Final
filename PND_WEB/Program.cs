using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using Rotativa.AspNetCore;

namespace PND_WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var builderRazor = builder.Services.AddRazorPages();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Data.DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddIdentity<AppUserModel,IdentityRole>()
    .AddEntityFrameworkStores<Data.DataContext>().AddDefaultTokenProviders();
           

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
              
                // Lockout settings.
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;

                // User settings.
                //options.User.AllowedUserNameCharacters =
                //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            var app = builder.Build();

            app.UseStatusCodePagesWithRedirects("/Home/Error/?statuscode={0}");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                builderRazor.AddRazorRuntimeCompilation();
            }

            var env = builder.Environment;
            RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<Data.DataContext>();
            SeedingData.SeedData(context);
            
            // run code
            app.Run();
        }
    }
}
