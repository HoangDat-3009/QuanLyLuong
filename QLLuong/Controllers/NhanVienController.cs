using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;
using QLLuong.Models.Authentication;
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
    /* public IActionResult Index(string searchString)
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
     }*/
    [Authentication]
    public async Task<IActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 10)
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
    [Authentication]
    public IActionResult Create()
    {
        // Fetch the last MaNhanVien
        var lastNhanVien = _context.NhanViens.OrderByDescending(nv => nv.MaNhanVien).FirstOrDefault();
        int newMaNhanVien = (lastNhanVien != null) ? lastNhanVien.MaNhanVien + 1 : 1;

        // Initialize ViewBag properties
        ViewBag.PhongBans = GetPhongBans();
        ViewBag.ChucVus = GetChucVus();
        ViewBag.TrinhDos = GetTrinhDos();
        ViewBag.ChuyenMons = GetChuyenMons();
        ViewBag.HeSos = GetHeSos();
        ViewBag.DanTocs = GetDanTocs();

        // Pass the new MaNhanVien to the view
        var model = new NhanVien { MaNhanVien = newMaNhanVien };
        return View(model);
    }


    // POST: NhanVien/Create
    [HttpPost]
    public IActionResult Create(NhanVien nhanVien)
    {
        if (ModelState.IsValid)
        {
            _context.NhanViens.Add(nhanVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Reinitialize ViewBag properties in case of validation errors
        ViewBag.PhongBans = GetPhongBans();
        ViewBag.ChucVus = GetChucVus();
        ViewBag.TrinhDos = GetTrinhDos();
        ViewBag.ChuyenMons = GetChuyenMons();
        ViewBag.HeSos = GetHeSos();
        ViewBag.DanTocs = GetDanTocs();

        return View(nhanVien);
    }

    [Authentication]
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
    [Authentication]
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
    [Authentication]
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
                TempData["ModalMessage"] = "Cập nhật thông tin thành công!";
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
    [Authentication]
    public IActionResult Delete(int maNhanVien)
    {
        var nhanVien = _context.NhanViens.Find(maNhanVien);
        if (nhanVien == null)
        {
            return NotFound();
        }
        return View(nhanVien);
    }

    [Authentication]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int maNhanVien)
    {
        var nhanVien = await _context.NhanViens.FindAsync(maNhanVien);
        if (nhanVien == null)
        {
            return NotFound();
        }

		nhanVien.IsDeleted = true;
		await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }





    private bool NhanVienExists(int id)
    {
        return _context.NhanViens.Any(e => e.MaNhanVien == id);
    }
    private List<PhongBan> GetPhongBans()
    {
        return _context.PhongBans.ToList();
    }

    private List<ChucVu> GetChucVus()
    {
        return _context.ChucVus.ToList();
    }

    private List<TrinhDo> GetTrinhDos()
    {
        return _context.TrinhDos.ToList();
    }

    private List<ChuyenMon> GetChuyenMons()
    {
        return _context.ChuyenMons.ToList();
    }

    private List<HeSo> GetHeSos()
    {
        return _context.HeSos.ToList();
    }

    private List<DanToc> GetDanTocs()
    {
        return _context.DanTocs.ToList();
    }
}
