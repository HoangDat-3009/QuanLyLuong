using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QLLuong.Areas.Staff.Controllers
{
    [Area("staff")]
    [Route("staff")]
    [Route("staff/homestaff")]
    public class HomeStaffController : Controller
    {
        // GET: HomeStaffController
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }


    }
}
