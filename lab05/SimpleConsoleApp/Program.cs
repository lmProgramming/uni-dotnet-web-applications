﻿namespace Program
{
    public class QuadraticEquation
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

        public QuadraticEquation(double a, double b, double c)
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

                    solutionsCount = SolutionsCount.Zero;
                    return [];
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
}