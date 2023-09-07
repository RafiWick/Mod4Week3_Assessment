using CommerceMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CommerceMvc.Controllers
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
            if (!Request.Cookies.ContainsKey("CurrentUser"))
            {
                Response.Cookies.Append("CurrentUser", "");
            }
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            return View();
        }

        public IActionResult Login()
        {
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(string currentUser)
        {
            Response.Cookies.Append("CurrentUser", currentUser);
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Append("CurrentUser", "");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}