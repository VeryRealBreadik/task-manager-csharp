using Microsoft.EntityFrameworkCore;
using TaskManager.Database.Models;

namespace TaskManager.Database.Context
{
    public class TodoAppContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo.db");
        }
    }
}
