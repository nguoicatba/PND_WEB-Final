using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using Rotativa.AspNetCore;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using PND_WEB.Services;

namespace PND_WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var builderRazor = builder.Services.AddRazorPages();

            // Đường dẫn đến file .dll
            var architectureFolder = Environment.Is64BitProcess ? "64 bit" : "32 bit";
            var wkhtmltoxPath = Path.Combine(Directory.GetCurrentDirectory(), "wkhtmltox", "v0.12.4", architectureFolder, "libwkhtmltox.dll");

            // Load thư viện native
            var context1 = new CustomAssemblyLoadContext();
            context1.LoadUnmanagedLibrary(wkhtmltoxPath);

            // Đăng ký DinkToPdf
            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            builder.Services.AddDbContext<Data.DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddIdentity<AppUserModel, IdentityRole>()
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

            builder.Services.AddScoped<IViewRenderService, ViewRenderService>();

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
            //RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<Data.DataContext>();
            var roleManager = app.Services.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedingData.SeedData(context, roleManager);

            // run code
            app.Run();
        }
    }
}
