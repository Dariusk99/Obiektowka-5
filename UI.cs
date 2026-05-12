public class UI {

    private bool Running;
    private readonly StudentService StudentService;

    public UI() {
        this.StudentService = new StudentService();
    }

    public void ShowMenu() {
        this.Running = true;

        while (Running) {
            Console.WriteLine("1. List students");
            Console.WriteLine("2. Exit");

            string input = Console.ReadLine() ?? "";
            
            switch(input) {
                case "1": this.ListStudents(); break;
                case "2": this.Running = false; break;
                default:
                    Console.WriteLine("Invalid option");
                    return;
            }
        }
    }

    private void ListStudents() {
        foreach (Student s in this.StudentService.GetAllStudents()) {
            Console.WriteLine(s);
        }
    }
}