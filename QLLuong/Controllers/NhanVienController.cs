using Microsoft.AspNetCore.Mvc;
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
        var nhanViens = from nv in _context.NhanViens
                        select nv;

        if (!string.IsNullOrEmpty(searchString))
        {
            nhanViens = nhanViens.Where(s => s.MaNhanVien.ToString().Equals(searchString) 
            ||(s.HoTen != null && s.HoTen.Contains(searchString)));
        }
        ViewBag.PhongBans = _context.PhongBans.ToList();
        ViewBag.TrinhDos = _context.TrinhDos.ToList();
        ViewBag.ChucVus = _context.ChucVus.ToList();
        ViewBag.HeSos = _context.HeSos.ToList();
        ViewBag.DanTocs = _context.DanTocs.ToList();
        ViewBag.ChuyenMons = _context.ChuyenMons.ToList();
        return View(nhanViens.ToList());
    }

    public IActionResult NhanVienByPhongBan(int mid)
    {
        if(mid == 0)
        {
            return View("Index");
        }
        
        var nhanViens = _context.NhanViens.Where(nv => nv.MaPhongBan == mid).ToList();
        ViewBag.TrinhDos = _context.TrinhDos.ToList();
        ViewBag.ChucVus = _context.ChucVus.ToList();
        ViewBag.HeSos = _context.HeSos.ToList();
        ViewBag.DanTocs = _context.DanTocs.ToList();
        ViewBag.ChuyenMons = _context.ChuyenMons.ToList();
        return PartialView("NhanVienTable", nhanViens);
    }

    // Edit action
    public async Task<IActionResult> Edit(int maNhanVien)
    {
        var nhanVien = await _context.NhanViens.FindAsync(maNhanVien);
        if (nhanVien == null)
        {
            return NotFound();
        }

        ViewBag.PhongBans = _context.PhongBans.ToList();
        ViewBag.TrinhDos = _context.TrinhDos.ToList();
        ViewBag.ChucVus = _context.ChucVus.ToList();
        ViewBag.HeSos = _context.HeSos.ToList();
        ViewBag.DanTocs = _context.DanTocs.ToList();
        ViewBag.ChuyenMons = _context.ChuyenMons.ToList();
        return View(nhanVien);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int maNhanVien, [Bind("MaNhanVien,HoTen,NgaySinh,GioiTinh,NoiSinh,MaPhongBan,MaChucVu,MaTrinhDo,MaChuyenMon," +
        "DiaChi,DienThoai,MaHeSo,Cccd,TaiKhoanNganHang,SoTaiKhoanNganHang")] NhanVien nhanVien)
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

        ViewBag.PhongBans = _context.PhongBans.ToList();
        ViewBag.TrinhDos = _context.TrinhDos.ToList();
        ViewBag.ChucVus = _context.ChucVus.ToList();
        ViewBag.HeSos = _context.HeSos.ToList();
        ViewBag.DanTocs = _context.DanTocs.ToList();
        ViewBag.ChuyenMons = _context.ChuyenMons.ToList();
        return View(nhanVien);
    }

    // Delete action
    public IActionResult Delete(int maNhanVien)
    {
        var nhanVien = _context.NhanViens.Find(maNhanVien);
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
        var nhanVien = await _context.NhanViens.FindAsync(maNhanVien);
        if (nhanVien != null)
        {
            var nhanVienDaNghiViec = new NhanVienDaNghiViec
            {
                MaNhanVien = nhanVien.MaNhanVien,
                HoTen = nhanVien.HoTen,
                GioiTinh = nhanVien.GioiTinh,
                NgaySinh = nhanVien.NgaySinh,
                NoiSinh = nhanVien.NoiSinh,
                NgayVaoCongTy = nhanVien.NgayVaoCongTy,
                MaDanToc = nhanVien.MaDanToc,
                MaChucVu = nhanVien.MaChucVu,
                MaPhongBan = nhanVien.MaPhongBan,
                MaTrinhDo = nhanVien.MaTrinhDo,
                MaChuyenMon = nhanVien.MaChuyenMon,
                DiaChi = nhanVien.DiaChi,
                DienThoai = nhanVien.DienThoai,
                MaHeSo = nhanVien.MaHeSo,
                Cccd = nhanVien.Cccd,
                TaiKhoanNganHang = nhanVien.TaiKhoanNganHang,
                SoTaiKhoanNganHang = nhanVien.SoTaiKhoanNganHang,
                NgayNghiViec = DateTime.Now
            };

            _context.NhanVienDaNghiViecs.Add(nhanVienDaNghiViec);
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }



    private bool NhanVienExists(int id)
    {
        return _context.NhanViens.Any(e => e.MaNhanVien == id);
    }
}
