using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Admin>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(x => x.Person)
                 .ToListAsync();
        }

        public async Task<Admin?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet.Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
