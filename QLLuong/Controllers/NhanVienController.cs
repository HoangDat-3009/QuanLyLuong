using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;

namespace QLLuong.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly QLLuongContext _context;

        public NhanVienController(QLLuongContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var nhanViens = from nv in _context.NhanVien
                            select nv;

            if (!string.IsNullOrEmpty(searchString))
            {
                nhanViens = nhanViens.Where(s => s.MaNhanVien.ToString().Equals(searchString) || (s.HoTen != null && s.HoTen.Contains(searchString)));
            }

            return View(nhanViens.ToList());
        }
    }
}