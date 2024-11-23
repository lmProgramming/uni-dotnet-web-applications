namespace Queries
{
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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
