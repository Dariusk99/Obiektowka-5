using System.Text;

public class UI {

    private bool Running;
    private readonly StudentService StudentService;

    public UI() {
        this.StudentService = new StudentService();
    }

    public void ShowMenu() {
        this.Running = true;

        while (Running) {
            Console.Clear();

            int option = PrintMenu(new [] {"Exit", "List students"});
            
            switch(option) {
                case 0: this.Running = false; return;
                case 1: this.ListStudents(); break;
            }
        }
    }

    private void ListStudents() {
        Console.Clear();
        List<Student> Students = this.StudentService.GetAllStudents();
    
        int option = PrintMenu(
            new [] {"Back"}
                .Concat(Students.Select(s => s.ToString())).ToArray()
        );

        switch (option) {
            case 0: return;
            default: ShowStudentInfo(Students[option-1]); break;
        }
    }

    private void ShowStudentInfo(Student Student) {
        Console.Clear();
        Console.WriteLine($"Student: {Student}");
        Console.WriteLine($"Final grade: ");

        List<string> menuOptions = new List<string>();
        GradeType[] types = Enum.GetValues<GradeType>();
        
        foreach (GradeType type in types) {
            List<Grade> grades = StudentService.GetStudentGradesByType(Student, type);

            StringBuilder builder = new StringBuilder();
            
            builder.Append($"{type}: ");

            grades.ForEach(g => {
                builder.Append($"[<{(int)g.GradeWeight}> - '{g.Exercise}'] ");
            });

            menuOptions.Add(builder.ToString());
        }

        int option = PrintMenu(
            new [] {"Back"}
                .Concat(menuOptions)
                .ToArray()
        );

        switch (option) {
            case 0: return;
            default: ShowGrades(Student, StudentService.GetStudentGradesByType(Student, types[option-1])); break;
        }
    }

    private void ShowGrades(Student Student, List<Grade> Grades) {
        Console.Clear();
        Console.WriteLine($"Student: {Student}");
        if (Grades.Count != 0 || Grades == null) Console.WriteLine($"\n[{Grades[0].GradeType}]");
        else Console.WriteLine($"\nNo grades");

        List<string> menuOptions = new List<string>();

        foreach(Grade grade in Grades) {
            menuOptions.Add($"[<{(int)grade.GradeWeight}> - '{grade.Exercise}']");
        }

        int option = PrintMenu(
            new [] {"Back"}
                .Concat(menuOptions)
                .Append("Add grade")
                .ToArray()
        );

        int lastOption = Grades.Count+1;
        
        if (option == 0) return;
        else if (option == menuOptions.Count+1) AddGrade(Student);
        else EditGrade(Grades[option-1]);
    }

    private void EditGrade(Grade Grade) {
        Console.Clear();
        Console.WriteLine(Grade);

        Console.Write($"\n'{Grade.Exercise}', press enter to skip or edit exercise name: ");
        string newExercise = Console.ReadLine() ?? "";
        
        Console.Write($"\n'{Grade.GradeType}', press enter to skip or choose course type:");

        GradeType[] types = Enum.GetValues<GradeType>();
        for (int i = 0; i < types.Length; i++) Console.Write($"\n{i+1}. {types[i]}");

        Console.WriteLine();
        string newTypeInput = Console.ReadLine() ?? "";
        int newType = int.Parse(newTypeInput);
        
        while (true) {
            Console.Write($"New exercise name: '{newExercise}'. New type: {types[newType-1]}");
            Console.Write("\nConfirm? y/n: ");
            string confirm = Console.ReadLine() ?? "";

            switch(confirm) {
                case "y":
                    if (newType >= 1 && newType <= types.Length) {
                        Grade.GradeType = types[newType-1];
                    }

                    if (newExercise != "") Grade.Exercise = newExercise;
                return;
                
                case "n": return;
                
                default: Console.Write("\nInvalid option\n"); break;
            }
        }
    }

    private void AddGrade(Student Student) {
        Console.Clear();
        Console.WriteLine($"Add grade for: {Student}");
        while (true) {
            Console.Write("\nInsert subject: ");
            string subject = Console.ReadLine() ?? "";

            
            GradeType[] types = Enum.GetValues<GradeType>();
            for (int i = 0; i<types.Length; i++) Console.Write($"\n{i+1}. {types[i]}");
            Console.Write("\nInsert type: ");
            int gradeType = int.Parse(Console.ReadLine() ?? "");

            Console.Write("\nInsert exercise: ");
            string exercise = Console.ReadLine() ?? "";

            GradeWeight[] weights = Enum.GetValues<GradeWeight>();
            for (int i = 0; i<weights.Length; i++) Console.Write($"\n{i+1}. {weights[i]}({(int)weights[i]})");
            Console.Write("\nInsert weight: ");
            int gradeWeight = int.Parse(Console.ReadLine() ?? "");

            Grade Grade = new Grade(Student, subject, exercise, types[gradeType-1], weights[gradeWeight-1]);
            Console.Write($"\n{Grade}");
            Console.Write($"\nAdd grade? y/n: ");
            string confirm = Console.ReadLine() ?? "";
            if (confirm == "y") {
                Student.Grades.Add(Grade);
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
            Console.Write("\nSelect: ");
            int input = int.Parse(Console.ReadLine() ?? "");
            if (input >= 0 && input < options.Length) return input;
            else Console.WriteLine("Invalid option");
        }
    }
}