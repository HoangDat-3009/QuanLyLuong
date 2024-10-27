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

            //QLLuongContext context = new QLLuongContext();
            

            app.MapControllerRoute(
                name: "NhanVienList",
                pattern: "/NhanVienAdmin",
                defaults: new { controller = "NhanVien", action = "Index" });
           
            app.MapControllerRoute(
                name: "NhanVien_Luong",
                pattern: "LuongAdmin",
                defaults: new { controller = "Luong", action = "Index" });
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
                pattern: "/ChamCongAdmin",
                defaults: new { controller = "ChamCong", action = "Index" });
            app.MapControllerRoute(
                name: "HomeStaff",
                pattern: "/HomeStaff",
                defaults: new { controller = "HomeStaff", action = "Index" });
            

            app.MapControllerRoute(
                name: "Luong_LuongCB",
                pattern: "/LuongCB",
                defaults: new { controller = "LuongCB_BH", action = "Edit" });


            /*app.MapControllerRoute(
                name: "ChamCongStaff",
                pattern: "{area:exists}/{controller=ChamCongStaff}/{action=Index}/{id?}"
            );*/

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=ChamCongStaff}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "ChamCongStaff",
                pattern: "/ChamCongStaff",
                defaults: new { Areas="Areas", controller = "ChamCongStaff", action = "Index" });

            app.MapControllerRoute(
                name: "LuongStaff",
                pattern: "/LuongStaff",
                defaults: new { Areas = "Areas", controller = "LuongStaff", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LogIn}/{action=Index}/{id?}");


            app.Use(async (context, next) =>
            {
                context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                context.Response.Headers["Pragma"] = "no-cache";
                context.Response.Headers["Expires"] = "0";
                await next();
            });

                 
            app.Run();
        }
    }
}
