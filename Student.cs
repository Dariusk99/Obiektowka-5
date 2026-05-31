public class Student {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public List<double> LectureGrades { get; private set; }
    public List<double> ExerciseGrades { get; private set; }

    public Student(int id, string name, string surname) {
        Id = id;
        Name = name;
        Surname = surname;
        LectureGrades = new List<Double>();
        ExerciseGrades = new List<Double>();
    }

    public void ShowInfo() {
        Console.WriteLine("\n--- INFORMACJE O STUDENCIE ---");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Imię: {Name}");
        Console.WriteLine($"Nazwisko: {Surname}");

        Console.WriteLine("Oceny:");

        if (LectureGrades.Count == 0) {
            Console.WriteLine("Brak ocen z wykładu.");
        }
        else {
            foreach (double grade in LectureGrades) {
                Console.WriteLine($"Wykłady - {grade}");
            }

            Console.WriteLine($"Średnia z wykładu: {LectureGrades.Average():F2}");
        }

        if (ExerciseGrades.Count == 0) {
            Console.WriteLine("Brak ocen z ćwiczeń.");
        }
        else {
            foreach (double grade in ExerciseGrades) {
                Console.WriteLine($"Ćwiczenia - {grade}");
            }

            Console.WriteLine($"Średnia z ćwiczeń: {ExerciseGrades.Average():F2}");
        }
    }
}