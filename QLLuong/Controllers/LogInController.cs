using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;
using System.Diagnostics;

namespace QLLuong.Controllers
{
    public class LogInController : Controller
    {
 /*       private readonly ILogger<LogInController> _logger;

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //login
        QlluongContext db = new QlluongContext();
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Index(UserLogin users)
        {
            
            if (HttpContext.Session.GetString("UserName") == null)
            {
                /*var u = db.UserLogin.Where(x => x.UserName.Equals(users.UserName) && x.UserPassword.Equals(users.UserPassword)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.UserName.ToString());
                    return RedirectToAction("Index", "Login");
                }*/
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
            }

            return View("Login");
        }


        //logout


    }
}
