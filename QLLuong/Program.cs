using Microsoft.EntityFrameworkCore;
using QLLuong.Models;
using QLLuong.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace QLLuong
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<QLLuongContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();





            /*builder.Services.AddSession();*/
            // Add this after AddControllersWithViews()
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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

            app.UseSession();



            app.MapControllerRoute(
                name: "NhanVienList",
                pattern: "/NhanVien",
                defaults: new { controller = "NhanVien", action = "Index" });
           
            app.MapControllerRoute(
                name: "NhanVien_Luong",
                pattern: "Luong",
                defaults: new { controller = "Luong", action = "Index" });
            app.MapControllerRoute(
                name: "Luong_LuongCB",
                pattern: "LuongCB_BH/Edit",
                defaults: new { controller = "LuongCB_BH", action = "Edit" });
            app.MapControllerRoute(
                name: "Luong_Filter",
                pattern: "Luong/Filter",
                defaults: new { controller = "Luong", action = "Filter" });
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
