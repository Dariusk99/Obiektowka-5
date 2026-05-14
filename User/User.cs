public abstract class User {

    public long Index { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public User(long index, string firstName, string lastName) {
        Index = index;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString() {
        return $"{FirstName} {LastName} ({Index})";
    }
}