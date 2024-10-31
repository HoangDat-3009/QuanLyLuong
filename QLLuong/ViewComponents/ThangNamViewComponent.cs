using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;

namespace QLLuong.ViewComponents
{
    public class ThangNamViewComponent : ViewComponent
    {
        QLLuongContext db;
        List<MonthYearViewModel> monthsAndYears;
        public ThangNamViewComponent(QLLuongContext context)
        {
            db = context;
            monthsAndYears = db.LuongCus
            .Select(l => new MonthYearViewModel { Thang = l.Thang, Nam = l.Nam })
            .Distinct()
            .OrderBy(l => l.Nam)
            .ThenBy(l => l.Thang)
            .ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderThangnam", monthsAndYears);
        }
    }
}
