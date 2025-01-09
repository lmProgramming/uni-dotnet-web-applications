using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp9_IdentityStudent.Models;

namespace WebApp9_IdentityStudent.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ForAdmin()
        {
            ViewData["Info"] = "For Admin";
            return View("Info");
        }
        [AllowAnonymous]
        public IActionResult ForAll()
        {
            ViewData["Info"] = "For All";
            return View("Info");
        }
        [Authorize]
        public IActionResult ForLogIn()
        {
            ViewData["Info"] = "For Log In";
            return View("Info");
        }

        [Authorize(Roles = "Admin, Dean")]
        public IActionResult ForAdminOrDean()
        {
            ViewData["Info"] = "For Admin or Dean";
            return View("Info");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
