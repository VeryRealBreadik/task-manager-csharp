using Microsoft.EntityFrameworkCore;
using TaskManager.Database.Context;
using TaskManager.Database.Models;
using TaskManager.Database.Repositories.Interfaces;

namespace TaskManager.Database.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TodoAppContext _context;

        public PersonRepository(TodoAppContext context)
        {
            _context = context;
        }

        // Create
        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public void BulkAdd(IEnumerable<Person> people)
        {
            _context.AddRange(people);
            _context.SaveChanges();
        }

        // Read
        public IEnumerable<Person> GetAll() => _context.People
            .Include(p => p.AssignedTasks)
            .ToList();

        public Person? GetById(int id) => _context.People
            .Include(p => p.AssignedTasks)
            .Single(p => p.Id == id);

        // Update
        public void Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }

        public void BulkUpdate(IEnumerable<Person> people)
        {
            _context.UpdateRange(people);
            _context.SaveChanges();
        }

        //Delete
        public void Delete(int id)
        {
            var dbPerson = _context.People
                .Single(p => p.Id == id);
            if (dbPerson != null)
            {
                _context.Remove(dbPerson);
                _context.SaveChanges();
            }
        }

        public void BulkDelete(IEnumerable<int> ids)
        {
            var dbPeople = _context.People
                .Where(p => ids.Contains(p.Id))
                .ToList();
            _context.RemoveRange(dbPeople);
            _context.SaveChanges();
        }
    }
}
