using AdityaSoftwares.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdityaSoftwares.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IEmailService _emailService = null;
        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public JsonResult SendMessage(string name,string email,int contact,string message)
        {
            EmailData em = new EmailData();

            em.EmailSubject = "test";
            em.EmailToName = name;
            em.EmailToId = email;
            em.EmailBody = message+contact;
            _emailService.SendEmail(em);
            var output = "Your message has been sent. Thank you!  " +name;
            return Json(output);
        }
    }
}