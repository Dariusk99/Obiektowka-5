public class Student {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public int PhoneNumber { get; private set; }
    public List<double> LecturePoints { get; private set; }
    public List<double> ExercisePoints { get; private set; }

    public Student(int id, string name, string surname, string email, int phoneNumber) {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        LecturePoints = new List<Double>();
        ExercisePoints = new List<Double>();
    }

    public void ShowInfo() {
        Console.WriteLine("\n--- INFORMACJE O STUDENCIE ---");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Imię: {Name}");
        Console.WriteLine($"Nazwisko: {Surname}");

        Console.WriteLine("Oceny:");

        if (LecturePoints.Count == 0) {
            Console.WriteLine("Brak ocen z wykładu.");
        }
        else {
            foreach (double grade in LecturePoints) {
                Console.WriteLine($"- {grade}");
            }

            Console.WriteLine($"Średnia: {LecturePoints.Average():F2}");
        }

        if (ExercisePoints.Count == 0) {
            Console.WriteLine("Brak ocen z ćwiczeń.");
        }
        else {
            foreach (double grade in ExercisePoints) {
                Console.WriteLine($"- {grade}");
            }

            Console.WriteLine($"Średnia: {ExercisePoints.Average():F2}");
        }
    }
}