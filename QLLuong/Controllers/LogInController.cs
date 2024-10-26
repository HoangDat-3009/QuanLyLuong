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


        //login

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
                    
                    if (u.MaQuyen ==1)
                    {
                        HttpContext.Session.SetString("Username", u.Username.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Username", u.Username.ToString());
                        return RedirectToAction("Index", "HomeStaff");
                    }
                    
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

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return RedirectToAction("Index","LogIn");
        }

    }
}

