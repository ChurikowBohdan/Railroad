using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(PersonWriteDTO data)
        {
            var entity = new Person
            {
                Name = data.Name,
                Surname = data.Surname,
                PhoneNumber = data.PhoneNumber,
                Country = data.Country,
                City = data.City,
                BirthDate = data.BirthDate
            };

            await _unitOfWork.PersonRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PersonRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PersonReadDTO>> GetAllAsync()
        {
            var persons = await _unitOfWork.PersonRepository.GetAllAsync();
            return persons.Select(persons => MapToPersonReadDTO(persons));
        }

        public async Task<PersonReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.PersonRepository.GetByIdAsync(id);
                if (entity != null)
                {
                    return MapToPersonReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int id, PersonWriteDTO personWriteDTO)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(id);

            person.Name = personWriteDTO.Name;
            person.Surname = personWriteDTO.Surname;
            person.PhoneNumber = personWriteDTO.PhoneNumber;
            person.Country = personWriteDTO.Country;
            person.City = personWriteDTO.City;
            person.BirthDate = personWriteDTO.BirthDate;

            await _unitOfWork.SaveAsync();
        }

        private PersonReadDTO MapToPersonReadDTO(Person person) => new PersonReadDTO
        {
            PersonId = person.Id,
            Name = person.Name,
            Surname = person.Surname,
            PhoneNumber = person.PhoneNumber,
            Country = person.Country,
            City = person.City,
            BirthDate = person.BirthDate
        };
    }
}
