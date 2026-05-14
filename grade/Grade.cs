public class Grade {

    public Student? Student { get; private set; }
    public Course Course { get; private set; }
    public string Description { get; set; }
    public GradeType GradeType { get; set; }
    public GradeWeight GradeWeight { get; set; }

    public Grade(Student student, Course course, string Description, GradeType gradeType, GradeWeight gradeWeight) {
        Student = student;
        Course = course;
        Description = Description;
        GradeType = gradeType;
        GradeWeight = gradeWeight;
    }

    public override string ToString() {
        return $"{Student}, {Course}, {Exercise}, {GradeType}, Ocena: {(int)GradeWeight}";
    }
}