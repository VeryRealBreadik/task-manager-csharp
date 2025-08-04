using TaskManager.Models;
using TaskManager.Models.Utilities;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person("Ivan", "Ivanov");
            var person2 = new Person("Oleg", "Olegov");
            var person3 = new Person("Elena", "Igorevna");
            var task1 = new Models.Task(
                "Title1", "Description1",
                DateTime.UtcNow.Date.AddDays(-10), DateTime.UtcNow.Date,
                Priority.High, Difficulty.Hard, person1
            );
            task1.MarkCompleted();
            var task2 = new Models.Task(
                "Title2", "Description2",
                DateTime.UtcNow.Date.AddDays(-5), DateTime.UtcNow.Date.AddDays(100),
                Priority.High, Difficulty.Hard, person2
            );
            var task3 = new Models.Task(
                "Title3", "Description3",
                DateTime.UtcNow.Date.AddDays(10), DateTime.UtcNow.Date.AddDays(70),
                Priority.High, Difficulty.Hard, person3
            );

            var tasks = new List<Models.Task> { task1, task2, task3 };
            var incompleteTasks = tasks
                .Where(t => !t.IsCompleted)
                .OrderBy(t => t.DueDate)
                .Select(t => t.Title)
                .ToList();
            foreach (string task in incompleteTasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}
