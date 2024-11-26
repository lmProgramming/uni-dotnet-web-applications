using ExamplesLinq;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Queries
{
    class Topic(string id, string name)
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;

        public override string ToString()
        {
            return $"{Id,2}) {Name}";
        }
    }

    class ProperStudent(int id, int index, string name, Gender gender, bool active,
        int departmentId)
    {
        public int Id { get; set; } = id;
        public int Index { get; set; } = index;
        public string Name { get; set; } = name;
        public Gender Gender { get; set; } = gender;
        public bool Active { get; set; } = active;
        public int DepartmentId { get; set; } = departmentId;

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}";
            return result;
        }
    }

    class Student(int id, int index, string name, Gender gender, bool active,
        int departmentId, List<Topic> topics)
    {
        public int Id { get; set; } = id;
        public int Index { get; set; } = index;
        public string Name { get; set; } = name;
        public Gender Gender { get; set; } = gender;
        public bool Active { get; set; } = active;
        public int DepartmentId { get; set; } = departmentId;

        public List<Topic> Topics { get; set; } = topics;

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in Topics)
                result += str + ", ";
            return result;
        }

        public string ChangeDepartment(int departmentId)
        {
            DepartmentId = departmentId;
            return $"Changed department to {departmentId}";
        }
    }

    /*
    1. Korzystając z klas z wykładu 7 (WykladLINQ.zip) stworzyć metodę z zapytaniem
    grupującym posortowanych studentów wg nazwiska (i numeru indeksu w przypadku tych
    samych nazwisk) w grupy po n elementów (n - parametr metody).
    2. Korzystając z klas z wykładu 7:
    a. posortować tematy (Topics) występujące wśród studentów wg częstości
    występowania wśród wszystkich studentów.
    b. w drugim wariancie tego zapytania wcześniej dokonać podziału względem płci, a
    dopiero w ramach każdej płci wykonać wspomniane sortowanie z podpunktu a.
    3. Korzystając z klas z wykładu 7 stworzyć klasę Topic, pamiętającą jeden temat (i jego
    identyfikator). Stworzyć nową klasę Student, która różni się tym od klasy
    StudentWithTopics, że tematy są pamiętane jako lista identyfikator tematów (a nie
    string-i). Stworzyć listę właściwych (niepowtarzalnych) tematów. Napisać zapytanie
    przekształcające listę obiektów StudentWithTopics, na listę obiektów klasy
    Student.
    a. Rozwiązanie minimalistyczne – lista tematów wpisana w kodzie.
    b. Dla chętnych – generacja listy tematów poprzez zapytanie.
    c. Dla chętnych – przygotować drugą wersję (oprócz tej pierwszej), gdzie zamiast
    pamiętać listę tematów tworzymy klasę Student, natomiast relację „n do n”
    pamiętamy w nowej liście z elementami typu StudentToTopic pamiętającej
    pary identyfikatorów: studenta i tematu (czyli tak, jak to będzie zapisane w
    poprawnie zaprojektowanej bazie relacyjnej).
    4. Korzystając z mechanizmu odbicia:
    a. stworzyć 1-2 obiekty wybranej klasy (ale pamiętać je w zmiennych klasy object),
    b. Uruchomić wybraną metodę (czyli otrzymać obiekt klasy MethodInfo i wywołać dla
    niego metodę Invoke), która posiada parametry. Zaprezentować wynik tej metody
    (np. w konsoli). Wynik również pamiętać w klasie object.
    */
    internal class Program
    {
        static void PrintHeader<T>(T header)
        {
            Console.WriteLine($"-----------------{header}---------------");
        }

        static void Main(string[] args)
        {
            var groupSize = 3;
            var students = Generator.GenerateStudentsWithTopicsEasy();

            Console.WriteLine("Task 1: ");
            var studentsGroupedBySurname = GroupStudentsBySurname(students, groupSize);
            foreach (var group in studentsGroupedBySurname)
            {
                PrintHeader("Group");
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            Console.WriteLine("\nTask 2: ");
            Console.WriteLine("\na)");
            var topicsByFrequency = SortTopicsByFrequency(students);
            foreach (var topic in topicsByFrequency)
            {
                Console.WriteLine(topic);
            }
            Console.WriteLine("\nb)");
            var topicsByGenderAndFrequency = SortTopicsByFrequencyAndGender(students);
            foreach (var group in topicsByGenderAndFrequency)
            {
                PrintHeader(group.Key);
                foreach (var topic in group)
                {
                    Console.WriteLine(topic);
                }
            }

            Console.WriteLine("\nTask 3: ");
            Console.WriteLine("\na)b)");
            var topics = GetTopics(students).ToList();
            var studentsConverted = StudentsWithTopicsToStudents(students, topics);
            foreach (var student in studentsConverted)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\nc)");

            IEnumerable<ProperStudent> properStudentsConverted;
            IEnumerable<(int, string)> associationTopics;

            (properStudentsConverted, associationTopics) = StudentsWithTopicsToProperStudents(studentsConverted, topics);
            foreach (var student in properStudentsConverted)
            {
                Console.WriteLine(student);
                var studentTopics = associationTopics
                    .Where(at => at.Item1 == student.Id)
                    .Select(at => at.Item2);
                Console.WriteLine("Topics: " + string.Join(", ", studentTopics));
            }

            Console.WriteLine("\nTask 4: ");
            Console.WriteLine("a)");
            object student1 = new Student(1, 1001, "John Doe", Gender.Male, true, 1, new List<Topic> { new Topic("1", "Math") });
            object student2 = new Student(2, 1002, "Jane Smith", Gender.Female, true, 2, new List<Topic> { new Topic("2", "Science") });

            Console.WriteLine("b)");
            MethodInfo changeDepartmentMethod = typeof(Student).GetMethod("ChangeDepartment", [typeof(int)]);
            string result1 = changeDepartmentMethod.Invoke(student1, [8]) as string;
            string result2 = changeDepartmentMethod.Invoke(student2, [3]) as string;

            Console.WriteLine("Result of ToString method for student1: " + result1);
            Console.WriteLine("Result of ToString method for student2: " + result2);
        }

        static IEnumerable<IEnumerable<StudentWithTopics>> GroupStudentsBySurname(IEnumerable<StudentWithTopics> students, int n)
        {
            return students
                .OrderBy(student => student.Name)
                .ThenBy(student => student.Index)
                .Select((student, index) => new { Student = student, Index = index })
                .GroupBy(item => item.Index / n)
                .Select(group => group.Select(item => item.Student));
        }

        static IEnumerable<string> SortTopicsByFrequency(IEnumerable<StudentWithTopics> students)
        {
            return students
                .SelectMany(student => student.Topics)
                .GroupBy(topic => topic)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key);
        }

        static IEnumerable<IGrouping<Gender, string>> SortTopicsByFrequencyAndGender(IEnumerable<StudentWithTopics> students)
        {
            return students
                .GroupBy(student => student.Gender)
                .SelectMany(group => group
                    .SelectMany(student => student.Topics)
                    .GroupBy(topic => topic)
                    .OrderByDescending(topicGroup => topicGroup.Count())
                    .Select(topicGroup => topicGroup.Key)
                    .GroupBy(topic => group.Key));
        }

        static IEnumerable<Topic> GetTopics(IEnumerable<StudentWithTopics> students)
        {
            return students
                .SelectMany(student => student.Topics)
                .Distinct()
                .Select((topic, index) => new Topic(index.ToString(), topic));
        }

        static IEnumerable<Student> StudentsWithTopicsToStudents(IEnumerable<StudentWithTopics> students, IEnumerable<Topic> topics)
        {
            return students.Select(student => new Student(
                student.Id,
                student.Index,
                student.Name,
                student.Gender,
                student.Active,
                student.DepartmentId,
                student.Topics.Select(topic => topics.First(t => t.Name == topic)).ToList()
            ));
        }

        static (IEnumerable<ProperStudent>, IEnumerable<(int, string)>) StudentsWithTopicsToProperStudents(IEnumerable<Student> students, IEnumerable<Topic> topics)
        {
            var properStudents = students.Select(student => new ProperStudent(
                student.Id,
                student.Index,
                student.Name,
                student.Gender,
                student.Active,
                student.DepartmentId
            ));

            var topicAssociationTable = students
                .SelectMany(student => student.Topics, (student, topic) => (student.Id, topic.Id))
                .ToList();

            return (properStudents, topicAssociationTable);
        }
    }
}
