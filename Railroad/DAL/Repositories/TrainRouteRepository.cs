using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class TrainRouteRepository : Repository<TrainRoute>, ITrainRouteRepository
    {
        public TrainRouteRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<TrainRoute>> GetAllWithDetailsAsync()
        {
            return await _dbSet.Include(x => x.Train).Include(x => x.RoutePoints).ThenInclude(x => x.Station)
                 .ToListAsync();
        }

        public async Task<TrainRoute?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet.Include(x => x.Train).Include(x => x.RoutePoints).ThenInclude(x => x.Station)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
