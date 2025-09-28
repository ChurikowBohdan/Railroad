using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Ticket>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(x => x.Person)
                .Include(x => x.TrainRoute).ThenInclude(x => x.Train)
                .Include(x => x.TrainRoute).ThenInclude(x => x.RoutePoints)
                .Include(x => x.Price)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet.Include(x => x.Person)
                .Include(x => x.TrainRoute).ThenInclude(x => x.Train)
                .Include(x => x.TrainRoute).ThenInclude(x => x.RoutePoints)
                .Include(x => x.Price)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
