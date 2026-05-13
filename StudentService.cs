public class StudentService {

    public List<Student> Students { get; private set; }

    public StudentService() {
        Setup();
    }

    public List<Student> GetAllStudents() {
        return this.Students;
    }

    public List<Grade> GetStudentGradesByType(Student Student, GradeType Type) {
        return Student.Grades
            .Where(g => g.GradeType == Type)
            .ToList();
    }

    private void Setup() {
        Students = new List<Student> {
            new Student(1, "Ferdynand", "Kiepski"),
            new Student(2, "Arnold", "Boczek"),
            new Student(3, "Marian", "Paździoch")
        };

        Random random = new Random();
        GradeWeight[] weights = Enum.GetValues<GradeWeight>();

        Students.ForEach(s => {
            foreach (GradeType type in Enum.GetValues<GradeType>()) {
                for (int i=0; i<3; i++) {
                s.Grades.Add(
                    new Grade(s, "OOP", $"Exercise {i+1}", type, weights[random.Next(weights.Length)])
                );
            };
            }
        });
    }
}