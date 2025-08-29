using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }
    }
}
