using TaskManager.Database.DTOs;
using TaskManager.Database.Models;
using TaskManager.Database.Repositories.Implementations;
using TaskManager.Database.Repositories.Interfaces;
using TaskManager.Database.Services.Interfaces;

namespace TaskManager.Database.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // Create
        public void Add(PersonDTO personDTO) => _personRepository.Add(FromDTO(personDTO));

        public void BulkAdd(IEnumerable<PersonDTO> peopleDTOs)
        {
            var people = peopleDTOs
                .Select(FromDTO)
                .ToList();
            _personRepository.BulkAdd(people);
        }

        // Read
        public IEnumerable<PersonDTO> GetAll()
        {
            var people = _personRepository.GetAll();
            var peopleDTOs = people
                .Select(ToDTO)
                .ToList();
            return peopleDTOs;
        }

        public PersonDTO? GetById(int id)
        {
            var person = _personRepository.GetById(id);
            if (person is null) return null;
            var personDTO = ToDTO(person);
            return personDTO;
        }

        // Update
        public void Update(PersonUpdateDTO personUpdateDTO)
        {
            var personUpdate = FromDTO(personUpdateDTO);
            _personRepository.Update(personUpdate);
        }

        public void BulkUpdate(IEnumerable<PersonUpdateDTO> peopleUpdateDTOs)
        {
            var peopleUpdate = peopleUpdateDTOs
                .Select(FromDTO)
                .ToList();
            _personRepository.BulkUpdate(peopleUpdate);
        }

        //Delete
        public void Delete(int id) => _personRepository.Delete(id);

        public void BulkDelete(IEnumerable<int> ids) => _personRepository.BulkDelete(ids);

        private PersonDTO ToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };
        }

        private Person FromDTO(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
            };
        }

        private Person FromDTO(PersonUpdateDTO personUpdateDTO)
        {
            var personUpdate = new Person();
            personUpdate.Id = personUpdateDTO.Id;
            if (personUpdateDTO.FirstName is not null) personUpdate.FirstName = personUpdateDTO.FirstName;
            if (personUpdateDTO.LastName is not null) personUpdate.LastName = personUpdateDTO.LastName;
            return personUpdate;
        }
    }
}
