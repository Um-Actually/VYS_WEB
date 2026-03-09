using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VYS_WEB.Models;

namespace VYS_WEB.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register ()
        {
            return View();
        }
        public IActionResult Profil()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string username,string password, string passwordcheck)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewData["chyba"] = "Jméno nebo heslo nebylo zadáno";
                return View();
            }
            else if (password != passwordcheck)
            {
                ViewData["chyba"] = "Hesla se neshodují";
                return View();
            }
            else
            {
                return Redirect("/User/Login");
            }

        }
    }
}
