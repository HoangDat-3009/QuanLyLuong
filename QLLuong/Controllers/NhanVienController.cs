using Microsoft.AspNetCore.Mvc;
using QLLuong.Models;

namespace QLLuong.Controllers
{
    public class NhanVienController : Controller
    {
        private List<NhanVien> listNhanVien = new List<NhanVien>();
        public NhanVienController()
        {
            listNhanVien = new List<NhanVien>()
                {
                    new NhanVien()
                    {
                        MaNhanVien = 1, HoTen = "Tran Van A", DiaChi = "so 1 abc", NgaySinh = DateTime.Now
                    },
                    new NhanVien()
                    {
                        MaNhanVien = 2, HoTen = "Tran Van B", DiaChi = "so 2 abc", NgaySinh = DateTime.Now
                    }
                };
        }
        public IActionResult Index()
        {
            return View(listNhanVien);
        }
    }
}
