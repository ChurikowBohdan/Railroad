using Microsoft.AspNetCore.Routing;
using Microsoft.Identity.Client;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class RouteFilterService : IRouteFilterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RouteFilterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<FilteredRouteReadDTO>> FilterSearch(string departureCityName, string arrivalCityName, RouteFilterDTO filterDTO)
        {
            var routes = await _unitOfWork.TrainRouteRepository.GetAllWithDetailsAsync();
            var orderedRoutes = routes.Select(r => new TrainRoute
            {
                Id = r.Id,
                TrainId = r.TrainId,
                Name = r.Name,
                Train = r.Train,
                RoutePoints = r.RoutePoints.OrderBy(p => p.Order).ToList(),
            });



            var baseFilter = orderedRoutes.Where(route => route.RoutePoints
            .Any(departurePoint => departurePoint.Station.CityName == departureCityName) && route.RoutePoints
            .Any(arrivalPoint => arrivalPoint.Station.CityName == arrivalCityName));

            var baseDTO = baseFilter.Select(routes => MapToDTO(routes)).ToList();
            return baseDTO;

            if (filterDTO.DepartureDate is null && filterDTO.ArrivalDate is null)
            {
                return baseDTO;
            }

        }

        public FilteredRouteReadDTO MapToDTO (TrainRoute route)
        {
            var departurePoint = route.RoutePoints.First();
            var arrivalPoint = route.RoutePoints.Last();
            return new FilteredRouteReadDTO
            {
                TrainRouteId = route.Id,
                TrainId = route.TrainId,
                RouteName = route.Name,
                TrainName = route.Train.Name,

                DepartureStationName = departurePoint.Station.Name,
                DepartureStationCityName = departurePoint.Station.CityName,
                DepartureStationDistrictName = departurePoint.Station.DistrictName,
                DepatrureTime = departurePoint.DepartureTime,
                DeparturePlatform = departurePoint.Platform,

                ArrivalStationName = arrivalPoint.Station.Name,
                ArrivalStationCityName = arrivalPoint.Station.CityName,
                ArrivalStationDistrictName = arrivalPoint.Station.DistrictName,
                ArrivalTime = arrivalPoint.ArrivalTime,
                ArrivalPlatform = arrivalPoint.Platform
            };
        }
    }
}
