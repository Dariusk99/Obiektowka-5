public class CsvGradeWriter {
    private string FilePath;

    public CsvGradeWriter(string filePath) {
        FilePath = filePath;
    }

    public void OnGradeAdded(object sender, GradeAddedEventArgs e) {
        double finalGrade = (e.LecturePoints + e.ExercisePoints) / 0.5;

        string newLine = 
            $"{e.Student.Id};" +
            $"{e.Student.Name};" +
            $"{e.Student.Surname};" +
            $"{e.LecturePoints};" +
            $"{e.ExercisePoints};" +
            $"{finalGrade};";

        File.AppendAllText(FilePath, newLine + Environment.NewLine);
    }
}