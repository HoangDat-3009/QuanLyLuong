using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
	public class NhanVienComponent : ViewComponent
	{
		QLLuongContext _context;
		List<NhanVien> _nhanViens;

		public NhanVienComponent(QLLuongContext context)
		{
			_context = context;
			_nhanViens = _context.NhanViens.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderNhanVien", _nhanViens);
		}
	}
}
