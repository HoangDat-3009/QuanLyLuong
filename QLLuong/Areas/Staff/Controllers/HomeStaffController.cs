using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLLuong.Controllers;

namespace QLLuong.Areas.Staff.Controllers
{
    [Area("staff")]
    [Route("homestaff")]
    [Route("staff/homestaff")]
    public class HomeStaffController : Controller
    {
        private readonly ILogger<HomeStaffController> _logger;

        public HomeStaffController(ILogger<HomeStaffController> logger)
        {
            _logger = logger;
        }
        // GET: HomeStaffController
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            return View();
        }


    }
}
