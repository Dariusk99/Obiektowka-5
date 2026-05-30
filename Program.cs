class Program {
    static void Main(string[] args) {
        //Setup
        Student s1 = new Student(1, "Dariusz", "Malina", "dariuszmalina@student.pl", 123456789);
        Student s2 = new Student(2, "Jerzy", "Jeżyna", "jerzyjezyna@student.pl", 005830102);

        Course course = new Course("Matematyka");
        course.Students.Add(s1);
        course.Students.Add(s2);

        Teacher teacher = new Teacher("Andrzej", "Kowalski");
        teacher.Courses.Add(course);

        EmailNotifier emailNotifier = new EmailNotifier();
        // SMSNotifier smsNotifier = new SMSNotifier();

        // teacher.GradeAdded += smsNotifier.OnGradeAdded;
        teacher.GradeAdded += emailNotifier.OnGradeAdded;

        while (true) {
            Console.WriteLine("--- PANEL NAUCZYCIELA ---");
            Console.WriteLine("1. Wyświetl moje kursy.");
            Console.WriteLine("2. Wyświetl studentów w kursie.");
            Console.WriteLine("3. Wyświetl informacje  studencie.");
            Console.WriteLine("4. Dodaj ocenę.");
            Console.WriteLine("0. Wyjdź.");

            string option = Console.ReadLine() ?? "";

            switch (option) {
                case "1":
                    teacher.ShowCourses();
                    break;
                    
                case "2":
                    teacher.ShowStudentsInCourses();
                    break;

                case "3":
                    Console.Write("Podaj ID studenta: ");
                    int id = int.Parse(Console.ReadLine());

                    Student student = 
                        teacher.Courses
                        .SelectMany(k => k.Students)
                        .FirstOrDefault(s => s.Id == id);
                    
                    if (student != null)
                        student.ShowInfo();
                    else
                        Console.WriteLine("Nie znaleziono studenta");
                    break;

                case "4":
                    Console.Write("Podaj ID studenta: ");
                    int studentId = int.Parse(Console.ReadLine());

                    Student existsStudent = 
                        teacher.Courses
                        .SelectMany(k => k.Students)
                        .FirstOrDefault(s => s.Id == studentId);
                    
                    if (existsStudent != null) {
                        Console.Write("Podaj ocenę: ");
                        double grade = double.Parse(Console.ReadLine());
                        Console.Write("Wybierz typ: ");
                        Console.Write("1. Ocena z wykładu: ");
                        Console.Write("2. Ocena z ćwiczeń: ");
                        int gradeType = int.Parse(Console.ReadLine());
                        teacher.AddGrade(existsStudent, grade, gradeType);
                    }
                    else
                        Console.WriteLine("Nie znaleziono studenta");
                    break;

                case "0":
                    return;

                default:    
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }
    }
}