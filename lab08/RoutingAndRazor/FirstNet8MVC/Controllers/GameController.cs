using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace RoutingAndRazor.Controllers
{
    public class GameController : Controller
    {
        private static int n = 100;
        private static int chosenRandomValue;
        private static int guessCount;

        static GameController()
        {
            DrawNewNumber();
        }

        [Route("Set,{n}")]
        public IActionResult Set(int n)
        {
            GameController.n = n;
            DrawNewNumber();
            return Content($"Zakres ustawiony na {n}. Wylosowano nową liczbę.");
        }

        [Route("Draw")]
        public IActionResult Draw()
        {
            DrawNewNumber();
            return Content("Wylosowano nową liczbę.");
        }

        [Route("Guess,{guess}")]
        public IActionResult Guess(int guess)
        {
            guessCount++;
            if (guess == chosenRandomValue)
            {
                ViewBag.Result = $"Gratulacje! Zgadłeś liczbę {chosenRandomValue} w {guessCount} próbach. Została wylosowana nowa liczba.";
                ViewBag.Color = ToHex(Color.DarkGreen);
                ViewBag.FontWeight = "bold";
                DrawNewNumber();
                return View();
            }

            double scaledDistance = Math.Abs(guess - chosenRandomValue) / (double)n * 2;

            string color = InterpolateColorClamped(Color.DarkGreen, Color.Red, scaledDistance);
            ViewBag.Color = color;
            ViewBag.FontWeight = "normal";

            var scaleReminder = $" Przypominam, że zakres jest od zera do {n}.";

            if (guess < chosenRandomValue)
            {
                ViewBag.Result = $"Za mała liczba.{(guess < 0 ? scaleReminder : "")} Próba: {guessCount}";
                return View();
            }

            ViewBag.Result = $"Za duża liczba.{(guess >= n ? scaleReminder : "")} Próba: {guessCount}";
            return View();
        }

        private static String ToHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        private static string InterpolateColorClamped(Color color1, Color color2, double fraction)
        {
            fraction = Math.Clamp(fraction, 0, 1);
            int r = (int)(color1.R + (color2.R - color1.R) * fraction);
            int g = (int)(color1.G + (color2.G - color1.G) * fraction);
            int b = (int)(color1.B + (color2.B - color1.B) * fraction);
            return ToHex(Color.FromArgb(r, g, b));
        }

        private static void DrawNewNumber()
        {
            var random = new Random();
            chosenRandomValue = random.Next(0, n);
            guessCount = 0;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
