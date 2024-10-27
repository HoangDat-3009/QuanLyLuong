using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models.Authentication;

namespace QLLuong.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Route("StaffInfor", Name = "StaffInfor")]
    [Route("Staff/StaffInfor")]
    public class StaffInforController : Controller
    {
        private readonly QLLuongContext _context;

        public StaffInforController(QLLuongContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authentication]
        public async Task<IActionResult> Index()
        {
            var nhanViens = _context.NhanViens
                .Include(nv => nv.MaPhongBanNavigation)
                .Include(nv => nv.MaChucVuNavigation)
                .Include(nv => nv.MaTrinhDoNavigation)
                .Include(nv => nv.MaChuyenMonNavigation)
                .Include(nv => nv.MaHeSoNavigation)
                .AsQueryable();
            var chek = _context.UserLogins.Where(x => x.Username == HttpContext.Session.GetString("Username")).FirstOrDefault();
            // Thực hiện tìm kiếm nếu có searchString
           
                nhanViens = nhanViens.Where(c => c.MaNhanVien == chek.MaNhanVien);
            

            var nhanVienList = await nhanViens.ToListAsync(); // Lấy danh sách nhân viên

            return View(nhanVienList); // Trả về danh sách nhân viên
        }

    }
}
