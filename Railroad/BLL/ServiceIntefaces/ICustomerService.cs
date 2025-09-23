
using Railroad.BLL.DTOs;
using Railroad.DAL.Entities;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface ICustomerService : ICrud<CustomerReadDTO, CustomerWriteDTO>
    {
        Task<IEnumerable<CustomerReadDTO?>> GetCustomersByTrainIdAsync(int trainId);
    }
}
