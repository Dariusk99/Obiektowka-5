public class Course {
    public string Name { get; private set; }
    public List<Student> Students { get; private set; }

    public Course(string name) {
        Name = name;
        Students = new List<Student>();
    }
}