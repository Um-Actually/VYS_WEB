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
    }
}
