using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class TrainRepository : Repository<Train>, ITrainRepository
    {
        public TrainRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }
    }
}
