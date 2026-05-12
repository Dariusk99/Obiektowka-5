public class StudentService {

    public List<Student> Students { get; private set; }

    public StudentService() {
        Setup();
    }

    public List<Student> GetAllStudents() {
        return this.Students;
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
                for (int i=0; i<5; i++) {
                s.Grades.Add(
                    new Grade(s, "OOP", $"Exercise {i}", type, weights[random.Next(weights.Length)])
                );
            };
            }
        });
    }
}