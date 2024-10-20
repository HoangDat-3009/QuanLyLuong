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
            ViewBag.LuongCoBan_PhanTramBH = db.LuongCoBan_PhanTramBHs.ToList();
            return View(luongs);
        }
    }
}
