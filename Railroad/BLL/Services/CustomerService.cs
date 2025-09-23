using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(CustomerWriteDTO customerWriteDTO)
        {
            var persons = await _unitOfWork.PersonRepository.GetAllAsync();
            var person = persons.FirstOrDefault(x => x.PhoneNumber == customerWriteDTO.PhoneNumber);
            
            if (person is not null)
            {
                var customer = new Customer
                {
                    DiscountValue = customerWriteDTO.DiscountValue,
                    Email = customerWriteDTO.Email,
                    RegistrationDate = DateTime.Now,
                    Person = person

                };
                await _unitOfWork.CustomerRepository.AddAsync(customer);
                await _unitOfWork.SaveAsync();
            }

            else
            {
                var customer = new Customer
                {
                    DiscountValue = customerWriteDTO.DiscountValue,
                    Email = customerWriteDTO.Email,
                    RegistrationDate = DateTime.Now,
                    Person = new Person
                    {
                        Name = customerWriteDTO.Name,
                        Surname = customerWriteDTO.Surname,
                        PhoneNumber = customerWriteDTO.PhoneNumber,
                        Country = customerWriteDTO.Country,
                        City = customerWriteDTO.City,
                        BirthDate = customerWriteDTO.BirthDate
                    }
                };
                await _unitOfWork.CustomerRepository.AddAsync(customer);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CustomerRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CustomerReadDTO>> GetAllAsync()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllWithDetailsAsync();
            return customers.Select(customer => MapToCustomerReadDTO(customer));
        }

        public async Task<CustomerReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.CustomerRepository.GetByIdWithDetailsAsync(id);
                if (entity != null)
                {
                    return MapToCustomerReadDTO(entity);
                }
            }
            return null;
        }


        public async Task<IEnumerable<CustomerReadDTO?>> GetCustomersByTrainIdAsync(int trainId)
        {
            var allCustomers = await _unitOfWork.CustomerRepository.GetAllWithDetailsAsync();
            var filteredCustomers = allCustomers.Where(x => x.Tickets.Any(t => t.TrainRoute.TrainId == trainId));
            if(filteredCustomers is not null)
            {
                return filteredCustomers.Select(customer => MapToCustomerReadDTO(customer));
            }
            return null;
        }

        public async Task UpdateAsync(int id, CustomerWriteDTO customerWriteDTO)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdWithDetailsAsync(id);
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(customer.PersonId);

            customer.DiscountValue = customerWriteDTO.DiscountValue;
            customer.Email = customerWriteDTO.Email;
            person.Name = customerWriteDTO.Name;
            person.Surname = customerWriteDTO.Surname;
            person.PhoneNumber = customerWriteDTO.PhoneNumber;
            person.City = customerWriteDTO.City;
            person.Country = customerWriteDTO.Country;

            await _unitOfWork.SaveAsync();
        }

        private CustomerReadDTO MapToCustomerReadDTO(Customer customer) => new CustomerReadDTO
        {
            CustomerId = customer.Id,
            Name = customer.Person.Name,
            Surname = customer.Person.Surname,
            PhoneNumber = customer.Person.PhoneNumber,
            Country = customer.Person.Country,
            City = customer.Person.City,
            BirthDate = customer.Person.BirthDate,
            DiscountValue = customer.DiscountValue,
            Email = customer.Email,
            RegistrationDate = customer.RegistrationDate,
            TicketsIds = customer.Tickets.Select(t => t.Id).ToList()
        };
    }
}
