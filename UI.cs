using System.Text;

public class UI {

    private bool Running;
    private readonly StudentService StudentService;

    public UI(StudentService studentService) {
        StudentService = studentService;
    }

    public void ShowMenu() {
        Running = true;

        while (Running) {
            Console.Clear();

            int option = PrintMenu(new [] {"Wyjdź", "Lista studentów"});
            
            switch(option) {
                case 0: Running = false; return;
                case 1: ListStudents(); break;
            }
        }
    }

    private void ListStudents() {
        Console.Clear();
        List<Student> students = StudentService.GetAllStudents();
    
        int option = PrintMenu(
            new [] {"Wróć"}
                .Concat(students.Select(s => s.ToString())).ToArray()
        );

        switch (option) {
            case 0: return;
            default: ShowStudentInfo(students[option-1]); break;
        }
    }

    private void ShowStudentInfo(Student student) {
        Console.Clear();
        Console.WriteLine($"Student: {student}");
        Console.WriteLine($"Ocena końcowa: ");

        List<string> menuOptions = new List<string>();
        GradeType[] types = Enum.GetValues<GradeType>();
        
        foreach (GradeType type in types) {
            List<Grade> grades = StudentService.GetStudentGradesByType(student, type);

            StringBuilder builder = new StringBuilder();
            
            builder.Append($"{type}: ");

            grades.ForEach(g => {
                builder.Append($"[<{(int)g.GradeWeight}> - '{g.Exercise}'] ");
            });

            menuOptions.Add(builder.ToString());
        }

        int option = PrintMenu(
            new [] {"Wróć"}
                .Concat(menuOptions)
                .ToArray()
        );

        switch (option) {
            case 0: return;
            default: ShowGrades(student, StudentService.GetStudentGradesByType(student, types[option-1])); break;
        }
    }

    private void ShowGrades(Student student, List<Grade> grades) {
        Console.Clear();
        Console.WriteLine($"Student: {student}");
        if (grades.Count != 0 || grades == null) Console.WriteLine($"\n[{grades[0].GradeType}]");
        else Console.WriteLine($"\nBrak ocen");

        List<string> menuOptions = new List<string>();

        foreach(Grade grade in grades) {
            menuOptions.Add($"[<{(int)grade.GradeWeight}> - '{grade.Exercise}']");
        }

        int option = PrintMenu(
            new [] {"Wróć"}
                .Concat(menuOptions)
                .Append("Dodaj ocenę")
                .ToArray()
        );

        int lastOption = grades.Count+1;
        
        if (option == 0) return;
        else if (option == menuOptions.Count+1) AddGrade(student);
        else EditGrade(grades[option-1]);
    }

    private void EditGrade(Grade grade) {
        Console.Clear();
        Console.WriteLine(grade);

        Console.Write($"\n'{grade.Exercise}', wprowadź nowy opis zadania lub enter by pominąć: ");
        string newExercise = Console.ReadLine() ?? "";
        
        Console.Write($"\n'{grade.GradeType}', wybierz kategorię lub enter by pominąć: ");

        GradeType[] types = Enum.GetValues<GradeType>();
        for (int i = 0; i < types.Length; i++) Console.Write($"\n{i+1}. {types[i]}");

        Console.WriteLine();
        string newTypeInput = Console.ReadLine() ?? "";
        int newType = int.Parse(newTypeInput);
        
        while (true) {
            Console.Write($"Zmieniono opis: '{newExercise}'. Zmieniono kategorię: {types[newType-1]}");
            Console.Write("\nZatwierdzić? t/n: ");
            string confirm = Console.ReadLine() ?? "";

            switch(confirm) {
                case "t":
                    if (newType >= 1 && newType <= types.Length) {
                        grade.GradeType = types[newType-1];
                    }

                    if (newExercise != "") grade.Exercise = newExercise;
                return;
                
                case "n": return;
                
                default: Console.Write("\nNieprawidłowy wybór\n"); break;
            }
        }
    }

    private void AddGrade(Student student) {
        Console.Clear();
        Console.WriteLine($"Dodaj ocenę dla: {student}");
        while (true) {
            Console.Write("\nWprowadź nazwę przedmiotu: ");
            string subject = Console.ReadLine() ?? "";
            
            GradeType[] types = Enum.GetValues<GradeType>();
            for (int i = 0; i<types.Length; i++) Console.Write($"\n{i+1}. {types[i]}");
            Console.Write("\nWprowadź kategorię: ");
            int gradeType = int.Parse(Console.ReadLine() ?? "");

            Console.Write("\nWprowadź opis: ");
            string exercise = Console.ReadLine() ?? "";

            GradeWeight[] weights = Enum.GetValues<GradeWeight>();
            for (int i = 0; i<weights.Length; i++) Console.Write($"\n{i+1}. {weights[i]}({(int)weights[i]})");
            Console.Write("\nWprowadź ocenę (2-5): ");
            int gradeWeight = int.Parse(Console.ReadLine() ?? "");

            Grade grade = new Grade(student, subject, exercise, types[gradeType-1], weights[gradeWeight-1]);
            Console.Write($"\n{grade}");
            Console.Write($"\nDodać ocenę? t/n: ");
            string confirm = Console.ReadLine() ?? "";
            
            if (confirm == "t") {
                StudentService.AddGrade(student, grade);
                return;
            }

            else if (confirm == "n") return;
        }
    }

    private int PrintMenu(string[] options) {
        for (int i = 0; i < options.Length; i++) {
            Console.WriteLine($"{i}. {options[i]}");
        }

        while (true) {
            Console.Write("\nWybierz: ");
            int input = int.Parse(Console.ReadLine() ?? "");
            if (input >= 0 && input < options.Length) return input;
            else Console.WriteLine("Nieprawidłowy wybór");
        }
    }
}