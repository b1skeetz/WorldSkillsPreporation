using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MyFirstAzureWebApp.Models;
using MyFirstAzureWebApp.Services;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace MyFirstAzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment hostEnv;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnv)
        {
            _logger = logger;
            this.hostEnv = hostEnv;
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
        public IActionResult Login()
        {
            return View();
        }
        /*public IActionResult Search()
        {
            return View();
        }*/
        
        public IActionResult Search(string userLogin)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = db.Users.Where(u => EF.Functions.Like(u.UserLogin, "%" + userLogin + "%")).ToList();
                return View(users);
            }
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var UsersList = db.Users.ToList();
                foreach (var User in UsersList)
                {
                    if (User.UserLogin == user.UserLogin && User.UserPassword == user.UserPassword)
                    {
                        return RedirectToAction("Success");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                int buf = db.SaveChanges();
                if (buf > 0)
                {
                    return RedirectToAction("Register");
                }         
            }
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Success(int temp)
        {
            return RedirectToAction("Timer");
        }

        public IActionResult Timer()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Timer(int temp)
        {
            return RedirectToAction("Success");
        }
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Upload(IFormFile file)
        {
            var fileDic = "Files";
            string filePath = Path.Combine(hostEnv.WebRootPath, fileDic);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileName = file.FileName;
            filePath = Path.Combine(filePath, fileName);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }
            return RedirectToAction("DragDrop");
        }

        public IActionResult DragDrop()
        {
            var fileDic = "Files";
            string filePath = Path.Combine(hostEnv.WebRootPath, fileDic);
            var files = Directory.GetFiles(filePath).Select(f => Path.GetFileName(f));
            ViewBag.Files = files;
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1)});

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Email() // deleted from project (Email view is absent)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Email(string recipientEmail, string emailSubject, string emailBody) // deleted from project (Email view is absent)
        { 
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 25))
                {
                    // Укажите адрес электронной почты и пароль для аутентификации на сервере POP3 Yandex
                    smtpClient.Credentials = new NetworkCredential("emailFrom@yandex.ru", "password");
                    smtpClient.EnableSsl = true;

                    // Создайте сообщение
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("emailFrom@yandex.ru");
                        mailMessage.To.Add(new MailAddress(recipientEmail));
                        mailMessage.Subject = emailSubject;
                        mailMessage.Body = emailBody;

                        // Отправьте сообщение
                        smtpClient.Send(mailMessage);
                        ViewBag.Message = "Success/Успех";
                    }
                }

                
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error/Ошибка: {ex.Message}";
            }

            return View();
        }
    }
}