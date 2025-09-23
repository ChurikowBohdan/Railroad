using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class RoutePointService : IRoutePointService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoutePointService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(RoutePointWriteDTO routePointDTO)
        {
            var trainRoute = await _unitOfWork.TrainRouteRepository.GetByIdAsync(routePointDTO.TrainRouteId);
            var station = await _unitOfWork.StationRepository.GetByIdAsync(routePointDTO.StationId);
            if (trainRoute != null && station != null)
            {
                var entity = new RoutePoint
                {
                    ArrivalTime = routePointDTO.ArrivalTime,
                    DepartureTime = routePointDTO.DepartureTime,
                    Platform = routePointDTO.Platform,
                    Order = routePointDTO.Order,
                    DistanceFromPreviousStation = routePointDTO.DistanceFromPreviousStation,
                    TrainRoute = trainRoute,
                    Station = station
                };

                await _unitOfWork.RoutePointRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.RoutePointRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RoutePointReadDTO>> GetAllAsync()
        {
            var routes = await _unitOfWork.RoutePointRepository.GetAllWithDetailsAsync();
            return routes.Select(route => MapToRoutePointReadDTO(route));
        }

        public async Task<RoutePointReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.RoutePointRepository.GetByIdWithDetailsAsync(id);
                if (entity != null)
                {
                    return MapToRoutePointReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int id, RoutePointWriteDTO routePointWriteDTO)
        {
            var routePoint = await _unitOfWork.RoutePointRepository.GetByIdWithDetailsAsync(id);

            routePoint.ArrivalTime = routePointWriteDTO.ArrivalTime;
            routePoint.DepartureTime = routePointWriteDTO.DepartureTime;
            routePoint.Platform = routePointWriteDTO.Platform;
            routePoint.Order = routePointWriteDTO.Order;
            routePoint.DistanceFromPreviousStation = routePointWriteDTO.DistanceFromPreviousStation;
            routePoint.TrainRouteId = routePointWriteDTO.TrainRouteId;
            routePoint.StationId = routePointWriteDTO.StationId;

            await _unitOfWork.SaveAsync();
        }

        private RoutePointReadDTO MapToRoutePointReadDTO(RoutePoint routePoint) => new RoutePointReadDTO
        {
            RoutePointId = routePoint.Id,
            TrainRouteId = routePoint.TrainRouteId,
            StationId = routePoint.StationId,
            ArrivalTime = routePoint.ArrivalTime,
            DepartureTime = routePoint.DepartureTime,
            Platform = routePoint.Platform,
            Order = routePoint.Order,
            DistanceFromPreviousStation = routePoint.DistanceFromPreviousStation
        };
    }
}
