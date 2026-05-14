public class StudentRepository {
    
    private List<Student> Students = new();

    public Student Save(Student student) {
        return Students.Add(student);
    }

    public Student GetByIndex(long index) {
        return Students.FirstOrDefault(s => s.Index == index);
    }

    public List<Student> GetAllWhereCourse(Course course) {
        return Students
            .Where(s => s.Courses.Contains(course))
            .ToList();
    }
}