using Microsoft.AspNetCore.Mvc;

using QLLuong.Models;
using QLLuong.Data;
using Microsoft.EntityFrameworkCore;
namespace QLLuong.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Route("LuongStaff", Name = "LuongStaff")]
    [Route("Staff/LuongStaff")]
    public class LuongStaffController : Controller
    {
        private readonly QLLuongContext db;
        public LuongStaffController(QLLuongContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            var UserName = HttpContext.Session.GetString("Username");
            if (UserName == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            var check = db.UserLogins.Where(u => u.Username.Equals(UserName)).FirstOrDefault();
            int monthNow = 10; //DateTime.Now.Month;
            int yearNow = DateTime.Now.Year;
            var chamcongs = db.ChamCongs.Where(cc =>cc.NgayGioRa.Value.Month ==  monthNow && cc.MaNhanVien == check.MaNhanVien && cc.NgayGioRa.Value.Year == yearNow);
            NhanVien nv = db.NhanViens
                .Include(n=> n.MaHeSoNavigation)
                .Include(n=> n.MaChucVuNavigation)
                .Include(n=> n.MaTrinhDoNavigation)
                .Where(n => n.MaNhanVien == check.MaNhanVien).FirstOrDefault();
            LuongCoBanPhanTramBh lcb_bh = db.LuongCoBanPhanTramBhs.FirstOrDefault();
            LuongCu luonght = new LuongCu();
            luonght.MaLuongCu = 165 + check.MaNhanVien;
            luonght.MaNhanVien = check.MaNhanVien;
            luonght.Thang = monthNow;
            luonght.Nam = yearNow;
            luonght.LuongCoBan = lcb_bh?.LuongCoBan ??0 ;
            luonght.HeSo = nv?.MaHeSoNavigation?.HeSoLuong ?? 0;
            luonght.PhuCapChucVu = nv.MaChucVuNavigation.PhuCap;
            luonght.PhuCapTrinhDo = nv.MaTrinhDoNavigation.PhuCap;
            luonght.Bhyt = (decimal)(((float)luonght.LuongCoBan 
                * (float)luonght.HeSo 
                + (float)luonght.PhuCapTrinhDo
                + (float)luonght.PhuCapChucVu) 
                * lcb_bh.PhanTramBhyt);
            luonght.Bhtn=(decimal)(((float)luonght.LuongCoBan * (float)luonght.HeSo + (float)luonght.PhuCapTrinhDo + (float)luonght.PhuCapChucVu) * lcb_bh.PhanTramBhtn);       
            luonght.Bhxh= (decimal)(((float)luonght.LuongCoBan * (float)luonght.HeSo + (float)luonght.PhuCapTrinhDo + (float)luonght.PhuCapChucVu) * lcb_bh.PhanTramBhxh);
            luonght.MaNhanVienNavigation = nv;
            float ktkl=0;
            int socong = 0;
            foreach(var i in chamcongs)
            {
                if (i.TrangThai.Equals("Ðã Hoàn Thành") || i.TrangThai.Equals("Đã hoàn thành")) socong++;

                if (i.TrangThai.Equals("Tăng ca")) socong++;
                if (i.TrangThai.Equals("Vào trễ", StringComparison.OrdinalIgnoreCase)){ 
                    socong++;
                    ktkl -= 50000; }
                if (i.TrangThai.Equals("Nghỉ"))
                {
                    if (i.GhiChu.Equals("Không phép")) ktkl -= 100000;
                    
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


            ViewBag.NhanViens = db.NhanViens.ToList();
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            ViewBag.PhongBans = db.PhongBans.ToList();
            ViewBag.ChamCongs = db.ChamCongs.ToList();

            return View(luonght);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter( int pageNumber = 1, int pageSize = 10)
        {

            var UserName = HttpContext.Session.GetString("Username");
            if (UserName == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            var check = db.UserLogins.Where(u => u.Username.Equals(UserName)).FirstOrDefault();

            var luongs = db.Luongs.Include(l => l.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaHeSoNavigation)
                .Include(l => l.MaKtklNavigation)
                .Include(l => l.MaLuongCoBanPhanTramBhNavigation).Where(l => l.MaNhanVienNavigation != null && l.MaNhanVien == check.MaNhanVien);

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

            ViewBag.showSearch = false;
            ViewBag.showThangnam = false;

            return View("Index", paginatedLuongs);
        }
    }
}
