public class Course {
    public string Name { get; private set; }
    public Teacher Teacher { get; private set; }

    public Course(string name, Teacher teacher) {
        Name = name;
        Teacher = teacher;
    }
}