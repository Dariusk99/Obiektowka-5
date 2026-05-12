public class Student {
    
    public long Index { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public List<Grade>? Grades { get; set; } = new List<Grade>();

    public Student(long Index, string FirstName, string LastName) {
        this.Index = Index;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    public override string ToString() {
        return $"{this.Index} {this.FirstName} {this.LastName}";
    }
}