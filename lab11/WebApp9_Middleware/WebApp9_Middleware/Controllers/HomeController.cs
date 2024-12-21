using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp9_Middleware.Models;
using WebApp9_Middleware.Services;

namespace WebApp9_Middleware.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        public HomeController(UptimeService up)
        {
            uptime = up;
        }

        public IActionResult Index()
        {
            TempData["Message"] = "The uptime";
         TempData["Uptime"] = $"{uptime.Uptime}ms";
            return View();
        }
    }
}
