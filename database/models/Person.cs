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
            AssignedTasks = new List<TodoTask>();
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AssignedTasks = new List<TodoTask>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
