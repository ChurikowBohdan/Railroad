using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
    public interface IRoutePointRepository : IRepository<RoutePoint>
    {
        Task<IEnumerable<RoutePoint>> GetAllWithDetailsAsync();

        Task<RoutePoint?> GetByIdWithDetailsAsync(int id);
    }
}
