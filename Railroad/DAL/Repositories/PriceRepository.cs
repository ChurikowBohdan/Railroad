using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        public PriceRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }
    }
}
