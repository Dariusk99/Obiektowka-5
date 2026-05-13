public class Grade {

    public Student? Student { get; private set; }
    public string Subject { get; private set; }
    public string Exercise { get; set; }
    public GradeType GradeType { get; set; }
    public GradeWeight GradeWeight { get; set; }

    public Grade(Student Student, string Subject, string Exercise, GradeType GradeType, GradeWeight GradeWeight) {
        this.Student = Student;
        this.Subject = Subject;
        this.Exercise = Exercise;
        this.GradeType = GradeType;
        this.GradeWeight = GradeWeight;
    }

    public override string ToString() {
        return $"{this.Student}, {this.Subject}, {this.Exercise}, {this.GradeType}, Grade weight: {(int)this.GradeWeight}";
    }
}