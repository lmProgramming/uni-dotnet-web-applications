namespace Program
{
    public class QuadraticEquationSolver
    {
        public enum SolutionsCount
        {
            Zero,
            One,
            Two,
            Infinity,
        }
        public double A;
        public double B;
        public double C;

        public QuadraticEquationSolver(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double[] CalculateSolutions(out SolutionsCount solutionsCount)
        {
            if (A == 0)
            {
                if (B == 0)
                {
                    if (C == 0)
                    {
                        solutionsCount = SolutionsCount.Infinity;
                        return [];
                    }
                    else
                    {
                        solutionsCount = SolutionsCount.Zero;
                        return [];
                    }
                }

                solutionsCount = SolutionsCount.One;
                return [-C / B];
            }

            double delta = B * B - 4 * A * C;
            if (delta < 0)
            {
                solutionsCount = SolutionsCount.Zero;
                return [];
            }
            if (delta == 0)
            {
                solutionsCount = SolutionsCount.One;
                return [-B / (2 * A)];
            }

            solutionsCount = SolutionsCount.Two;
            return
            [
                (-B - Math.Sqrt(delta)) / (2 * A),
                (-B + Math.Sqrt(delta)) / (2 * A)
            ];
        }

        public string CalculatePrettySolutions()
        {
            SolutionsCount solutionsCount;

            double[] solutions = CalculateSolutions(out solutionsCount);

            switch (solutionsCount)
            {
                case SolutionsCount.Zero:
                    return "Brak rozwiązań";
                case SolutionsCount.One:
                    return $"Jedno rozwiązanie: {solutions[0]}";
                case SolutionsCount.Two:
                    return $"Dwa rozwiązania: {solutions[0]} i {solutions[1]}";
                case SolutionsCount.Infinity:
                    return "Nieskończenie wiele rozwiązań";
                default:
                    return "Nieznana ilość rozwiązań";
            }
        }

        public override string ToString()
        {
            return $"{A.ToString()}*x^2 + {B.ToString()}*x + {C.ToString()}";
        }
    }

    class Coefficient
    {
        public string Name;
        public double Value;

        public Coefficient(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Czy chcesz przetestować algorytm? y/n");
            if (Console.ReadLine() == "y")
            {
                Test();
            }
            while (true)
            {
                Console.WriteLine("Podaj współczynniki równania kwadratowego ax^2+bx+c=0");

                var coefficients = new[] { new Coefficient("a", 0), new Coefficient("b", 0), new Coefficient("c", 0) };

                bool success;

                foreach (var coefficient in coefficients)
                {
                    InputNumber(coefficient.Name, ref coefficient.Value, out success);
                    if (!success)
                    {
                        Console.WriteLine("Podana wartość nie jest liczbą");
                        continue;
                    }
                }

                double a = coefficients[0].Value, b = coefficients[1].Value, c = coefficients[2].Value;

                var quadraticEquation = new QuadraticEquationSolver(a, b, c);

                Console.WriteLine(quadraticEquation.CalculatePrettySolutions());
            }
        }

        private static void Test()
        {
            var quadraticEquations = new QuadraticEquationSolver[] {
                new QuadraticEquationSolver(1, 2, 3),
                new QuadraticEquationSolver(1, 3, 2),
                new QuadraticEquationSolver(1, 2, 1),
                new QuadraticEquationSolver(0, 4, 2),
                new QuadraticEquationSolver(0, 0, 5),
                new QuadraticEquationSolver(0, 0, 0)
            };

            Console.WriteLine($"Test rozpoczęty dla {quadraticEquations.Length} równań");

            foreach (var equation in quadraticEquations)
            {
                Console.WriteLine(equation.ToString());

                Console.WriteLine(equation.CalculatePrettySolutions());
            }

            Console.WriteLine("Test zakończony");
        }

        private static void InputNumber(string numberName, ref double result, out bool success)
        {
            Console.Write($"Podaj {numberName}: ");
            string? text = Console.ReadLine();

            if (text == null)
            {
                Console.WriteLine("Podana wartość była nullem");
                success = false;
                return;
            }

            success = double.TryParse(text, out result);
        }
    }
}