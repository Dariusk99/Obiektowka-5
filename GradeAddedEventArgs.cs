public class GradeAddedEventArgs : EventArgs {
    public Student Student { get; set; }
    public double Grade { get; set; }

    public GradeAddedEventArgs(Student student, double grade) {
        Student = student;
        Grade = grade;
    }
}