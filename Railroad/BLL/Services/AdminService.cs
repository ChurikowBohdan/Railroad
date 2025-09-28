using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AdminWriteDTO adminWriteDTO)
        {
            var persons = await _unitOfWork.PersonRepository.GetAllAsync();
            var person = persons.FirstOrDefault(x => x.PhoneNumber == adminWriteDTO.PhoneNumber);

            if (person is not null)
            {
                var admin = new Admin
                {   DiscountValue = adminWriteDTO.DiscountValue,
                    Person = person
                };
                await _unitOfWork.AdminRepository.AddAsync(admin);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                var admin = new Admin
                {
                    DiscountValue = adminWriteDTO.DiscountValue,
                    Email = adminWriteDTO.Email,
                    RegistrationDate = DateTime.Now,
                    Person = new Person
                    {
                        Name = adminWriteDTO.Name,
                        Surname = adminWriteDTO.Surname,
                        PhoneNumber = adminWriteDTO.PhoneNumber,
                        Country = adminWriteDTO.Country,
                        City = adminWriteDTO.City,
                        BirthDate = adminWriteDTO.BirthDate
                    }
                };
                await _unitOfWork.AdminRepository.AddAsync(admin);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.AdminRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AdminReadDTO>> GetAllAsync()
        {
            var admins = await _unitOfWork.AdminRepository.GetAllWithDetailsAsync();
            return admins.Select(admin => MapToAdminReadDTO(admin));
        }

        public async Task<AdminReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.AdminRepository.GetByIdWithDetailsAsync(id);
                if (entity != null)
                {
                    return MapToAdminReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int id, AdminWriteDTO adminWriteDTO)
        {
            var admin = await _unitOfWork.AdminRepository.GetByIdWithDetailsAsync(id);

            admin.DiscountValue = adminWriteDTO.DiscountValue;
            admin.Email = adminWriteDTO.Email;

            await _unitOfWork.SaveAsync();
        }

        private AdminReadDTO MapToAdminReadDTO(Admin admin) => new AdminReadDTO
        {
            AdminId = admin.Id,
            Name = admin.Person.Name,
            Surname = admin.Person.Surname,
            PhoneNumber =   admin.Person.PhoneNumber,
            Country = admin.Person.Country,
            City = admin.Person.City,
            BirthDate = admin.Person.BirthDate,
            DiscountValue = admin.DiscountValue,
            Email = admin.Email,
            RegistrationDate = admin.RegistrationDate,
            TicketsIds = admin.Tickets.Select(t => t.Id).ToList()
        };
    }
}
