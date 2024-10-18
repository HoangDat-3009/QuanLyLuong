using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.Controllers
{
    public class ChamCongController : Controller
    {
        private readonly QlluongContext _context;

        public ChamCongController(QlluongContext context)
        {
            _context = context;
        }

        // GET: ChamCong
        public async Task<IActionResult> Index()
        {
            var qlluongContext = _context.ChamCongs
            .Include(c => c.MaNhanVienNavigation)
            .ThenInclude(nv => nv.MaPhongBanNavigation)
            .Include(c => c.MaNhanVienNavigation)
            .ThenInclude(nv => nv.MaChucVuNavigation);

            return View(await qlluongContext.ToListAsync());
        }

        // GET: ChamCong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var chamCong = await _context.ChamCongs
                .Include(c => c.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);*/
            var chamCong = await _context.ChamCongs
            .Include(c => c.MaNhanVienNavigation)
            .ThenInclude(n => n.MaPhongBanNavigation)
            .Include(c => c.MaNhanVienNavigation)
            .ThenInclude(n => n.MaChucVuNavigation)
            .FirstOrDefaultAsync(m => m.ChamCongId == id);
            


            if (chamCong == null)
            {
                return NotFound();
            }

            return View(chamCong);
        }



        // GET: ChamCong/Create
        public IActionResult Create()
        {
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien");
            return View();
        }

        // POST: ChamCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,NgayGioVao,NgayGioRa,TrangThai,GhiChu")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", chamCong.MaNhanVien);
            return View(chamCong);
        }

        // GET: ChamCong/Edit/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNhanVien,NgayGioVao,NgayGioRa,TrangThai,GhiChu")] ChamCong chamCong)
        {
            if (id != chamCong.MaNhanVien)
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
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", chamCong.MaNhanVien);
            return View(chamCong);
        }

        // GET: ChamCong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCongs
                .Include(c => c.MaNhanVienNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (chamCong == null)
            {
                return NotFound();
            }

            return View(chamCong);
        }

        // POST: ChamCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async    Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamCong = await _context.ChamCongs.FindAsync(id);
            if (chamCong != null)
            {
                _context.ChamCongs.Remove(chamCong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamCongExists(int id)
        {
            return _context.ChamCongs.Any(e => e.MaNhanVien == id);
        }
    }
}
