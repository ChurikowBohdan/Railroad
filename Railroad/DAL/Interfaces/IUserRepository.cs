using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithDetailsAsync();

        Task<User?> GetByIdWithDetailsAsync(int id);

        Task<User?> GetByUsernameAsync(string username);
    }
}
