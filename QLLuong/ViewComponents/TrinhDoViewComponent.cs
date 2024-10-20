using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
	public class TrinhDoViewComponent : ViewComponent
	{
		QLLuongContext _context;
		List<TrinhDo> _trinhDos;

		public TrinhDoViewComponent(QLLuongContext context)
		{
			_context = context;
			_trinhDos = _context.TrinhDos.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderPhongban", _trinhDos);
		}
	}
}
