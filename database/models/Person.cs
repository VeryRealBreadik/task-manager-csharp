namespace TaskManager.Database.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<TodoTask> AssignedTasks { get; set; }

        public Person()
        {
            AssignedTasks = [];
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AssignedTasks = [];
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
