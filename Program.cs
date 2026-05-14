class Program {
    static void Main(string[] args) {
        StudentService studentService = new StudentService();
        GradeService gradeService = new GradeService();
        
        Teacher authenticatedTeacher = new Teacher(109, "Bartosz", "Walaszek");
        List<Course> courses = new() { 
            new Course("Algebra", authenticatedTeacher),
            new Course("Analiza matematyczna", authenticatedTeacher)
         };

        UI ui = new UI(studentService);
        ui.ShowMenu();
    }
}