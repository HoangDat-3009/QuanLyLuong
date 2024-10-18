using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;

namespace QLLuong.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly QlluongContext _context;

        public NhanVienController(QlluongContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var nhanViens = from nv in _context.NhanViens
                            select nv;

            if (!string.IsNullOrEmpty(searchString))
            {
                nhanViens = nhanViens.Where(s => s.MaNhanVien.ToString().Equals(searchString) || (s.HoTen != null && s.HoTen.Contains(searchString)));
            }

            return View(nhanViens.ToList());
        }
    }
}