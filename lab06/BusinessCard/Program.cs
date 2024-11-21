namespace BusinessCard
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Task 1: Tuple");
            var person = ("Jan", "Kowalski", 30, 5000.0);
            PrintTuple(person);

            Console.WriteLine("\nTask 2: Variable named `class`");
            UseVariableNamedClass();

            Console.WriteLine("\nTask 3: System.Array methods");
            DemonstrateArrayMethods();

            Console.WriteLine("\nTask 4: Anonymous Type");
            CheckAnonymousType();

            Console.WriteLine("\nTask 5: DrawCard method");
            DrawCard("Jan", "Kowalski", '*', 3, 25);
            DrawCard("Ryszard", "Rychu", borderChar: '#', 4);
            DrawCard("Rychu", "Ryś", minWidth: 100);
            DrawCard("Adam", "Ryś", minWidth: 100, borderChar: '1');

            Console.WriteLine("\nTask 6: CountMyTypes");
            var tuple = CountMyTypes(2, 4.5, 3, 0, -1.5, "Hello", "World", true, 123, 5.5, "Short", "sh");
            PrintTypesCounts(tuple);
        }

        static void PrintTuple((string FirstName, string LastName, int Age, double Salary) person)
        {
            Console.WriteLine($"Imię: {person.FirstName}, Nazwisko: {person.LastName}, Wiek: {person.Age}, Płaca: {person.Salary}");

            var (firstName, lastName, age, salary) = person;
            Console.WriteLine($"Imię: {firstName}, Nazwisko: {lastName}, Wiek: {age}, Płaca: {salary}");

            Console.WriteLine($"Imię: {person.Item1}, Nazwisko: {person.Item2}, Wiek: {person.Item3}, Płaca: {person.Item4}");
        }

        static void UseVariableNamedClass()
        {
            var @class = @"This is a variable named 'class'.\";
            Console.WriteLine(@class);
        }

        static void DemonstrateArrayMethods()
        {
            int[] array = { 5, 3, 8, 1, 2 };

            Array.Sort(array);
            Console.WriteLine("Sorted Array: " + string.Join(", ", array));

            Array.Reverse(array);
            Console.WriteLine("Reversed Array: " + string.Join(", ", array));

            int index = Array.IndexOf(array, 8);
            Console.WriteLine("Index of 8: " + index);

            Array.Resize(ref array, 7);
            Console.WriteLine("Resized Array: " + string.Join(", ", array));

            Array.Clear(array, 0, array.Length);
            Console.WriteLine("Cleared Array: " + string.Join(", ", array));
        }

        static void CheckAnonymousType()
        {
            var person = new { FirstName = "Jan", LastName = "Kowalski", Age = 30, Salary = 5000.0 };
            Console.WriteLine($"Imię: {person.FirstName}, Nazwisko: {person.LastName}, Wiek: {person.Age}, Płaca: {person.Salary}");
            //PrintTuple(person);
            Console.WriteLine("Using PrintTuple with the var unpacked");
            PrintTuple((person.FirstName, person.LastName, person.Age, person.Salary));
            Console.WriteLine("Using dynamic parameter");
            PrintAnonymousTuple(person);
        }

        static void PrintAnonymousTuple(dynamic person)
        {
            Console.WriteLine($"Imię: {person.FirstName}, Nazwisko: {person.LastName}, Wiek: {person.Age}, Płaca: {person.Salary}");
        }

        static void DrawCard(string line1, string line2 = "", char borderChar = '*', int borderWidth = 2, int minWidth = 20)
        {
            int contentWidth = Math.Max(line1.Length, line2.Length);
            int cardWidth = Math.Max(minWidth, contentWidth + borderWidth * 2);

            string border = new string(borderChar, cardWidth);
            string emptyLine = borderChar + new string(' ', cardWidth - 2) + borderChar;

            string borderLine = new string(borderChar, borderWidth);

            int halfSize = cardWidth - borderWidth * 2;

            string contentLine1 = borderLine + line1.PadLeft((halfSize + line1.Length) / 2).PadRight(halfSize) + borderLine;
            string contentLine2 = borderLine + line2.PadLeft((halfSize + line2.Length) / 2).PadRight(halfSize) + borderLine;

            for (int i = 0; i < borderWidth; i++)
            {
                Console.WriteLine(border);
            }
            Console.WriteLine(contentLine1);
            if (!string.IsNullOrEmpty(line2))
                Console.WriteLine(contentLine2);
            for (int i = 0; i < borderWidth; i++)
            {
                Console.WriteLine(border);
            }
        }

        static (int, int, int, int) CountMyTypes(params object[] elements)
        {
            Console.WriteLine(String.Join(';', elements));

            int evenInts = 0;
            int positiveDoubles = 0;
            int longStrings = 0;
            int others = 0;

            foreach (var element in elements)
            {
                switch (element)
                {
                    case int i when i % 2 == 0:
                        evenInts++;
                        break;
                    case double d when d > 0:
                        positiveDoubles++;
                        break;
                    case string s when s.Length >= 5:
                        longStrings++;
                        break;
                    default:
                        others++;
                        break;
                }
            }

            return (evenInts, positiveDoubles, longStrings, others);
        }
        static void PrintTypesCounts((int, int, int, int) counts)
        {
            Console.WriteLine($"Even integers: {counts.Item1}");
            Console.WriteLine($"Positive doubles: {counts.Item2}");
            Console.WriteLine($"Long strings (>= 5 characters): {counts.Item3}");
            Console.WriteLine($"Other: {counts.Item4}");
        }
    }
}