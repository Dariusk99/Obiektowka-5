public class Teacher : User {
    
    public List<Courses> Courses { get; set; } = new();

    public Teacher(long index, string firstName, string lastName) : base(index, firstName, lastName) {
        Index = index;
        FirstName = firstName;
        LastName = lastName;
    }
}