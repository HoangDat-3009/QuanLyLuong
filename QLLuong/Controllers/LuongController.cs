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
        public IActionResult Index(string searchString,int pageNumber =1,int pageSize =10)
        {
            
            var luongs = db.Luongs.Include(l=> l.MaNhanVienNavigation)
                .ThenInclude(nv=>nv.MaHeSoNavigation)
                .Include(l=>l.MaKtklNavigation)
                .Include(l=>l.MaLuongCoBanPhanTramBhNavigation).Where(l=>l.MaNhanVienNavigation != null);
           
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            ViewBag.PhongBans = db.PhongBans.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                luongs = luongs.Where(s => s.MaNhanVien.ToString().Equals(searchString)
                || (s.MaNhanVienNavigation.HoTen != null && s.MaNhanVienNavigation.HoTen.Contains(searchString)));
            }
            
            //phantrang

            var totalRecords =  luongs.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs =  luongs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.searchString = searchString;
            return View(paginatedLuongs);
        }
        [HttpPost]
        public IActionResult Filter(int month,int year, int pageNumber = 1, int pageSize = 7)
        {
            var luongs = db.Luongs.Include(l => l.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaHeSoNavigation)
                .Include(l => l.MaKtklNavigation)
                .Include(l => l.MaLuongCoBanPhanTramBhNavigation).Where(l => l.MaNhanVienNavigation != null);
            if (month == 0 && year == 0)
            {
                return View("Index",luongs);
            }

            if (month == 0)
            {
                luongs= luongs.Where(l=> l.Nam == year);
            }
            if (year == 0) {
                luongs = luongs.Where(l => l.Thang == month);
            }
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            ViewBag.PhongBans = db.PhongBans.ToList();
            ViewBag.ChuyenMons = db.ChuyenMons.ToList();

            var totalRecords = luongs.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs = luongs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return PartialView("LuongTable",luongs);
        }
    }
}
