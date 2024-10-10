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
                    Id = 1,Name = "Tran Van A",Email = " abc@gmail.com",Address="so 1 abc",DateOfBirth=new DateTime()
                },
                new NhanVien()
                {
                    Id = 2,Name = "Tran Van B",Email = " abcd@gmail.com",Address="so 2 abc",DateOfBirth=new DateTime()
                }
            };
        }
        public IActionResult Index()
        {
            return View(listNhanVien);
        }
    }
}
