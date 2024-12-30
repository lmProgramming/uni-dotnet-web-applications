using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace RazorCookies.Pages.Game
{
    public class GameModel : PageModel
    {
        private const string SessionKeyN = "N";
        private const string SessionKeyChosenValue = "ChosenValue";
        private const string SessionKeyGuesses = "Guesses";

        public string Result { get; set; } = "";
        public string TextColor { get; set; } = "#000000";
        public string FontWeight { get; set; } = "normal";

        private int N
        {
            get => HttpContext.Session.GetInt32(SessionKeyN) ?? 100;
            set => HttpContext.Session.SetInt32(SessionKeyN, value);
        }

        private int ChosenValue
        {
            get => HttpContext.Session.GetInt32(SessionKeyChosenValue) ?? ResetAndGetNewValue();
            set => HttpContext.Session.SetInt32(SessionKeyChosenValue, value);
        }

        private List<int> Guesses
        {
            get => GetGuesses();
            set => HttpContext.Session.SetString(SessionKeyGuesses, System.Text.Json.JsonSerializer.Serialize(value));
        }

        private List<int> GetGuesses()
        {
            var guesses = HttpContext.Session.GetString(SessionKeyGuesses);
            if (guesses == null)
            {
                return new List<int>();
            }

            return System.Text.Json.JsonSerializer.Deserialize<List<int>>(guesses)!;
        }

        public void OnGet()
        {
            Result = "Set a range, draw a number, and start guessing!";
        }

        public IActionResult OnPostSet(int n)
        {
            if (n < 1)
            {
                Result = "Error: n must be at least 1.";
                TextColor = ToHex(Color.Red);
                FontWeight = "bold";
                return Page();
            }

            N = n;
            Reset();
            Result = $"Set range to <0, {n})";
            return Page();
        }

        public IActionResult OnPostDraw()
        {
            Reset();
            Result = $"Set new random number in range <0, {N})";
            return Page();
        }

        public IActionResult OnPostGuess(int guess)
        {
            var guesses = Guesses;
            guesses.Add(guess);
            Guesses = guesses;

            string guessesSequence = string.Join(',', guesses);
            int guessCount = guesses.Count;

            if (guess == ChosenValue)
            {
                Result = $"Congratulations! You've guessed {ChosenValue} in {guessCount} tries. New random number has been set. Sequence: {guessesSequence}";
                TextColor = ToHex(Color.DarkGreen);
                FontWeight = "bold";
                Reset();
                return Page();
            }

            double scaledDistance = Math.Abs(guess - ChosenValue) / (double)N * 2;
            TextColor = InterpolateColorClamped(Color.DarkGreen, Color.Red, scaledDistance);
            FontWeight = "normal";

            string scaleReminder = $" Your number was not in range from 0 to {N}.";

            var additionalInfo = $"{(guess < 0 ? scaleReminder : "")} Attempt: {guessCount}. Sequence: {guessesSequence}";

            if (guess < ChosenValue)
            {
                Result = $"Too small.{additionalInfo}";
                return Page();
            }

            Result = $"Too big.{additionalInfo}";
            return Page();
        }

        private string ToHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        private string InterpolateColorClamped(Color color1, Color color2, double fraction)
        {
            fraction = Math.Clamp(fraction, 0, 1);
            int r = (int)(color1.R + (color2.R - color1.R) * fraction);
            int g = (int)(color1.G + (color2.G - color1.G) * fraction);
            int b = (int)(color1.B + (color2.B - color1.B) * fraction);
            return ToHex(Color.FromArgb(r, g, b));
        }

        private void Reset()
        {
            var random = new Random();
            ChosenValue = random.Next(0, N);
            Guesses = new List<int>();
        }

        private int ResetAndGetNewValue()
        {
            Reset();
            return ChosenValue;
        }
    }
}
