namespace LeaveManagement.Data
{
    public abstract class BaseEntity
    {
        // Partial: it is made to extend the functionality of a class into multiple
        // classes in different files. 
        // Abstract: it cannot stand in its own at all
        // Abstract class: is a restricted class that cannot be used to create objects(to access it, it must be inherited from another class).
        // Abstract method: can only be used in an abstract class, and it does not have a body.The body is provided by the derived class (inherited from).

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
