using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;

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
            
            var luongs = db.Luongs.Include(l=> l.MaNhanVienNavigation)
                .ThenInclude(nv=>nv.MaHeSoNavigation)
                .Include(l=>l.MaKtklNavigation)
                .Include(l=>l.MaLuongCoBanPhanTramBhNavigation).ToList();
            //for (int i = 0; i < luongs.Count(); i++)
            //{
            //    if (luongs[i].MaNhanVienNavigation == null)
            //    {
            //        luongs.RemoveAt(i);
            //    }
            //}
            ViewBag.LuongCoBanPhanTramBhs = db.LuongCoBanPhanTramBhs.ToList();
            //ViewBag.NhanViens = db.NhanViens.ToList();
            ViewBag.KhenThuongKyLuats = db.KhenThuongKyLuats.ToList();
            ViewBag.TrinhDos = db.TrinhDos.ToList();
            ViewBag.ChucVus = db.ChucVus.ToList();
            ViewBag.HeSos = db.HeSos.ToList();
            return View(luongs);
        }
        
    }
}
