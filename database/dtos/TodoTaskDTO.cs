using TaskManager.Database.Models;
using TaskManager.Database.Models.Utilities;

namespace TaskManager.Database.DTOs
{
    public class TodoTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public Priority Priority { get; set; }
        public Difficulty Difficulty { get; set; }
        public Person Assignee { get; set; }
    }

    public class TodoTaskUpdateDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority? Priority { get; set; }
        public Difficulty? Difficulty { get; set; }
    }
}
