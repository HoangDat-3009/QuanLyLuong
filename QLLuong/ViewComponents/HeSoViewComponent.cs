using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
	public class HeSoViewComponent : ViewComponent
	{
		QLLuongContext _context;
		List<HeSo> _heSos;

		public HeSoViewComponent(QLLuongContext context)
		{
			_context = context;
			_heSos = _context.HeSos.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderPhongban", _heSos);
		}
	}
}
