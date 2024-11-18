namespace BusinessCard
{
    class Program
    {
        static void Main()
        {
            var person = ("Jan", "Kowalski", 30, 5000.0);
            PrintTuple(person);
        }

        static void PrintTuple((string FirstName, string LastName, int Age, double Salary) person)
        {
            Console.WriteLine($"Imię: {person.FirstName}, Nazwisko: {person.LastName}, Wiek: {person.Age}, Płaca: {person.Salary}");

            var (firstName, lastName, age, salary) = person;
            Console.WriteLine($"Imię: {firstName}, Nazwisko: {lastName}, Wiek: {age}, Płaca: {salary}");

            Console.WriteLine($"Imię: {person.Item1}, Nazwisko: {person.Item2}, Wiek: {person.Item3}, Płaca: {person.Item4}");
        }
    }
}
