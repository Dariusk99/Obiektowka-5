public class Student {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public List<double> Grades { get; private set; }

    public Student(int id, string name, string surname) {
        Id = id;
        Name = name;
        Surname = surname;
        Grades = new List<Double>();
    }

    public void ShowInfo() {
        Console.WriteLine("\n--- INFORMACJE O STUDENCIE ---");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Imię: {Name}");
        Console.WriteLine($"Nazwisko: {Surname}");

        Console.WriteLine("Oceny:");

        if (Grades.Count == 0) {
            Console.WriteLine("Brak ocen.");
        }
        else {
            foreach (double grade in Grades) {
                Console.WriteLine($"- {grade}");
            }

            Console.WriteLine($"Średnia: {Grades.Average():F2}");
        }
    }
}