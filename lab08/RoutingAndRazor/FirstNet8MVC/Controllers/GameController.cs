using Microsoft.AspNetCore.Mvc;

namespace RoutingAndRazor.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
