public class StudentService {

    private List<Student> Students = new List<Student>();
    private StudentRepository Repository;

    public event Action<Student, Grade>? GradeAdded;

    public StudentService(StudentRepository repository) {
        Repository = repository;
    }

    public List<Student> GetAllByCourse(Course course) {
        return Repository.GetAllWhereCourse(course);
    }

    public List<Grade> GetStudentGradesByType(Student student, GradeType type) {
        return student.Grades
            .Where(g => g.GradeType == type)
            .ToList();
    }

    public void AddGrade(Student student, Grade grade) {
        student.Grades.Add(grade);
        GradeAdded?.Invoke(student, grade);
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
                    new Grade(s, "OOP", $"Zadanie {i+1}", type, weights[random.Next(weights.Length)])
                );
            };
            }
        });
    }
}