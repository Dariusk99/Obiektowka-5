public class EmailNotifier {
    public void OnGradeAdded(object sender, GradeAddedEventArgs e) {
        Console.WriteLine($"(EmailNotifier) Wysłano wiadomość do {e.Student.Email}: Dodano ocenę {e.Grade}");
    }
}