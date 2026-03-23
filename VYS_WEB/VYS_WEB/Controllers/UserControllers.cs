using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VYS_WEB.Models;
using VYS_WEB.Data;
using System.Linq;

namespace VYS_WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

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

            if (_db.Users.Any(u => u.Name == username))
            {
                ViewData["chyba"] = "Uživatel s tímto jménem již existuje";
                return View();
            }

            var user = new User
            {
                Name = username,
                Password = password
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return Redirect("/User/Login");

        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewData["chyba"] = "Jméno nebo heslo nebylo zadáno";
                return View();
            }

            User? prihlasenyUzivatel = _db
                .Users
                .Where(u => u.Name == username)
                .FirstOrDefault();

            if (prihlasenyUzivatel == null)
            {
                ViewData["chyba"] = "Neznámý uživatel.";

                return View();
            }

            if (prihlasenyUzivatel.Password != password)
            {
                ViewData["chyba"] = "Chybné heslo.";

                return View();
            }

            TempData["username"] = prihlasenyUzivatel.Name;
            return RedirectToAction("Profil");
        }
        public IActionResult Profile()
        {
            return View();
        }

    }
    
}
