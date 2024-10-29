using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace QLLuong.Controllers
{
    public class LuongCuController : Controller
    {
        private readonly QLLuongContext db;
        public LuongCuController(QLLuongContext context)
        {
            db = context;   
        }
        public IActionResult Index(int month, int year, string searchString, int pageNumber = 1, int pageSize = 10)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "LogIn");
            }


            var luongs = db.LuongCus.Include(l => l.MaNhanVienNavigation)
                .Where(l => l.MaNhanVienNavigation != null);

            if (month != 0)
            {
                luongs = luongs.Where(l => l.Thang == month);
            }
            if (year != 0)
            {
                luongs = luongs.Where(l => l.Nam == year);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                luongs = luongs.Where(s => s.MaNhanVien.ToString().Equals(searchString)
                || (s.MaNhanVienNavigation.HoTen != null && s.MaNhanVienNavigation.HoTen.Contains(searchString)));
            }

            var totalRecords = luongs.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs = luongs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            //ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            //ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            //ViewBag.TrinhDos = db.TrinhDos.ToList();
            //ViewBag.ChucVus = db.ChucVus.ToList();
            //ViewBag.HeSos = db.HeSos.ToList();
            //ViewBag.PhongBans = db.PhongBans.ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;


            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.showSearch = true;
            ViewBag.showThangNam = true;
            ViewBag.searchString = searchString;

            return View(paginatedLuongs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(int month, int year, string searchString, int pageNumber = 1, int pageSize = 10)
        {

            var luongs = db.LuongCus.Include(l => l.MaNhanVienNavigation)
                .Where(l => l.MaNhanVienNavigation != null);

            if (month != 0)
            {
                luongs = luongs.Where(l => l.Thang == month);
            }
            if (year != 0)
            {
                luongs = luongs.Where(l => l.Nam == year);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                luongs = luongs.Where(s => s.MaNhanVien.ToString().Equals(searchString)
                || (s.MaNhanVienNavigation.HoTen != null && s.MaNhanVienNavigation.HoTen.Contains(searchString)));
            }

            var totalRecords = luongs.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs = luongs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            //ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            //ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            //ViewBag.TrinhDos = db.TrinhDos.ToList();
            //ViewBag.ChucVus = db.ChucVus.ToList();
            //ViewBag.HeSos = db.HeSos.ToList();
            //ViewBag.PhongBans = db.PhongBans.ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.showSearch = true;
            ViewBag.showThangNam = true;
            ViewBag.searchString = searchString;

            return View("Index", paginatedLuongs);
        }
    }
}
