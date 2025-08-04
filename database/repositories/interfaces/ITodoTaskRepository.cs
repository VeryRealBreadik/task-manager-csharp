using TaskManager.Database.Models;

namespace TaskManager.Database.Repositories.Interfaces
{
    public interface ITodoTaskRepository
    {
        // Create
        void Add(TodoTask task);
        void BulkAdd(IEnumerable<TodoTask> tasks);

        // READ
        IEnumerable<TodoTask> GetAll();
        TodoTask? GetById(int id);
        IEnumerable<TodoTask> GetByPersonId(int personId);
        IEnumerable<TodoTask> GetByDueDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<TodoTask> GetByDueDateAfter(DateTime startDate);
        IEnumerable<TodoTask> GetByDueDateBefore(DateTime endDate);

        // Update
        void Update(TodoTask task);
        void BulkUpdate(IEnumerable<TodoTask> tasks);

        // Delete
        void Delete(int id);
        void BulkDelete(IEnumerable<int> ids);
    }
}
