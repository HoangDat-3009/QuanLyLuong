using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
	public class DanTocViewComponent : ViewComponent
	{
		QLLuongContext _context;
		List<DanToc> _danTocs;

		public DanTocViewComponent(QLLuongContext context)
		{
			_context = context;
			_danTocs = _context.DanTocs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderPhongban", _danTocs);
		}
	}
}
