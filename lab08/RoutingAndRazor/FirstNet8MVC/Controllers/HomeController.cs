using System.Diagnostics;
using FirstNet8MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstNet8MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static readonly Random random = new Random();
        // property for tests
        public int RandomNumber { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            RandomNumber = random.Next(0, 1000);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPage()
        {
            ViewBag.Message = "My first page in MVC";
            ViewBag.ValueX = 1234;
            ViewBag.ValueText = "text value";
            return View();
        }
        public IActionResult MyPage2(int number, string name, string other)
        {
            ViewBag.Message = "Parametric page number=" + number + " name=" +
                  name + " , other=" + other;
            return View("MyPage");
        }

        [Route("M3/{no}/{word},{something}")]
        public IActionResult MyPage3(int no, string word, string something)
        {
            ViewBag.Message = $"Page with local routing rule {nameof(no)}={no}" +
                   $" {nameof(word)}={word}, {nameof(something)}={something}";
            return View("MyPage");
        }

        public IActionResult ViewDataProbe()
        {
            ViewData["Message"] = "ViewDataProbe";
            List<string> colors = new List<string>();
            colors.Add("red");
            colors.Add("green");
            colors.Add("blue");

            // the ViewData object is part of the Controller object
            ViewData["listColors"] = colors;
            ViewData["dateNow"] = DateTime.Now;
            ViewData["name"] = "Dariusz";
            ViewData["age"] = 20;

            // the result of the View () method returned as the result of this method
            return View("ViewDataProbe");
            //return View("ViewBagProbe");
        }

        public IActionResult ViewBagProbe()
        {
            ViewBag.Message = "ViewBagProbe";
            List<string> colors = new List<string>();
            colors.Add("red");
            colors.Add("green");
            colors.Add("blue");

            // the ViewBag object is part of the Controller object
            ViewBag.listColors = colors;
            ViewBag.dateNow = DateTime.Now;
            ViewBag.name = "Dariusz";
            ViewBag.age = 20;

            //return View("ViewDataProbe");
            return View("ViewBagProbe");

        }

        public IActionResult AllDataProbe()
        {
            ViewBag.random = RandomNumber;
            // if we wanted to read the TempData value in Action
            // var message = TempData["error"];
            ViewData["name"] = "Dariusz";
            // I don't set ViewData ["age"] so as not to overwrite it
            return View();
        }

        public IActionResult AllDataProbeRedirect()
        {
            ViewBag.random = RandomNumber;
            TempData["random"] = RandomNumber;
            // this data will be transferred
            TempData["error"] = $"error 433222 (from {nameof(RedirectToAction)})";
            // this data will be deleted during redirect
            ViewData["age"] = 90;
            return RedirectToAction("AllDataProbe");
        }

        public IActionResult TestJS()
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
