public class Teacher {
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public List<Course> Courses { get; private set; }

    public event EventHandler<GradeAddedEventArgs> GradeAdded;

    public Teacher(string name, string surname) {
        Name = name;
        Surname = surname;
        Courses = new List<Course>();
    }

    public void ShowCourses() {
        Console.WriteLine("\nMoje kursy:");

        foreach (Course course in Courses) {
            Console.WriteLine($"- {course.Name}");
        }
    }

    public void ShowStudentsInCourses() {
        foreach (Course course in Courses) {
            Console.WriteLine($"\nKurs: {course.Name}, Studenci:");

            foreach (Student student in course.Students)
                {
                    Console.WriteLine($"{student.Id} - {student.Name} {student.Surname}");
                }
        }
    }

    public void AddGrade(Student student, double grade, int type) {
        if (type == 1) student.LectureGrades.Add(grade);
        if (type == 2) student.ExerciseGrades.Add(grade);
        GradeAdded?.Invoke(this, new GradeAddedEventArgs(student, grade));
    }
}