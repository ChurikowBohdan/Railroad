using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<User>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(x => x.Person)
                 .ToListAsync();
        }

        public async Task<User?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet.Include(x => x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
