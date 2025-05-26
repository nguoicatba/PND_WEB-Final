using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using System.Runtime.InteropServices;
using PND_WEB.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PND_WEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Cấu hình Razor Pages (nếu dùng)
            builder.Services.AddRazorPages();

            // Load thư viện native cho DinkToPdf
            var architectureFolder = Environment.Is64BitProcess ? "64 bit" : "32 bit";
            var wkhtmltoxPath = Path.Combine(Directory.GetCurrentDirectory(), "wkhtmltox", "v0.12.4", architectureFolder, "libwkhtmltox.dll");
            var context1 = new CustomAssemblyLoadContext();
            context1.LoadUnmanagedLibrary(wkhtmltoxPath);

            // Đăng ký DinkToPdf
            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            // Đăng ký DbContext
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Đăng ký các dịch vụ custom
            builder.Services.AddSingleton<BudgetService>();
            builder.Services.AddScoped<IViewRenderService, ViewRenderService>();

            // Cấu hình Identity
            builder.Services.AddIdentity<AppUserModel, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = false;
            });

            var app = builder.Build();

            // Xử lý lỗi HTTP code
            app.UseStatusCodePagesWithRedirects("/Home/Error/?statuscode={0}");

            // Cấu hình môi trường
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Cấu hình routing mặc định
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Gọi SeedData một cách bất đồng bộ
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataContext>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<AppUserModel>>();

                await SeedingData.SeedData(context, roleManager, userManager);
            }

            // Run ứng dụng
            await app.RunAsync();
        }
    }
}
