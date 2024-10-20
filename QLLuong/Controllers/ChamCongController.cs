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
        private int pageSize = 12;

        [HttpGet]
        public IActionResult Index(string searchString, int page = 1)
        {
            var chamcongs = _context.ChamCongs
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaPhongBanNavigation)
                .Include(c => c.MaNhanVienNavigation)
                .ThenInclude(nv => nv.MaChucVuNavigation)
                .AsQueryable();


            // tim kiem
            if (!string.IsNullOrEmpty(searchString))
            {
                chamcongs = chamcongs.Where(c => c.MaNhanVienNavigation.HoTen.ToLower().Contains(searchString.ToLower())||c.MaNhanVien.ToString().Contains(searchString));
            }

            //phan trang
            page = page < 1 ? 1 : page;

            int skip = (page - 1) * pageSize;


            var paginatedChamCongs = chamcongs.Skip(skip).Take(pageSize).ToList();

 
            int totalRecords = chamcongs.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            ViewBag.PageIndex = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedChamCongs);
        }




        // GET: ChamCong/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCongs.FindAsync(id);
            if (chamCong == null)
            {
                return NotFound();
            }
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", chamCong.MaNhanVien);
            return View(chamCong);
        }

        // POST: ChamCong/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNhanVien,NgayGioVao,NgayGioRa,TrangThai,GhiChu")] ChamCong chamCong)
        {
            /*if (id != chamCong.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamCongExists(chamCong.MaNhanVien))
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
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", chamCong.MaNhanVien);*/
            return View(chamCong);
        }

        private bool ChamCongExists(int id)
        {
            return _context.ChamCongs.Any(e => e.MaNhanVien == id);
        }
    }
}
