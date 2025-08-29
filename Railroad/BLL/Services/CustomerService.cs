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
        public async Task AddAsync(CustomerWriteDTO customerDTO)
        {
            var entity = new Customer
            {
                DiscountValue = customerDTO.DiscountValue,
                Email = customerDTO.Email,
                RegistrationDate = DateTime.Now,
                Person = new Person
                {
                    Name = customerDTO.Name,
                    Surname = customerDTO.Surname,
                    PhoneNumber = customerDTO.PhoneNumber,
                    Country = customerDTO.Country,
                    City = customerDTO.City,
                    BirthDate = customerDTO.BirthDate
                }
            };

            await _unitOfWork.CustomerRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CustomerRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<CustomerReadDTO>> GetAllAsync()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllWithDetailsAsync();
            return customers.Select(customer => MapToCustomerReadDTO(customer.Id, customer));
        }

        public async Task<CustomerReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.CustomerRepository.GetByIdWithDetailsAsync(id);
                if (entity != null)
                {
                    return MapToCustomerReadDTO(id, entity);
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
                return filteredCustomers.Select(customer => MapToCustomerReadDTO(customer.Id, customer));
            }
            return null;
        }

        public async Task UpdateAsync(int customerId, CustomerWriteDTO data)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdWithDetailsAsync(customerId);
            var entity = new Customer
            {
                Id = customerId,
                PersonId = customer.PersonId,
                DiscountValue = data.DiscountValue,
                Email = data.Email,
                RegistrationDate = customer.RegistrationDate,
                Person = customer.Person,
                Tickets = customer.Tickets,
            };

            _unitOfWork.CustomerRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        private CustomerReadDTO MapToCustomerReadDTO(int id, Customer customer) => new CustomerReadDTO
        {
            CustomerId = id,
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
