using Railroad.BLL.DTOs;
using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithDetailsAsync();

        Task<Customer?> GetByIdWithDetailsAsync(int id);
    }
}
