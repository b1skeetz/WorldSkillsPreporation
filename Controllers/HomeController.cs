using Microsoft.AspNetCore.Mvc;
using MyFirstAzureWebApp.Models;
using MyFirstAzureWebApp.Services;
using System.Diagnostics;
using System.Linq;

namespace MyFirstAzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            using (postgresContext db = new postgresContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return View("Success", new User()
                {
                    UserLogin = user.UserLogin,
                    UserPassword = user.UserPassword
                });
            }
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}