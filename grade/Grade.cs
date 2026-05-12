public class Grade {

    public Student? Student { get; private set; }
    public string Subject { get; private set; }
    public string Exercise { get; private set; }
    public GradeType GradeType { get; private set; }
    public GradeWeight GradeWeight { get; private set; }

    public Grade(Student Student, string Subject, string Exercise, GradeType GradeType, GradeWeight GradeWeight) {
        this.Student = Student;
        this.Subject = Subject;
        this.GradeType = GradeType;
        this.GradeWeight = GradeWeight;
    }

    public override string ToString() {
        return $"{this.Exercise}, {this.GradeWeight}";
    }
}