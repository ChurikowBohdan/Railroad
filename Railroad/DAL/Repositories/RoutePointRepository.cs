using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class RoutePointRepository : Repository<RoutePoint>, IRoutePointRepository
    {
        public RoutePointRepository(RailroadDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<RoutePoint>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(x => x.TrainRoute)
                 .Include(x => x.Station)
                 .ToListAsync();
        }

        public async Task<RoutePoint?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet.Include(x => x.TrainRoute)
                .Include(x => x.Station)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
