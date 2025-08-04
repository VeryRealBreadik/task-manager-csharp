using Microsoft.EntityFrameworkCore;
using TaskManager.Database.Context;
using TaskManager.Database.Models;
using TaskManager.Database.Models.Utilities;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new TodoAppContext();
            db.Database.EnsureCreated();

            var person1 = new Person("Ivan", "Ivanov");
            var person2 = new Person("Oleg", "Olegov");
            var person3 = new Person("Elena", "Igorevna");
            var task1 = new TodoTask(
                "Title1", "Description1",
                DateTime.UtcNow.Date.AddDays(-10), DateTime.UtcNow.Date,
                Priority.High, Difficulty.Hard, person1
            );
            task1.MarkCompleted();
            var task2 = new TodoTask(
                "Title2", "Description2",
                DateTime.UtcNow.Date.AddDays(-5), DateTime.UtcNow.Date.AddDays(100),
                Priority.High, Difficulty.Hard, person2
            );
            var task3 = new TodoTask(
                "Title3", "Description3",
                DateTime.UtcNow.Date.AddDays(1), DateTime.UtcNow.Date.AddDays(6),
                Priority.High, Difficulty.Hard, person3
            );

            // db.AddRange([task1, task2, task3]);
            // db.SaveChanges();

            // var tasksWithPeople = db.TodoTasks
            //     .Include(t => t.Assignee)
            //     .ToList();
            // foreach (TodoTask task in tasksWithPeople)
            // {
            //     Console.WriteLine(task.Assignee);
            // }

            // var thisWeekTasks = db.TodoTasks
            //     .Where(t =>
            //         !t.IsCompleted &&
            //         t.DueDate <= DateTime.UtcNow.AddDays(7))
            //     .Include(t => t.Assignee)
            //     .ToList();
            // foreach (TodoTask task in thisWeekTasks)
            // {
            //     Console.WriteLine(task);
            // }

            // var dbTask = db.TodoTasks
            //     .Single(t => t.Id == 2);
            // dbTask.MarkCompleted();
            // db.SaveChanges();

            var dbTaskToDelete = db.TodoTasks
                .SingleOrDefault(t => t.Id == 3);
            if (dbTaskToDelete != null)
            {
                db.Remove(dbTaskToDelete);
            }
            db.SaveChanges();
        }
    }
}
