using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(TicketWriteDTO ticketWriteDTO)
        {
            var route = await _unitOfWork.TrainRouteRepository.GetByIdWithDetailsAsync(ticketWriteDTO.TrainRouteId);
            var price = await _unitOfWork.PriceRepository.GetByIdAsync(ticketWriteDTO.PriceId);
            var customer = await _unitOfWork.CustomerRepository.GetByIdWithDetailsAsync(ticketWriteDTO.CustomerId);
            var departurePoint = route.RoutePoints
                .FirstOrDefault(rp => rp.StationId == ticketWriteDTO.DepartureStationId);
            var destinationPoint = route.RoutePoints
                .FirstOrDefault(rp => rp.StationId == ticketWriteDTO.DestinationStationId);

            if (customer is not null && price is not null && route is not null && departurePoint is not null && destinationPoint is not null)
            {

                var routePoints = route.RoutePoints
                    .Where(rp => rp.Order > departurePoint.Order
                              && rp.Order <= destinationPoint.Order)
                    .OrderBy(rp => rp.Order).ToList();

                decimal totalDistance = routePoints.Sum(rp => (decimal)rp.DistanceFromPreviousStation);
                decimal roadPrice = totalDistance * price.PriceForKilometer;
                decimal carriagePrice = (decimal)ticketWriteDTO.CarriageWeight * price.PriceForKGOfCarriageWeight;

                var entity = new Ticket
                {
                    DepartureStationId = ticketWriteDTO.DepartureStationId,
                    DestinationStationId = ticketWriteDTO.DestinationStationId,
                    CarriageWeight = ticketWriteDTO.CarriageWeight,
                    Seat = ticketWriteDTO.Seat,
                    CarriagePrice = carriagePrice,
                    RoadPrice = roadPrice,
                    FinalPrice = roadPrice + carriagePrice,
                    TrainRoute = route,
                    Price = price,
                    Customer = customer,
                };

                await _unitOfWork.TicketRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TicketRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<TicketReadDTO>> GetAllAsync()
        {
            var tickets = await _unitOfWork.TicketRepository.GetAllWithDetailsAsync();
            return tickets.Select(ticket => MapToTicketReadDTO(ticket));
        }

        public async Task<TicketReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var ticket = await _unitOfWork.TicketRepository.GetByIdWithDetailsAsync(id);
                if (ticket != null)
                {
                    return MapToTicketReadDTO(ticket);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int ticketId, TicketWriteDTO ticketWriteDTO)
        {
            var ticket = await _unitOfWork.TicketRepository.GetByIdWithDetailsAsync(ticketId);
            var route = await _unitOfWork.TrainRouteRepository.GetByIdWithDetailsAsync(ticketWriteDTO.TrainRouteId);
            var price = await _unitOfWork.PriceRepository.GetByIdAsync(ticketWriteDTO.PriceId);
            var customer = await _unitOfWork.CustomerRepository.GetByIdWithDetailsAsync(ticketWriteDTO.CustomerId);
            var departurePoint = route.RoutePoints
                .FirstOrDefault(rp => rp.StationId == ticketWriteDTO.DepartureStationId);
            var destinationPoint = route.RoutePoints
                .FirstOrDefault(rp => rp.StationId == ticketWriteDTO.DestinationStationId);

            if (customer is not null && price is not null && route is not null && departurePoint is not null && destinationPoint is not null)
            {

                var routePoints = route.RoutePoints
                    .Where(rp => rp.Order > departurePoint.Order
                              && rp.Order <= destinationPoint.Order)
                    .OrderBy(rp => rp.Order).ToList();

                decimal totalDistance = routePoints.Sum(rp => (decimal)rp.DistanceFromPreviousStation);
                decimal roadPrice = totalDistance * price.PriceForKilometer;
                decimal carriagePrice = (decimal)ticketWriteDTO.CarriageWeight * price.PriceForKGOfCarriageWeight;

                var entity = new Ticket
                {
                    Id = ticket.Id,
                    DepartureStationId = ticketWriteDTO.DepartureStationId,
                    DestinationStationId = ticketWriteDTO.DestinationStationId,
                    CarriageWeight = ticketWriteDTO.CarriageWeight,
                    Seat = ticketWriteDTO.Seat,
                    CarriagePrice = carriagePrice,
                    RoadPrice = roadPrice,
                    FinalPrice = roadPrice + carriagePrice,
                    TrainRoute = route,
                    Price = price,
                    Customer = customer,
                };

                await _unitOfWork.TicketRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();
            }

        }

        private TicketReadDTO MapToTicketReadDTO(Ticket ticket) => new TicketReadDTO
        {
            TicketId = ticket.Id,
            TrainRouteId = ticket.TrainRouteId,
            PriceId = ticket.PriceId,
            CustomerId = ticket.CustomerId,
            DepartureStationId = ticket.DepartureStationId,
            DestinationStationId = ticket.DestinationStationId,
            CarriageWeight = ticket.CarriageWeight,
            Seat = ticket.Seat,
            CarriagePrice = ticket.CarriagePrice,
            RoadPrice = ticket.RoadPrice,
            FinalPrice = ticket.FinalPrice,
            PurchaseDate = ticket.PurchaseDate
        };
    }
}
