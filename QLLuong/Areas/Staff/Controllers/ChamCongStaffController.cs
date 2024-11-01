using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;
using QLLuong.Models.Authentication;
using X.PagedList;


namespace QLLuong.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Route("ChamCongStaff", Name = "ChamCongStaff")]
    [Route("Staff/ChamCongStaff")]
    public class ChamCongStaffController : Controller
    {
        private readonly QLLuongContext _context;

        public ChamCongStaffController(QLLuongContext context)
        {
            _context = context;
        }
        private int pageSize = 10;

        [HttpGet]
        [Authentication]
        public IActionResult Index(string searchString, DateTime? selectedMonth, int page = 1)
        {
            var chamcongs = _context.ChamCongs
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaPhongBanNavigation)
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaChucVuNavigation)
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.UserLogin)
                .AsQueryable();

            // loc theo thang
            if (selectedMonth.HasValue && selectedMonth.Value != DateTime.MinValue)
            {
                chamcongs = chamcongs.Where(c => c.NgayGioRa.HasValue && c.NgayGioRa.Value.Month == selectedMonth.Value.Month);
            }

            var chek = _context.UserLogins.Where(x => x.Username == HttpContext.Session.GetString("Username")).FirstOrDefault();
            
            chamcongs = chamcongs.Where(c => c.MaNhanVienNavigation.UserLogin.MaNhanVien == chek.MaNhanVien );
            //phan trang
            page = page < 1 ? 1 : page;
            int skip = (page - 1) * pageSize;

            var paginatedChamCongs = chamcongs.Skip(skip).Take(pageSize).ToList();


            int totalRecords = chamcongs.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;

            ViewBag.Departments = _context.PhongBans.ToList();
            ViewBag.SelectedMonth = selectedMonth;

            return View(paginatedChamCongs);
        }
    }
}
