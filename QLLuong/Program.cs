using Microsoft.EntityFrameworkCore;
using QLLuong.Models;
using QLLuong.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System;

namespace QLLuong
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<QLNhanVienContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "NhanVienList",
                pattern: "/NhanVien",
                defaults: new { controller = "NhanVien", action = "Index" });
            app.MapControllerRoute(
                name: "NhanVien_Infor_Staff",
                pattern: "/NhanVien/Infor",
                defaults: new { controller = "NhanVien", action = "Index_Infor_Staff" });
            app.MapControllerRoute(
                name: "NhanVien_Luong",
                pattern: "Luong",
                defaults: new { controller = "Luong", action = "Index" });
            app.MapControllerRoute(
                name: "NhanVien_KTKL",
                pattern: "KTKL",
                defaults: new { controller = "KTKL", action = "Index" });
            app.MapControllerRoute(
                name: "Login_Index",
                pattern: "/Login",
                defaults: new { controller = "Login", action = "Index" });
            app.MapControllerRoute(
                name: "Home",
                pattern: "/Home",
                defaults: new { controller = "Home", action = "Index" });
            app.MapControllerRoute(
                name: "ChamCong",
                pattern: "/ChamCong",
                defaults: new { controller = "ChamCong", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LogIn}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
