using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLLuong.Data;
using QLLuong.Models;
using System.Diagnostics;

namespace QLLuong.Controllers
{
    public class LogInController : Controller
    {
        private readonly QLLuongContext _context;

        public LogInController(QLLuongContext context)
        {
            _context = context;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/

        //login
       /* QLLuongContext db = new QLLuongContext();*/
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public ActionResult Index(UserLogin users)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = _context.UserLogins.Where(x => x.Username.Equals(users.Username) && x.Userpassword.Equals(users.Userpassword)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
            }

            return View(users);
        }





        /*public IActionResult Login(UserLogin ulog)
        {
            if (ModelState.IsValid)
            {
                var users = db.UserLogins.Where(a => a.Username.Equals(ulog.Username) && a.Userpassword.Equals(ulog.Userpassword)).FirstOrDefault();
                if (users != null)
                {
                    HttpContext.Session.SetString("Username", users.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View(ulog);

        }

        [Authorize]
        public IActionResult SecurePage()
        {

            if (HttpContext.Session.GetString("Username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }*/

        //logout


    }
}

/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using QLLuong.Models;

public class LogInController : Controller
{

    private readonly UserLogin _dummyUser = new UserLogin { Username = "admin", Userpassword = "password" };
*//*    public IActionResult Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return RedirectToAction("Login", "LogIn");
        }

        return View();
    }*//*
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserLogin user)
    {
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Userpassword))
        {
            ViewBag.Message = "Tên đăng nhập và mật khẩu không được để trống";
            return View("Index"); 
        }

        if (user.Username == _dummyUser.Username && user.Userpassword == _dummyUser.Userpassword)
        {
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Message = "Thông tin đăng nhập không hợp lệ";
        return View("Index");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}*/
