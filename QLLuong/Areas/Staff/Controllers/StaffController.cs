using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models.Authentication;

namespace QLLuong.Areas.Staff.Controllers
{
    public class StaffController : Controller
    {
        private readonly QLLuongContext _context;
        [Authentication]
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 6)
        {
            var nhanViens = from nv in _context.NhanViens
                            .Include(nv => nv.MaPhongBanNavigation)
                            .Include(nv => nv.MaChucVuNavigation)
                            .Include(nv => nv.MaTrinhDoNavigation)
                            .Include(nv => nv.MaChuyenMonNavigation)
                            .Include(nv => nv.MaHeSoNavigation)
                            select nv;

            if (!string.IsNullOrEmpty(searchString))
            {
                nhanViens = nhanViens.Where(s => s.MaNhanVien.ToString().Equals(searchString)
                || (s.HoTen != null && s.HoTen.Contains(searchString)));
            }

            var totalRecords = await nhanViens.CountAsync();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedNhanViens = await nhanViens
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;

            return View(paginatedNhanViens);
        }

    }
}
