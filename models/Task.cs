using TaskManager.Models.Utilities;

namespace TaskManager.Models
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; private set; }
        private DateTime _dueDate { get; set; }
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                if (value < StartDate)
                {
                    throw new DataMisalignedException("DueDate cannot be earlier than StartDate.");
                }
                else
                {
                    _dueDate = value;
                }
            }
        }
        public bool IsCompleted { get; private set; }
        public Priority Priority { get; set; }
        public Difficulty Difficulty { get; set; }
        public Person Assignee { get; set; }

        public Task(string title, string description, DateTime startDate, DateTime dueDate, Priority priority,
                    Difficulty difficulty, Person assignee)
        {
            if (dueDate < startDate)
            {
                throw new DataMisalignedException("DueDate cannot be earlier than StartDate.");
            }
            Title = title;
            Description = description;
            StartDate = startDate;
            _dueDate = dueDate;
            IsCompleted = false;
            Priority = priority;
            Difficulty = difficulty;
            Assignee = assignee;
        }

        public void MarkCompleted()
        {
            IsCompleted = true;
        }

        public int GetDaysRemaining()
        {
            int daysRemaining = DueDate.Subtract(DateTime.UtcNow.Date).Days;
            return daysRemaining >= 0 ? daysRemaining : 0;
        }

        override public string ToString()
        {
            return $"""
            Task information.
            Title: {Title};
            Description: {Description};
            Start date: {StartDate.ToShortDateString()};
            Due date: {DueDate.ToShortDateString()};
            Is completed: {(IsCompleted ? "Yes" : "No")};
            Priority: {Priority};
            Difficulty: {Difficulty};
            Assignee: {Assignee};
            """;
        }
    }
}
