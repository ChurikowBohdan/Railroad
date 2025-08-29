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
    }
}
