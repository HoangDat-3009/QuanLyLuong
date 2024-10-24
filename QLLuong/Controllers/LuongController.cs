using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace QLLuong.Controllers
{
    public class LuongController : Controller
    {
        private readonly QLLuongContext db;
        public LuongController(QLLuongContext context)
        {
            db = context;
        }
        public IActionResult Index(int month, int year, string searchString, int pageNumber = 1, int pageSize = 10)
        {

            var luongs = db.Luongs.Include(l => l.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaHeSoNavigation)
                .Include(l => l.MaKtklNavigation)
                .Include(l => l.MaLuongCoBanPhanTramBhNavigation).Where(l => l.MaNhanVienNavigation != null);

            TempData["ModalMessage"] = "Tháng:" + month + ",năm:" + year;
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
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            ViewBag.PhongBans = db.PhongBans.ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;


            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.searchString = searchString;

            return View(paginatedLuongs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(int month, int year, string searchString, int pageNumber =1,int pageSize =10)
        {
            
            var luongs = db.Luongs.Include(l=> l.MaNhanVienNavigation)
                .ThenInclude(nv=>nv.MaHeSoNavigation)
                .Include(l=>l.MaKtklNavigation)
                .Include(l=>l.MaLuongCoBanPhanTramBhNavigation).Where(l=>l.MaNhanVienNavigation != null);

            TempData["ModalMessage"] = "Tháng:" + month + ",năm:" + year;
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

            var totalRecords =  luongs.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs =  luongs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            ViewBag.PhongBans = db.PhongBans.ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;


            ViewBag.month = month;
            ViewBag.year = year;
            ViewBag.searchString = searchString;

            return View("Index",paginatedLuongs);
        }
    }
}
