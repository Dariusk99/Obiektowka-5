public class GradeService {

    private List<Grade> Grades = new List<Grade>();

    public void CalculateFinalGrade(Student student, Grade grade) {
        double lecturePoints = student.Grades
            .Where(g => g.GradeType == GradeType.WYKŁAD)
            .Sum(g => (int)g.GradeWeight);

        double exercisePoints = student.Grades
            .Where(g => g.GradeType == GradeType.ĆWICZENIA)
            .Sum(g => (int)g.GradeWeight);

        student.
    }
}