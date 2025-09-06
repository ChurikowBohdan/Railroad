using Microsoft.Identity.Client;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RailroadDbContext dbContext) : base(dbContext)
        {
        }
    }
}
