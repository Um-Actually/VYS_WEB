using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VYS_WEB.Models;

namespace VYS_WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult tymy_jezdci ()
        {
            return View();
        }
        public IActionResult historie()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
