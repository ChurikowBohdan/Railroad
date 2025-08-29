using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetAllWithDetailsAsync();

        Task<Ticket> GetByIdWithDetailsAsync(int id);
    }
}
