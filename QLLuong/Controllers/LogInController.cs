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
            
            ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
            return View(users);
        }


        //logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index","LogIn");
        }

    }
}

