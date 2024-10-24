using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLLuong.Data;
using QLLuong.Models;

using QLLuong.Models.Authentication;

namespace QLLuong.Controllers
{
    public class LuongCB_BHController : Controller
    {
        private readonly QLLuongContext db;
        public LuongCB_BHController(QLLuongContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Edit(int id =1 )
        {
            var lcb = await db.LuongCoBanPhanTramBhs.FindAsync(id);
            if (lcb == null)
            {
                return NotFound();
            }

            ViewBag.LuongCoBanPhanTramBhs = await db.LuongCoBanPhanTramBhs.ToListAsync();
            return View(lcb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public async Task<IActionResult> Edit([Bind("MaLuongCoBanPhanTramBh,LuongCoBan,PhanTramBhyt,PhanTramBhtn,PhanTramBhxh")] LuongCoBanPhanTramBh lcb, int id = 1)
        {
            if (lcb.MaLuongCoBanPhanTramBh != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var exit = await db.LuongCoBanPhanTramBhs.FindAsync(id);
                    if (exit == null)
                    {
                        return NotFound();
                    }

                    exit.LuongCoBan = lcb.LuongCoBan;
                    exit.PhanTramBhtn = lcb.PhanTramBhtn;
                    exit.PhanTramBhyt = lcb.PhanTramBhyt;
                    exit.PhanTramBhxh = lcb.PhanTramBhxh;
                    db.Entry(exit).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    TempData["ModalMessage"] = "Thông tin đã được sửa thành công!";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Ghi log lỗi hoặc hiển thị chi tiết lỗi
                    Console.WriteLine(ex.Message); // Hoặc sử dụng một logger nếu có
                    throw;
                }

                //return RedirectToAction(nameof(Index));
            }

            ViewBag.LuongCoBanPhanTramBhs = await db.LuongCoBanPhanTramBhs.ToListAsync();
            return View(lcb);
        }
    }
}
