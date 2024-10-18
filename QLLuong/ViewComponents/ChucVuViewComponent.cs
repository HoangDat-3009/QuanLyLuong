using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
	public class ChucVuViewComponent : ViewComponent
	{
		QLLuongContext _context;
		List<ChucVu> _chucVus;

		public ChucVuViewComponent(QLLuongContext context)
		{
			_context = context;
			_chucVus = _context.ChucVus.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderPhongban", _chucVus);
		}
	}
}
