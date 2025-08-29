using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
        public interface IUnitOfWork : IDisposable
        {
            ICustomerRepository CustomerRepository { get; }
            IPersonRepository PersonRepository { get; }
            IRoutePointRepository RoutePointRepository { get; }
            IStationRepository StationRepository { get; }
            ITicketRepository TicketRepository { get; }
            ITrainRouteRepository TrainRouteRepository { get; }


            Task SaveAsync();
        }
}
