public class GradeCalculator {
    public void OnGradeAdded(object sender, GradeAddedEventArgs e) {
        double finalGrade = (e.Student.LectureGrades.Sum() + e.Student.ExerciseGrades.Sum()) / 0.5;
        Console.WriteLine($"Ocena końcowa: {finalGrade}");
    }
}