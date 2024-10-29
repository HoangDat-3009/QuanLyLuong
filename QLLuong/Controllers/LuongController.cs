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
        public IActionResult Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            int monthNow = 10;//DateTime.Now.Month;
            int yearNow = DateTime.Now.Year;
            var chamCongs = db.ChamCongs.Where(cc => cc.NgayGioRa.Value.Month == monthNow && cc.NgayGioRa.Value.Year == yearNow).ToList();
            var chamCongsTemp = chamCongs;
            var nhanviens = db.NhanViens
                .Include(n => n.MaHeSoNavigation)
                .Include(n => n.MaChucVuNavigation)
                .Include(n => n.MaTrinhDoNavigation)
                .Where(nv => nv.IsDeleted == false);
            LuongCoBanPhanTramBh lcb_bh = db.LuongCoBanPhanTramBhs.FirstOrDefault();
            var luongs = new List<LuongCu>();
            
            foreach( var i in nhanviens)
            {
                LuongCu luonght = new LuongCu();
                luonght.MaLuongCu = 165 + i.MaNhanVien;
                luonght.MaNhanVien = i.MaNhanVien;
                luonght.Thang = monthNow;
                luonght.Nam = yearNow;
                luonght.LuongCoBan = lcb_bh?.LuongCoBan ?? 0;
                luonght.HeSo = i?.MaHeSoNavigation?.HeSoLuong ?? 0;
                luonght.PhuCapChucVu = i.MaChucVuNavigation.PhuCap;
                luonght.PhuCapTrinhDo = i.MaTrinhDoNavigation.PhuCap;
                luonght.Bhyt = (decimal)(((float)luonght.LuongCoBan
                    * (float)luonght.HeSo
                    + (float)luonght.PhuCapTrinhDo
                    + (float)luonght.PhuCapChucVu)
                    * lcb_bh.PhanTramBhyt);
                luonght.Bhtn = (decimal)(((float)luonght.LuongCoBan * (float)luonght.HeSo + (float)luonght.PhuCapTrinhDo + (float)luonght.PhuCapChucVu) * lcb_bh.PhanTramBhtn);
                luonght.Bhxh = (decimal)(((float)luonght.LuongCoBan * (float)luonght.HeSo + (float)luonght.PhuCapTrinhDo + (float)luonght.PhuCapChucVu) * lcb_bh.PhanTramBhxh);
                luonght.MaNhanVienNavigation = i;
                float ktkl = 0;
                int socong = 0;
                foreach (var j in chamCongs)
                {
                    if (j.MaNhanVien != i.MaNhanVien) continue;
                    if (j.TrangThai.Equals("Ðã Hoàn Thành") || j.TrangThai.Equals("Đã hoàn thành")) socong++;
                    if (j.TrangThai.Equals("Tăng ca")) socong++;
                    if (j.TrangThai.Equals("Vào trễ", StringComparison.OrdinalIgnoreCase))
                    {
                        socong++;
                        ktkl -= 50000;
                    }
                    if (j.TrangThai.Equals("Nghỉ"))
                    {
                        if (j.GhiChu.Equals("Không phép")) ktkl -= 100000;

                    }

                }
                luonght.SoCong = socong;
                luonght.KhenThuongKyLuat = (decimal)ktkl;
                luonght.ThucLinh = Math.Round(
        (
        ((decimal)(luonght.LuongCoBan ?? 0) * (decimal)luonght.HeSo * (decimal)socong / 30)
        + (decimal)(luonght.PhuCapChucVu ?? 0)
        + (decimal)(luonght.PhuCapTrinhDo ?? 0)
        - (decimal)(luonght.Bhyt ?? 0)
        - (decimal)(luonght.Bhtn ?? 0)
        - (decimal)(luonght.Bhxh ?? 0)
        + (decimal)(luonght.KhenThuongKyLuat ?? 0)), 2);
                luongs.Add(luonght);
            }

            IEnumerable<LuongCu> luong1 = luongs;
            if (!string.IsNullOrEmpty(searchString))
            {
                luong1 = luong1.Where(s => s.MaNhanVien.ToString().Equals(searchString)
                || (s.MaNhanVienNavigation.HoTen != null && s.MaNhanVienNavigation.HoTen.Contains(searchString)));
            }

            var totalRecords = luong1.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs = luong1
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


            ViewBag.showSearch = true;
            ViewBag.searchString = searchString;
            ViewBag.showThangnam = false;

            return View(paginatedLuongs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(string searchString, int pageNumber =1,int pageSize =10)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            int monthNow = 10;//DateTime.Now.Month;
            int yearNow = DateTime.Now.Year;
            var chamCongs = db.ChamCongs.Where(cc => cc.NgayGioRa.Value.Month == monthNow && cc.NgayGioRa.Value.Year == yearNow).ToList();
            var chamCongsTemp = chamCongs;
            var nhanviens = db.NhanViens
                .Include(n => n.MaHeSoNavigation)
                .Include(n => n.MaChucVuNavigation)
                .Include(n => n.MaTrinhDoNavigation)
                .Where(nv => nv.IsDeleted == false);
            LuongCoBanPhanTramBh lcb_bh = db.LuongCoBanPhanTramBhs.FirstOrDefault();
            var luongs = new List<LuongCu>();

            foreach (var i in nhanviens)
            {
                LuongCu luonght = new LuongCu();
                luonght.MaLuongCu = 165 + i.MaNhanVien;
                luonght.MaNhanVien = i.MaNhanVien;
                luonght.Thang = monthNow;
                luonght.Nam = yearNow;
                luonght.LuongCoBan = lcb_bh?.LuongCoBan ?? 0;
                luonght.HeSo = i?.MaHeSoNavigation?.HeSoLuong ?? 0;
                luonght.PhuCapChucVu = i.MaChucVuNavigation.PhuCap;
                luonght.PhuCapTrinhDo = i.MaTrinhDoNavigation.PhuCap;
                luonght.Bhyt = (decimal)(((float)luonght.LuongCoBan
                    * (float)luonght.HeSo
                    + (float)luonght.PhuCapTrinhDo
                    + (float)luonght.PhuCapChucVu)
                    * lcb_bh.PhanTramBhyt);
                luonght.Bhtn = (decimal)(((float)luonght.LuongCoBan * (float)luonght.HeSo + (float)luonght.PhuCapTrinhDo + (float)luonght.PhuCapChucVu) * lcb_bh.PhanTramBhtn);
                luonght.Bhxh = (decimal)(((float)luonght.LuongCoBan * (float)luonght.HeSo + (float)luonght.PhuCapTrinhDo + (float)luonght.PhuCapChucVu) * lcb_bh.PhanTramBhxh);
                luonght.MaNhanVienNavigation = i;
                float ktkl = 0;
                int socong = 0;
                foreach (var j in chamCongs)
                {
                    if (j.MaNhanVien != i.MaNhanVien) continue;
                    if (j.TrangThai.Equals("Ðã Hoàn Thành") || j.TrangThai.Equals("Đã hoàn thành")) socong++;
                    if (j.TrangThai.Equals("Tăng ca")) socong++;
                    if (j.TrangThai.Equals("Vào trễ", StringComparison.OrdinalIgnoreCase))
                    {
                        socong++;
                        ktkl -= 50000;
                    }
                    if (j.TrangThai.Equals("Nghỉ"))
                    {
                        if (j.GhiChu.Equals("Không phép")) ktkl -= 100000;

                    }

                }
                luonght.SoCong = socong;
                luonght.KhenThuongKyLuat = (decimal)ktkl;
                luonght.ThucLinh = Math.Round(
        (
        ((decimal)(luonght.LuongCoBan ?? 0) * (decimal)luonght.HeSo * (decimal)socong / 30)
        + (decimal)(luonght.PhuCapChucVu ?? 0)
        + (decimal)(luonght.PhuCapTrinhDo ?? 0)
        - (decimal)(luonght.Bhyt ?? 0)
        - (decimal)(luonght.Bhtn ?? 0)
        - (decimal)(luonght.Bhxh ?? 0)
        + (decimal)(luonght.KhenThuongKyLuat ?? 0)), 2);
                luongs.Add(luonght);
            }

            IEnumerable<LuongCu> luong1 = luongs;
            if (!string.IsNullOrEmpty(searchString))
            {
                luong1 = luong1.Where(s => s.MaNhanVien.ToString().Equals(searchString)
                || (s.MaNhanVienNavigation.HoTen != null && s.MaNhanVienNavigation.HoTen.Contains(searchString)));
            }

            var totalRecords = luong1.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedLuongs = luong1
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


            ViewBag.showSearch = true;
            ViewBag.searchString = searchString;
            ViewBag.showThangnam = false;

            return View("Index",paginatedLuongs);
        }
    }
}
