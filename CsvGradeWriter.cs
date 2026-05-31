public class CsvGradeWriter {
    private string FilePath;

    public CsvGradeWriter(string filePath) {
        FilePath = filePath;
    }

    public void OnGradeAdded(object sender, GradeAddedEventArgs e) {

        string newLine = 
            $"{e.Student.Id};" +
            $"{e.Student.Name};" +
            $"{e.Student.Surname};" +
            $"{e.Grade};";

        File.AppendAllText(FilePath, newLine + Environment.NewLine);
    }
}