public class GradeAddedHandler {

    public double CalculateFinalGrade(Student student, Course course) {
        double lecturePoints = student.Grades
            .Where(g => g.GradeType == GradeType.WYKŁAD)
            .Sum(g => (double)g.GradeWeight);

        double exercisePoints = student.Grades
            .Where(g => g.GradeType == GradeType.ĆWICZENIA)
            .Sum(g => (double)g.GradeWeight);

        return lecturePoints + exercisePoints;
    }
}