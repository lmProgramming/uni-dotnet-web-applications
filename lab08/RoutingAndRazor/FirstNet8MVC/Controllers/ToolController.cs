using Microsoft.AspNetCore.Mvc;

namespace RoutingAndRazor.Controllers
{
    /*
     Stworzyć w aplikacji internetowej MVC kontroler ToolController, który
     rozwiązuje równanie kwadratowe ax2+bx+c=0 (analogicznie jak dla listy 5,
     zadanie 1). Współczynniki równania mają być podane w adresie dla akcji Solve,
     czyli przykładowo 2x2+3x+4=0 ma być podane jako:
     http://localhost:12345/Tool/Solve/2/3/4
     Zastosować różne kolory/fonty/itp. na stronie w zależności od tego, czy są dwa,
     jedno, brak rozwiązań czy też równanie jest tożsamościowe. Najlepiej
     wykorzystać do tego klasy HTML oraz reguły i style CSS. Starać się nie
     korzystać z możliwości silnika Razor (oprócz przekazania danych do widoku, np.
     nazwa klasy CSS), czyli wszelkie przetwarzanie powinno być wykonane w ramach
     kodu C# akcji kontrolera.
    */
    public class ToolController : Controller
    {
        [Route("Tool/Solve/{a}/{b}/{c}")]
        public IActionResult Solve(double a, double b, double c)
        {
            var quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);
            QuadraticEquation.SolutionsCount solutionsCount;
            var solutions = quadraticEquation.CalculateSolutions(out solutionsCount);
            var result = quadraticEquation.GetPrettySolutions(solutions, solutionsCount);
            ViewBag.Result = result;
            int solutionsCountInt;
            switch (solutionsCount)
            {
                case QuadraticEquation.SolutionsCount.Zero:
                    solutionsCountInt = 0;
                    break;
                case QuadraticEquation.SolutionsCount.One:
                    solutionsCountInt = 1;
                    break;
                case QuadraticEquation.SolutionsCount.Two:
                    solutionsCountInt = 2;
                    break;
                default:
                    solutionsCountInt = -1;
                    break;
            }
            
            ViewBag.ResultCount = solutionsCountInt;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
