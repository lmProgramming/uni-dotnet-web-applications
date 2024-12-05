using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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

            string textColor = solutionsCount switch
            {
                QuadraticEquation.SolutionsCount.Zero => "red",
                QuadraticEquation.SolutionsCount.One => "orange",
                QuadraticEquation.SolutionsCount.Two => "green",
                QuadraticEquation.SolutionsCount.Infinity => "purple",
                _ => "black"
            };
            ViewBag.ResultColor = textColor;

            string fontWeight = solutionsCount switch
            {
                QuadraticEquation.SolutionsCount.Zero => "bold",
                QuadraticEquation.SolutionsCount.One => "normal",
                QuadraticEquation.SolutionsCount.Two => "normal",
                QuadraticEquation.SolutionsCount.Infinity => "normal",
                _ => "normal"
            };
            ViewBag.ResultFontWeight = fontWeight;

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
