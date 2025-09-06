using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<IEnumerable<Admin>> GetAllWithDetailsAsync();
        Task<Admin?> GetByIdWithDetailsAsync(int id);
    }
}
