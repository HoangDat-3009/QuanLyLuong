using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
	public class ChuyenMonViewComponent : ViewComponent
	{
		QLLuongContext _context;
		List<ChuyenMon> _chuyenMons;

		public ChuyenMonViewComponent(QLLuongContext context)
		{
			_context = context;
			_chuyenMons = _context.ChuyenMons.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderPhongban", _chuyenMons);
		}
	}
}
