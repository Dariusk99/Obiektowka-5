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
    }
}