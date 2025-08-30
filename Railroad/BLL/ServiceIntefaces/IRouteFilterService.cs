using Railroad.BLL.DTOs;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface IRouteFilterService
    {
        Task<ICollection<FilteredRouteReadDTO>> FilterSearch(string departureCityName, string arrivalCityName, RouteFilterDTO filterDTO);
    }
}
