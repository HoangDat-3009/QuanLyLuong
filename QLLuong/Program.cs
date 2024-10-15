namespace QLLuong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
                name: "NhanVienList",
                pattern: "/ChamCong",
                defaults: new { controller = "ChamCong", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LogIn}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
