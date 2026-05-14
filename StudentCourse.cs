public class StudentCourse {
    public Student Student { get; set; }
    public Course Course { get; set; }
    public List<Grade> Grades { get; set; } = new();
    public double? FinalGrade { get; set; }
}