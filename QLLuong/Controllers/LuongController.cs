using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using System.Data.Entity;

namespace QLLuong.Controllers
{
    public class LuongController : Controller
    {
        private readonly QLLuongContext db;
        public LuongController(QLLuongContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            
            var luongs = from nv in db.Luongs
                         select nv;
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            ViewBag.NhanViens = db.NhanViens.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            return View(luongs);
        }
       public IActionResult LuongCB_BH()
        {
            var luongcb_bh = db.LuongCoBanPhanTramBhs.ToList();
            return View(luongcb_bh);
        }
    }
}
