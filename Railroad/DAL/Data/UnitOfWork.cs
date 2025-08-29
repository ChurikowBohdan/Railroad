using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;
using Railroad.DAL.Repositories;

namespace Railroad.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RailroadDbContext _context;
        private bool disposed = false;

        public UnitOfWork(RailroadDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository => new CustomerRepository(_context);
        public IPersonRepository PersonRepository => new PersonRepository(_context);
        public IPriceRepository PriceRepository => new PriceRepository(_context);
        public IRoutePointRepository RoutePointRepository => new RoutePointRepository(_context);
        public IStationRepository StationRepository => new StationRepository(_context);
        public ITicketRepository TicketRepository => new TicketRepository(_context);
        public ITrainRepository TrainRepository => new TrainRepository(_context);
        public ITrainRouteRepository TrainRouteRepository => new TrainRouteRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
