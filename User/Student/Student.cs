public class Student : User {
    
    public List<Grade>? Grades { get; set; } = new List<Grade>();

    public Student(long index, string firstName, string lastName) : base(index, firstName, lastName) {
        Index = index;
        FirstName = firstName;
        LastName = lastName;
    }
}