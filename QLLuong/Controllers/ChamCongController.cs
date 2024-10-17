using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using System;
using Microsoft.EntityFrameworkCore;
using QLLuong.Models;
using System.Data.SqlTypes;

namespace QLLuong.Controllers
{
    public class ChamCongController : Controller
    {

        private readonly QLNhanVienContext _context;

        public ChamCongController(QLNhanVienContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            /*var chamCongs = await _context.ChamCong.ToListAsync();
            return View(chamCongs);*/
            if (_context.ChamCong == null)
            {
                return Problem("Entity set 'QLNhanVienContext.ChamCong' is null.");
            }

            try
            {
                var chamCongs = await _context.ChamCong.ToListAsync();
                return View(chamCongs);
            }
            catch (SqlNullValueException ex)
            {
                // Log lỗi
                return Problem($"Lỗi khi truy xuất dữ liệu: {ex.Message}");
            }
        }
    }
}
