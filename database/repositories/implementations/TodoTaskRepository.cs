using TaskManager.Database.Context;
using TaskManager.Database.Repositories.Interfaces;
using TaskManager.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Database.Repositories.Implementations
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TodoAppContext _context;

        public TodoTaskRepository(TodoAppContext context)
        {
            _context = context;
        }

        // Create
        public void Add(TodoTask task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void BulkAdd(IEnumerable<TodoTask> tasks)
        {
            _context.AddRange(tasks);
            _context.SaveChanges();
        }

        // READ
        public IEnumerable<TodoTask> GetAll() => _context.TodoTasks
            .Include(t => t.Assignee)
            .ToList();

        public TodoTask? GetById(int id) => _context.TodoTasks
            .Include(t => t.Assignee)
            .Single(t => t.Id == id);

        public IEnumerable<TodoTask> GetByPersonId(int personId) => _context.TodoTasks
            .Include(t => t.Assignee)
            .Where(t => t.Assignee.Id == personId)
            .ToList();

        public IEnumerable<TodoTask> GetByDueDateRange(DateTime startDate, DateTime endDate) => _context.TodoTasks
            .Include(t => t.Assignee)
            .Where(t => startDate <= t.DueDate && t.DueDate <= endDate)
            .ToList();

        public IEnumerable<TodoTask> GetByDueDateAfter(DateTime startDate) => _context.TodoTasks
            .Include(t => t.Assignee)
            .Where(t => startDate <= t.DueDate)
            .ToList();

        public IEnumerable<TodoTask> GetByDueDateBefore(DateTime endDate) => _context.TodoTasks
            .Include(t => t.Assignee)
            .Where(t => t.DueDate <= endDate)
            .ToList();

        // Update
        public void Update(TodoTask task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        public void BulkUpdate(IEnumerable<TodoTask> tasks)
        {
            _context.UpdateRange(tasks);
            _context.SaveChanges();
        }

        // Delete
        public void Delete(int id)
        {
            var dbTask = _context.TodoTasks
                .Single(t => t.Id == id);
            if (dbTask != null) {
                _context.Remove(dbTask);
                _context.SaveChanges();
            }
        }

        public void BulkDelete(IEnumerable<int> ids) {
            var dbTasks = _context.TodoTasks
                .Where(t => ids.Contains(t.Id))
                .ToList();
            _context.RemoveRange(dbTasks);
            _context.SaveChanges();
        }
    }
}
