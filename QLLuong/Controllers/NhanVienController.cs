﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;
using System.Linq;
using System.Threading.Tasks;

public class NhanVienController : Controller
{
    private readonly QLLuongContext _context;

    public NhanVienController(QLLuongContext context)
    {
        _context = context;
    }

    // Existing Index action
    public IActionResult Index(string searchString)
    {
        var nhanViens = from nv in _context.NhanVien
                        select nv;

        if (!string.IsNullOrEmpty(searchString))
        {
            nhanViens = nhanViens.Where(s => s.MaNhanVien.ToString().Contains(searchString) || s.HoTen.Contains(searchString));
        }

        return View(nhanViens.ToList());
    }

    // Edit action
    public async Task<IActionResult> Edit(int maNhanVien)
    {
        var nhanVien = await _context.NhanVien.FindAsync(maNhanVien);
        if (nhanVien == null)
        {
            return NotFound();
        }

        ViewBag.PhongBans = _context.PhongBan.ToList();
        return View(nhanVien);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int maNhanVien, [Bind("MaNhanVien,HoTen,NgaySinh,GioiTinh,NoiSinh,MaPhongBan,MaChucVu,MaTrinhDo,MaChuyenMon,DiaChi,DienThoai,MaHeSo")] NhanVien nhanVien)
    {
        if (maNhanVien != nhanVien.MaNhanVien)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(nhanVien);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(nhanVien.MaNhanVien))
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

        ViewBag.PhongBans = _context.PhongBan.ToList();
        return View(nhanVien);
    }

    // Delete action
    public IActionResult Delete(int maNhanVien)
    {
        var nhanVien = _context.NhanVien.Find(maNhanVien);
        if (nhanVien == null)
        {
            return NotFound();
        }
        return View(nhanVien);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int maNhanVien)
    {
        var nhanVien = await _context.NhanVien.FindAsync(maNhanVien);
        if (nhanVien != null)
        {
            _context.NhanVien.Remove(nhanVien);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool NhanVienExists(int id)
    {
        return _context.NhanVien.Any(e => e.MaNhanVien == id);
    }
}
