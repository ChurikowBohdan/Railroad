using Microsoft.AspNetCore.Routing;
using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
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

            var orderedRoutes = routes.Where(x => x.RoutePoints.OrderBy(o => o.Order) != null);
        }
    }
}
