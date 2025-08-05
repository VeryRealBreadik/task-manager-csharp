using TaskManager.Database.DTOs;

namespace TaskManager.Database.Services.Interfaces
{
    public interface IPersonService
    {
        // Create
        void Add(PersonDTO person);
        void BulkAdd(IEnumerable<PersonDTO> people);

        // Read
        IEnumerable<PersonDTO> GetAll();
        PersonDTO? GetById(int id);

        // Update
        void Update(PersonUpdateDTO person);
        void BulkUpdate(IEnumerable<PersonUpdateDTO> people);

        //Delete
        void Delete(int id);
        void BulkDelete(IEnumerable<int> ids);
    }
}
