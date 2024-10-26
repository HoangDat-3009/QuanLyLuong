using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;
using QLLuong.Models.Authentication;
using X.PagedList;

namespace QLLuong.Controllers
{
    public class ChamCongController : Controller
    {
        private readonly QLLuongContext _context;

        public ChamCongController(QLLuongContext context)
        {
            _context = context;
        }
        private int pageSize = 10;

        [HttpGet]
        [Authentication]
        public IActionResult Index(string searchString,DateTime? selectedDate , int selectedDepartmentId = 0, int page = 1)
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetString("MaQuyen") == "1")
            {
                return RedirectToAction("Index", "LogIn");
            }

            var chamcongs = _context.ChamCongs
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaPhongBanNavigation)
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaChucVuNavigation)
                .AsQueryable();


            //tim kiem
            if (!string.IsNullOrEmpty(searchString))
            {
                chamcongs = chamcongs.Where(c => c.MaNhanVienNavigation.HoTen.ToLower().Contains(searchString.ToLower())||c.MaNhanVien.ToString().Contains(searchString));
            }
            // Lọc theo phòng ban đã chọn
            if (selectedDepartmentId > 0)
            {
                chamcongs = chamcongs.Where(c => c.MaNhanVienNavigation.MaPhongBan == selectedDepartmentId);
            }
            if (selectedDate.HasValue && selectedDate.Value != DateTime.MinValue)
            {
                chamcongs = chamcongs.Where(c => c.NgayGioRa.HasValue && c.NgayGioRa.Value.Date == selectedDate.Value.Date);
            }

            //phan trang
            page = page < 1 ? 1 : page;
            int skip = (page - 1) * pageSize;

            var paginatedChamCongs = chamcongs.Skip(skip).Take(pageSize).ToList();

 
            int totalRecords = chamcongs.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;

            ViewBag.Departments = _context.PhongBans.ToList();

            ViewBag.selectdate = selectedDate;

            return View(paginatedChamCongs);
        }



        // GET: ChamCong/Edit
        [Authentication]
        public async Task<IActionResult> Edit(int maNhanVien)
        {
            var cc = await _context.ChamCongs
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaPhongBanNavigation)
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaChucVuNavigation)
                .AsQueryable()
                .FirstOrDefaultAsync(c => c.MaNhanVien == maNhanVien);
            if (cc == null)
            {
                return NotFound();
            }

            ViewBag.PhongBans = _context.PhongBans.ToList();
            
            ViewBag.ChucVus = _context.ChucVus.ToList();
            return View(cc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit(int maNhanVien, [Bind("ChamCongId ,MaNhanVien,HoTen,MaPhongBan,MaChucVu,NgayGioVao,NgayGioRa,TrangThai,GhiChu")] ChamCong cc)
        {
            if (maNhanVien != cc.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCc = await _context.ChamCongs.FindAsync(cc.ChamCongId);
                    if (existingCc == null)
                    {
                        return NotFound();
                    }

                    
                    existingCc.NgayGioVao = cc.NgayGioVao;
                    existingCc.NgayGioRa = cc.NgayGioRa;
                    existingCc.TrangThai = cc.TrangThai;
                    existingCc.GhiChu = cc.GhiChu;

                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamCongExists(cc.ChamCongId)) 
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.PhongBans = _context.PhongBans.ToList();
            
            ViewBag.ChucVus = _context.ChucVus.ToList();

            return View(cc);
        }

        private bool ChamCongExists(int id)
        {
            return _context.ChamCongs.Any(e => e.ChamCongId == id);
        }

    }
}
