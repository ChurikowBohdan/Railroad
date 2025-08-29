using Microsoft.EntityFrameworkCore;
using Railroad.BLL.DTOs;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RailroadDbContext dbContext) : base(dbContext)
        { }
        public async Task<IEnumerable<Customer>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(x => x.Person)
                 .Include(x => x.Tickets).ThenInclude(x => x.TrainRoute)
                 .ToListAsync();
        }

        public async Task<Customer?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet.Include(x => x.Person)
                .Include(x => x.Tickets).ThenInclude(x => x.TrainRoute)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
