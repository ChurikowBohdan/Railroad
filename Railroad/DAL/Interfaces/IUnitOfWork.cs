using Railroad.DAL.Entities;

namespace Railroad.DAL.Interfaces
{
        public interface IUnitOfWork : IDisposable
        {
            ICustomerRepository CustomerRepository { get; }
            IPersonRepository PersonRepository { get; }
            IPriceRepository PriceRepository { get; }
            IRoutePointRepository RoutePointRepository { get; }
            IStationRepository StationRepository { get; }
            ITicketRepository TicketRepository { get; }
            ITrainRepository TrainRepository { get; }
            ITrainRouteRepository TrainRouteRepository { get; }


            Task SaveAsync();
        }
}
