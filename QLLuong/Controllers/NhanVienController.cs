using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var nhanViens = await _context.NhanVien.ToListAsync();
            return View(nhanViens);

        }
    }
}
