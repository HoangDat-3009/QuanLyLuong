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
        public IActionResult Index(int month, int year,  int pageNumber = 1, int pageSize = 10)
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

            var luongs = db.Luongs.Include(l => l.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaHeSoNavigation)
                .Include(l => l.MaKtklNavigation)
                .Include(l => l.MaLuongCoBanPhanTramBhNavigation).Where(l => l.MaNhanVienNavigation != null && l.MaNhanVien == check.MaNhanVien);

            TempData["ModalMessage"] = "Tháng:" + month + ",năm:" + year;
            if (month != 0)
            {
                luongs = luongs.Where(l => l.Thang == month);
            }
            if (year != 0)
            {
                luongs = luongs.Where(l => l.Nam == year);
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
            ViewBag.showSearch = false;

            return View(paginatedLuongs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(int month, int year,  int pageNumber = 1, int pageSize = 10)
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

            TempData["ModalMessage"] = "Tháng:" + month + ",năm:" + year;
            if (month != 0)
            {
                luongs = luongs.Where(l => l.Thang == month);
            }
            if (year != 0)
            {
                luongs = luongs.Where(l => l.Nam == year);
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

            ViewBag.showSearch = false;

            return View("Index", paginatedLuongs);
        }
    }
}
