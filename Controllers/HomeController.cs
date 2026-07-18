using FlipKart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlipKart.Controllers
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            // Very simple demo authentication: accept any non-empty email/password
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                // Optionally show an error - for now, redisplay the login view
                ViewBag.Error = "Please provide both email and password.";
                return View();
            }

            // Store the user email in TempData so Index view can show a personalized message
            TempData["UserEmail"] = email;

            // Redirect to Index after successful "login"
            return RedirectToAction("Index");
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
    }
}
