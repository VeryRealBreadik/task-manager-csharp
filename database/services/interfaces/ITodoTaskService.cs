using TaskManager.Database.DTOs;

namespace TaskManager.Database.Services.Interfaces
{
    public interface ITodoTaskService
    {
        // Create
        void Add(TodoTaskDTO task);
        void BulkAdd(IEnumerable<TodoTaskDTO> tasks);

        // READ
        IEnumerable<TodoTaskDTO> GetAll();
        TodoTaskDTO? GetById(int id);
        IEnumerable<TodoTaskDTO> GetByPersonId(int personId);
        IEnumerable<TodoTaskDTO> GetByDueDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<TodoTaskDTO> GetByDueDateAfter(DateTime startDate);
        IEnumerable<TodoTaskDTO> GetByDueDateBefore(DateTime endDate);

        // Update
        void Update(TodoTaskUpdateDTO task);
        void BulkUpdate(IEnumerable<TodoTaskUpdateDTO> tasks);
        void MarkCompletedById(int id);

        // Delete
        void Delete(int id);
        void BulkDelete(IEnumerable<int> ids);
    }
}
