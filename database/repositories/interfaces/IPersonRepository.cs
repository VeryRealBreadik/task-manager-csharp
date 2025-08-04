using TaskManager.Database.Models;

namespace TaskManager.Database.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        // Create
        void Add(Person person);
        void BulkAdd(IEnumerable<Person> people);

        // Read
        IEnumerable<Person> GetAll();
        Person? GetById(int id);

        // Update
        void Update(Person person);
        void BulkUpdate(IEnumerable<Person> people);

        //Delete
        void Delete(int id);
        void BulkDelete(IEnumerable<int> ids);
    }
}
