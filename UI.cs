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
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List students");

            string input = Console.ReadLine() ?? "";
            
            switch(input) {
                case "0": this.Running = false; break;
                case "1": this.ListStudents(); break;
                default: Console.WriteLine("Invalid option"); return;
            }
        }
    }

    private void ListStudents() {
        Console.Clear();
        List<Student> Students = this.StudentService.GetAllStudents();

        Console.WriteLine("0. Back");

        for (int i = 0; i < Students.Count; i++) {
            Console.WriteLine($"{i+1}. {Students[i]}");
        }

        Console.Write("Select student: ");

        int input = int.Parse(Console.ReadLine() ?? "");

        if (input == 0) return;

        if (input >= 1 && input <= Students.Count) ShowStudent(Students[input-1]);
        else Console.WriteLine("Invalid option");
    }

    private void ShowStudent(Student Student) {
        Console.Clear();
        Console.WriteLine($"Student: {Student}");
        Console.WriteLine($"Final grade: \n");

        GradeType[] values = Enum.GetValues<GradeType>();

        for (int i = 0; i < values.Length; i++) {
            List<Grade> grades = Student.Grades
                .Where(g => g.GradeType == values[i])
                .ToList();

            Console.Write($"\n {i+1}. {values[i]}: ");
            grades.ForEach(g => Console.Write($"[{(int)g.GradeWeight}]"));
        }

        Console.Write("\n Select grades for edit: ");
        int input = int.Parse(Console.ReadLine() ?? "");

        if (input >= 1 && input <= values.Length) {
            GradeType selected = values[input-1];        
            
            List<Grade> grades = Student.Grades
                .Where(g => g.GradeType == selected)
                .ToList();
            
            grades.ForEach(g => Console.WriteLine((int)g.GradeWeight));
        } else {
            Console.WriteLine("Invalid option");
        }
    }

    private void EditStudentGrades(Student Student, List<Grade> Grades) {
        Console.Clear();
        Console.WriteLine($"Student: {Student}");
        Console.WriteLine($"{Grades[0].GradeType}: \n");
        int inputa = int.Parse(Console.ReadLine() ?? "");
    }
}