using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
    public class PhongBanViewComponent:ViewComponent
    {
        QLLuongContext _context;
        List<PhongBan> _phongBans;

        public PhongBanViewComponent(QLLuongContext context)
        {
            _context = context;
            _phongBans = _context.PhongBans.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderPhongban",_phongBans);
        }
    }
}
