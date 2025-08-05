using TaskManager.Database.DTOs;
using TaskManager.Database.Models;
using TaskManager.Database.Repositories.Implementations;
using TaskManager.Database.Repositories.Interfaces;
using TaskManager.Database.Services.Interfaces;

namespace TaskManager.Database.Services.Implementations
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskService(TodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        // Create
        public void Add(TodoTaskDTO taskDTO) => _todoTaskRepository.Add(FromDTO(taskDTO));

        public void BulkAdd(IEnumerable<TodoTaskDTO> tasksDTOs)
        {
            var tasks = tasksDTOs
                .Select(FromDTO)
                .ToList();
            _todoTaskRepository.BulkAdd(tasks);
        }

        // READ
        public IEnumerable<TodoTaskDTO> GetAll()
        {
            var tasks = _todoTaskRepository.GetAll();
            var tasksDTOs = tasks
                .Select(ToDTO)
                .ToList();
            return tasksDTOs;
        }

        public TodoTaskDTO? GetById(int id)
        {
            var task = _todoTaskRepository.GetById(id);
            if (task is null) return null;
            var taskDTO = ToDTO(task);
            return taskDTO;
        }

        public IEnumerable<TodoTaskDTO> GetByPersonId(int personId)
        {
            var tasks = _todoTaskRepository.GetByPersonId(personId);
            var tasksDTOs = tasks
                .Select(ToDTO)
                .ToList();
            return tasksDTOs;
        }

        public IEnumerable<TodoTaskDTO> GetByDueDateRange(DateTime startDate, DateTime endDate)
        {
            var tasks = _todoTaskRepository.GetByDueDateRange(startDate, endDate);
            var tasksDTOs = tasks
                .Select(ToDTO)
                .ToList();
            return tasksDTOs;
        }

        public IEnumerable<TodoTaskDTO> GetByDueDateAfter(DateTime startDate)
        {
            var tasks = _todoTaskRepository.GetByDueDateAfter(startDate);
            var tasksDTOs = tasks
                .Select(ToDTO)
                .ToList();
            return tasksDTOs;
        }

        public IEnumerable<TodoTaskDTO> GetByDueDateBefore(DateTime endDate)
        {
            var tasks = _todoTaskRepository.GetByDueDateBefore(endDate);
            var tasksDTOs = tasks
                .Select(ToDTO)
                .ToList();
            return tasksDTOs;
        }

        // Update
        public void Update(TodoTaskUpdateDTO taskDTO)
        {
            var task = FromDTO(taskDTO);
            _todoTaskRepository.Update(task);
        }

        public void BulkUpdate(IEnumerable<TodoTaskUpdateDTO> tasksDTOs)
        {
            var tasks = tasksDTOs
                .Select(FromDTO)
                .ToList();
            _todoTaskRepository.BulkUpdate(tasks);
        }

        public void MarkCompletedById(int id)
        {
            var task = new TodoTask
            {
                Id = id,
            };
            task.MarkCompleted();
            _todoTaskRepository.Update(task);
        }

        // Delete
        public void Delete(int id) => _todoTaskRepository.Delete(id);

        public void BulkDelete(IEnumerable<int> ids) => _todoTaskRepository.BulkDelete(ids);

        private TodoTaskDTO ToDTO(TodoTask task)
        {
            return new TodoTaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate,
                DueDate = task.DueDate,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                Difficulty = task.Difficulty,
                Assignee = task.Assignee,
            };
        }

        private TodoTask FromDTO(TodoTaskDTO taskDTO)
        {
            return new TodoTask
            {
                Id = taskDTO.Id,
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                DueDate = taskDTO.DueDate,
                Priority = taskDTO.Priority,
                Difficulty = taskDTO.Difficulty,
                Assignee = taskDTO.Assignee,
            };
        }

        private TodoTask FromDTO(TodoTaskUpdateDTO taskUpdateDTO)
        {
            var taskUpdate = new TodoTask();
            taskUpdate.Id = taskUpdateDTO.Id;
            if (taskUpdateDTO.Title is not null) taskUpdate.Title = taskUpdate.Title;
            if (taskUpdateDTO.Description is not null) taskUpdate.Description = taskUpdate.Description;
            if (taskUpdateDTO.DueDate is not null) taskUpdate.DueDate = taskUpdate.DueDate;
            if (taskUpdateDTO.Priority is not null) taskUpdate.Priority = taskUpdate.Priority;
            if (taskUpdateDTO.Difficulty is not null) taskUpdate.Difficulty = taskUpdate.Difficulty;
            return taskUpdate;
        }
    }
}
