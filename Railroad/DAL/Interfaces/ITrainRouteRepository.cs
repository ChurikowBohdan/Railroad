using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
    public interface ITrainRouteRepository : IRepository<TrainRoute>
    {
        Task<IEnumerable<TrainRoute>> GetAllWithDetailsAsync();

        Task<TrainRoute> GetByIdWithDetailsAsync(int id);
    }
}
